using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;


namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;    //Адаптер данных
        string connString = myPublic.connString;
        string selRoute = "Все путевки";
        public ObservableCollection<ChartPoint> ChartData;
        int[] count = new int[12];

        public Statistics()
        {
            InitializeComponent();
            string selectCmd = "SELECT name FROM Route order by name";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "routes");

            DataRow row = ds.Tables[0].NewRow();
            row["name"] = "Все путевки";
            routeCb.DataContext = ds;
            routeCb.DisplayMemberPath = "name";
            ds.Tables[0].Rows.Add(row);

            routeCb.SelectedIndex = ds.Tables[0].Rows.Count - 1;
            updateChart();

        }

        private void routeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectCmd = "SELECT name FROM Route order by name";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "routes");

            DataRow row = ds.Tables[0].NewRow();
            row["name"] = "Все путевки";

            ds.Tables[0].Rows.Add(row);
            selRoute = ds.Tables[0].Rows[routeCb.SelectedIndex][0].ToString();
            updateChart();
        }

        private void updateChart()
        {
            string selectCmd;
            //информация для графика
            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=1";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "janVouchers");
            count[0] = Convert.ToInt32(ds.Tables["janVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=2";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "febVouchers");
            count[1] = Convert.ToInt32(ds.Tables["febVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=3";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "marVouchers");
            count[2] = Convert.ToInt32(ds.Tables["marVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=4";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "aprVouchers");
            count[3] = Convert.ToInt32(ds.Tables["aprVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=5";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "mayVouchers");
            count[4] = Convert.ToInt32(ds.Tables["mayVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=6";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "junVouchers");
            count[5] = Convert.ToInt32(ds.Tables["junVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=7";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "julVouchers");
            count[6] = Convert.ToInt32(ds.Tables["julVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=8";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "augVouchers");
            count[7] = Convert.ToInt32(ds.Tables["augVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=9";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "sepVouchers");
            count[8] = Convert.ToInt32(ds.Tables["sepVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=10";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "octVouchers");
            count[9] = Convert.ToInt32(ds.Tables["octVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=11";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "novVouchers");
            count[10] = Convert.ToInt32(ds.Tables["novVouchers"].Rows[0][0]);

            selectCmd = "SELECT Count(Voucher.ID) AS CountOfID FROM Route, Schedule, Voucher WHERE (((Schedule.ID)=[Voucher].[shedule_id]) AND ((Route.ID)=[Schedule].[route_id])) and Month(Voucher.Date)=12";
            if (selRoute != "Все путевки") selectCmd += " and Route.name='" + selRoute + "'";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "decVouchers");
            count[11] = Convert.ToInt32(ds.Tables["decVouchers"].Rows[0][0]);
            ChartData = new ObservableCollection<ChartPoint>
            {
    new ChartPoint{ Value = count[0], Month = "Январь" },
    new ChartPoint{ Value = count[1], Month = "Февраль" },
    new ChartPoint{ Value = count[2], Month = "Март" },
    new ChartPoint{ Value = count[3], Month = "Апрель" },
    new ChartPoint{ Value = count[4], Month = "Май" },
    new ChartPoint{ Value = count[5], Month = "Июнь" },
    new ChartPoint{ Value = count[6], Month = "Июль" },
    new ChartPoint{ Value = count[7], Month = "Август" },
    new ChartPoint{ Value = count[8], Month = "Сентябрь" },
    new ChartPoint{ Value = count[9], Month = "Октябрь" },
    new ChartPoint{ Value = count[10], Month = "Ноябрь" },
    new ChartPoint{ Value = count[11], Month = "Декабрь" },
            };
            ChartOne.ItemsSource = ChartData;
        }
    }
}