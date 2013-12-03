using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        //Общие объекты
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;    //Адаптер данных
        FlowDocument document = new FlowDocument();
        string b_date;
        string e_date;
        string connString = myPublic.connString;

        public Report()
        {
            InitializeComponent();
        }

        private void OnInit(object sender, EventArgs e)
        {
            string selectCmd = "SELECT Route.name AS [Путевка], Route.price AS [Стоимость], count(Voucher.ID) AS [Количество заказов], Route.price*count(Voucher.ID) AS [Объем продаж путевки] FROM Voucher, Route, Schedule, Employee WHERE Voucher.shedule_id=Schedule.ID and Schedule.route_id=Route.ID group by Route.name, Route.price";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "orders");
            dataGridRoutes.DataContext = ds;

            updateChart();
        }
        
        private void updateChart()         
        {
             PieChart.DataContext = ds.Tables["orders"];
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            b_date = tb_begin_date.Text;
            e_date = tb_end_date.Text;
            try
            {
                b_date=b_date.Replace('.', '/');
                e_date=e_date.Replace('.', '/');
                string selectCmd;
                if (tb_begin_date.Text == "") { selectCmd = "SELECT Route.name AS [Путевка], Route.price AS [Стоимость], count(Voucher.ID) AS [Количество заказов], Route.price*count(Voucher.ID) AS [Объем продаж путевки] FROM Voucher, Route, Schedule, Employee WHERE Voucher.shedule_id=Schedule.ID and Schedule.route_id=Route.ID and Voucher.employee_id=Employee.ID and Voucher.date<=DateValue('" + e_date + "') group by Route.name, Route.price"; }
                else if (tb_end_date.Text == "") { selectCmd = "SELECT Route.name AS [Путевка], Route.price AS [Стоимость], count(Voucher.ID) AS [Количество заказов], Route.price*count(Voucher.ID) AS [Объем продаж путевки] FROM Voucher, Route, Schedule, Employee WHERE Voucher.shedule_id=Schedule.ID and Schedule.route_id=Route.ID and Voucher.employee_id=Employee.ID and Voucher.date>=DateValue('" + b_date + "') group by Route.name, Route.price"; }
                else { selectCmd = "SELECT Route.name AS [Путевка], Route.price AS [Стоимость], count(Voucher.ID) AS [Количество заказов], Route.price*count(Voucher.ID) AS [Объем продаж путевки] FROM Voucher, Route, Schedule, Employee WHERE Voucher.shedule_id=Schedule.ID and Schedule.route_id=Route.ID and Voucher.employee_id=Employee.ID and Voucher.date>=DateValue('" + b_date + "') and  Voucher.date<=DateValue('" + e_date + "') group by Route.name, Route.price"; }
                da = new OleDbDataAdapter(selectCmd, connString);
                ds = new DataSet();
                da.Fill(ds, "orders");

                if (ds.Tables["orders"].Rows.Count == 0) MessageBox.Show("Данных за текущий период нет", "Отчеты", MessageBoxButton.OK, MessageBoxImage.Warning);
                dataGridRoutes.DataContext = ds;
                updateChart();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные введены неправильно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Paragraph paragraph = new Paragraph();
            document.FontFamily = new FontFamily("Arial");
            Bold caption = new Bold(new Run("Отчет об объемах продаж туристического агенства \"SunTravel\""));
            caption.FontSize = 20;
            paragraph.Inlines.Add(new LineBreak());
            paragraph.Inlines.Add(caption);
            paragraph.Inlines.Add(new LineBreak());
            if (b_date == "" && e_date == "" || b_date == null && e_date == null) paragraph.Inlines.Add(new Run("За весь период: "));
            else paragraph.Inlines.Add(new Run("За период: " + b_date + " - " + e_date));
            paragraph.Inlines.Add(new LineBreak());
            paragraph.Inlines.Add(new LineBreak());

            document.Blocks.Add(paragraph);

            Table table1 = new Table();
            document.Blocks.Add(table1);

            // Set some global formatting properties for the table.
            table1.CellSpacing = 10;

            table1.Columns.Add(new TableColumn());
            table1.Columns.Add(new TableColumn());
            table1.Columns.Add(new TableColumn());
            table1.Columns.Add(new TableColumn());


            table1.RowGroups.Add(new TableRowGroup());

            // Add the first (title) row.
            table1.RowGroups[0].Rows.Add(new TableRow());

            // Alias the current working row for easy reference.
            TableRow currentRow = table1.RowGroups[0].Rows[0];

            // Global formatting for the title row.
            currentRow.Background = Brushes.Silver;
            currentRow.FontSize = 16;

            // Add the header row with content, 
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Путевка"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Стоимость"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Количество заказов"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Объем продаж путевки"))));

            string[,] array = DataGridUtil.ReadOnlyDataGridToArray(dataGridRoutes);
            int sum = 0;

            for (var i = 0; i < array.GetLength(0); i++)
            {
                table1.RowGroups.Add(new TableRowGroup());
                table1.RowGroups[i + 1].Rows.Add(new TableRow());
                TableRow currentRow1 = table1.RowGroups[i + 1].Rows[0];
                sum += Convert.ToInt32(array[i, 3]);
                currentRow1.FontSize = 14;
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    currentRow1.Cells.Add(new TableCell(new Paragraph(new Run(array[i, j]))));
                }
                // currentRow.Cells[0].ColumnSpan = 4;
                if (i % 2 != 0) currentRow1.Background = Brushes.LightGray;
            }


            Paragraph paragraph1 = new Paragraph();
            paragraph1.Inlines.Add(new LineBreak());
            paragraph1.Inlines.Add(new LineBreak());

            paragraph1.Inlines.Add(new Bold(new Run("Итого: " + sum + " грн.")));


            document.Blocks.Add(paragraph1);
            PrintDialog pd = new PrintDialog();
            document.PageHeight = pd.PrintableAreaHeight;
            document.PageWidth = pd.PrintableAreaWidth;
            document.PagePadding = new Thickness(50);
            document.ColumnGap = 0;
            document.ColumnWidth = pd.PrintableAreaWidth;

            IDocumentPaginatorSource dps = document;
            pd.PrintDocument(dps.DocumentPaginator, "Отчет");

            MessageBox.Show("Документ успешно нaпечатан", "Печать", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }
}


