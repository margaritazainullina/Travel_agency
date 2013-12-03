using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;    //Адаптер данных
        int cl_id = -1;
        string cl_name;
        int passp_n;
        string passp_s;
        string cur_date = DateTime.Today.ToShortDateString();
        int emp_id = AppSettings.userId;
        string emp_name = AppSettings.userName;
        int sch_id = AppSettings.currentScheduleId;
        int voucher_id=-1;
        string b_date;
        string e_date;
        string connString = myPublic.connString;

        public Order()
        {
            
            string selectCmd = "SELECT  Format(Schedule.begin_date, 'dd/mm/yy') as bd,  Format(Schedule.end_date, 'dd/mm/yy') as ed, Route.price as p From Schedule, Route WHERE Schedule.route_id = Route.ID and Schedule.ID = " + AppSettings.currentScheduleId;

            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "info");
            InitializeComponent();

            voucherTb.Text = AppSettings.currentTourName;
            b_dateTb.Text = CurrentOrder.b_date;
            b_date = CurrentOrder.b_date;
            e_dateTb.Text = CurrentOrder.e_date;
            e_date = CurrentOrder.e_date;
            priceTb.Text = CurrentOrder.price.ToString();
            empTb.Text = emp_name;

            foreach (string i in CurrentOrder.hotels) 
            {
                hotelsTb.Text += i+"\r\n";
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                cl_name = nameTb.Text;
                passp_n = Convert.ToInt32(nTb.Text);
                passp_s = sTb.Text;
                cl_id = getNewClientID();
                voucher_id = getNewVoucherId();

                CurrentOrder.cl_id = this.cl_id;
                CurrentOrder.cl_name = this.cl_name;
                CurrentOrder.passp_n = this.passp_n;
                CurrentOrder.passp_s = this.passp_s;
                CurrentOrder.cur_date = this.cur_date;
                CurrentOrder.emp_id = this.emp_id;
                CurrentOrder.emp_name = this.emp_name;
                CurrentOrder.sch_id = this.sch_id;
                CurrentOrder.voucher_id = this.voucher_id;

                //запись в базу информации о ваучере
                string selectCmd1 = "INSERT INTO Voucher values( " + voucher_id + ", '" + DateTime.Today.ToShortDateString() + "'," + cl_id + ", " + emp_id + ", " + sch_id + ")";
                da = new OleDbDataAdapter(selectCmd1, connString);
                ds = new DataSet();
                da.Fill(ds, "info");

                //запись в базу информации о страховке
                int ins_id = getNewInsuranseId();
                CurrentOrder.ins_amount = CurrentOrder.price * 3;
                CurrentOrder.fee = CurrentOrder.price * 0.001;
                string selectCmd2 = "INSERT INTO Insurance values(" + ins_id + ", " + CurrentOrder.fee + ", " + CurrentOrder.ins_amount +", "+voucher_id +")";
                da = new OleDbDataAdapter(selectCmd2, connString);
                ds = new DataSet();
                da.Fill(ds, "infoins");

                //запись в базу информации о чеке
                int bill_id = getNewBillId();
                string selectCmd3 = "INSERT INTO Bill values(" + bill_id + ", '" + cur_date + "', " + CurrentOrder.price + ", " + voucher_id + ")";
                da = new OleDbDataAdapter(selectCmd3, connString);
                ds = new DataSet();
                da.Fill(ds, "infobill");

                BillPreview win2 = new BillPreview();
                win2.Show();
                InsurancePreview win1 = new InsurancePreview();
                win1.Show();
                OrderPreview win = new OrderPreview();
                win.Show();
            }
            catch (Exception ex) { MessageBox.Show("Данные введены неправильно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        public int getNewVoucherId()
        {
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Voucher";

            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "vouchersID");

            return Convert.ToInt32(ds.Tables["vouchersID"].Rows[0]["ID"]) + 1;
        }

        public int getNewInsuranseId()
        {
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Insurance";

            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "insuranceID");

            return Convert.ToInt32(ds.Tables["insuranceID"].Rows[0]["ID"]) + 1;
        }

        public int getNewBillId()
        {
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Bill";

            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "billID");

            return Convert.ToInt32(ds.Tables["billID"].Rows[0]["ID"]) + 1;
        }

        public int getNewClientID() 
        {
            try
            {
                //если клиент есть - вернуть его id
                string connString = myPublic.connString;
                string selectCmd = "SELECT ID From Client WHERE passport_n = " + passp_n;

                da = new OleDbDataAdapter(selectCmd, connString);
                ds = new DataSet();
                da.Fill(ds, "client");

                DataView d1 = new DataView(ds.Tables["client"]);
                if (ds.Tables["client"].Rows.Count == 0) throw new Exception();
                return Convert.ToInt32(ds.Tables["client"].Rows[0]["ID"]);
            }
            catch (Exception ex)
            {
                string connString = myPublic.connString;
                string selectCmd = "SELECT max(ID) as ID From Client";

                da = new OleDbDataAdapter(selectCmd, connString);
                ds = new DataSet();
                da.Fill(ds, "client");

                cl_id = Convert.ToInt32(ds.Tables["client"].Rows[0]["ID"]) + 1;

                //запись в таблицу Client если клиента с таким номером паспорта нет
                string selectCmd1 = "INSERT into Client values( " + cl_id + ", '" + cl_name + "', " + passp_n + " , '" + passp_s + "')";
                da = new OleDbDataAdapter(selectCmd1, connString);
                ds = new DataSet();
                da.Fill(ds, "client");

                return cl_id;
            }
        }

    }
}
