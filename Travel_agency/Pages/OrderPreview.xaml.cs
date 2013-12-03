using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for OrderPreview.xaml
    /// </summary>
    public partial class OrderPreview : Window
    {
        FlowDocument document = new FlowDocument();

        public OrderPreview()
        {
            try
            {

                InitializeComponent();
                Paragraph paragraph = new Paragraph();
                document.FontFamily = new FontFamily("Arial");
                Bold caption = new Bold(new Run("Туристический ваучер"));
                caption.FontSize = 20;
                caption.BaselineAlignment = BaselineAlignment.Center;
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(caption);
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("№ " + CurrentOrder.voucher_id + "                               " + CurrentOrder.cur_date));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("Кому: ")));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("ФИО: " + CurrentOrder.cl_name));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Номер и серия паспорта: " + CurrentOrder.passp_s + " " + CurrentOrder.passp_n));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("На период: ")));
                paragraph.Inlines.Add(new Run("от " + CurrentOrder.b_date + " до " + CurrentOrder.e_date));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("Услуги: ")));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("Проживание: ")));
                paragraph.Inlines.Add(new LineBreak());
                for (int i = 0; i < CurrentOrder.hotels.Count; i++)
                {
                    paragraph.Inlines.Add(new Run(CurrentOrder.cities.ElementAt(i) + " - Отель \"" + CurrentOrder.hotels.ElementAt(i) + "\""));
                    paragraph.Inlines.Add(new LineBreak());
                }
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("Транспорт: ")));
                paragraph.Inlines.Add(new Run(CurrentOrder.transport));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("Питание: ")));
                paragraph.Inlines.Add(new Run(CurrentOrder.mealtype));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Bold(new Run("Экскурсии: ")));
                paragraph.Inlines.Add(new LineBreak());

                if (CurrentOrder.excursion.Count == 0) paragraph.Inlines.Add(new Run(" - "));
                else
                    for (int i = 0; i < CurrentOrder.hotels.Count; i++)
                    {
                        paragraph.Inlines.Add(new Run(CurrentOrder.excursion.ElementAt(i)));
                        paragraph.Inlines.Add(new LineBreak());
                    }

                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Подпись клиента __________         Туристический менеджер " + CurrentOrder.emp_name + " __________"));

                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("Туристическое агенство \"SunTravel\""));
                paragraph.Inlines.Add(new LineBreak());
                paragraph.Inlines.Add(new Run("г.Харьков"));
                document.Blocks.Add(paragraph);
                reportRtb.Document = document; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);                        
            }
        }

        public void printOrder() 
        {
            PrintDialog pd = new PrintDialog();
            document.PageHeight = pd.PrintableAreaHeight;
            document.PageWidth = pd.PrintableAreaWidth;
            document.PagePadding = new Thickness(50);
            document.ColumnGap = 0;
            document.ColumnWidth = pd.PrintableAreaWidth;

            IDocumentPaginatorSource dps = document;
            pd.PrintDocument(dps.DocumentPaginator, "Заказ");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            printOrder();
            MessageBox.Show("Документ успешно нaпечатан", "Печать", MessageBoxButton.OK, MessageBoxImage.Information); 
        }
    }
}
