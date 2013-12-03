using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        string connString = myPublic.connString;
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;    //Адаптер данных
        string selectCmd;
        string[,] dataArray;

        public Schedule()
        {
            InitializeComponent();
            checkUserRights();
        }

        private void hideCol(object sender, EventArgs e)
        {
            dataGridSchedules.Columns[0].Visibility = Visibility.Collapsed;
            dataGridSchedules.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void updateView(object sender, EventArgs e)
        {
            selectCmd = "SELECT * FROM Schedule";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "info");


            if (AppSettings.currentTourId == -1)
            {
                sheduleLbl.Content = "Все заезды";
                if (!(bool)showCb.IsChecked)
                {
                    selectCmd = "SELECT Route.ID AS [Код], Route.name AS [Маршрут], Schedule.duration AS [Продолжительность],  Format(Schedule.begin_date, 'dd/mm/yy') AS [Отправление],  Format(Schedule.end_date, 'dd/mm/yy') AS [Прибытие], Schedule.ID AS [S_id] from Schedule, Route where Route.ID = Schedule.route_id and Schedule.begin_date>=Date() order by Schedule.begin_date asc";
                }
                else selectCmd = "SELECT Route.ID AS [Код], Route.name AS [Маршрут], Schedule.duration AS [Продолжительность],  Format(Schedule.begin_date, 'dd/mm/yy') AS [Отправление],  Format(Schedule.end_date, 'dd/mm/yy') AS [Прибытие], Schedule.ID AS [S_id]  from Schedule, Route where Route.ID = Schedule.route_id order by Schedule.begin_date asc";
            }
            else
            {
                sheduleLbl.Content = "Заезды тура \"" + AppSettings.currentTourName + "\"";
                if (!(bool)showCb.IsChecked)
                {
                    selectCmd = "SELECT Route.ID AS [Код], Route.name AS [Маршрут], Schedule.duration AS [Продолжительность],  Format(Schedule.begin_date, 'dd/mm/yy') AS [Отправление],  Format(Schedule.end_date, 'dd/mm/yy') AS [Прибытие], Schedule.ID AS [S_id] from Schedule, Route where Route.ID = Schedule.route_id and Schedule.begin_date>=Date() and route_id = " + AppSettings.currentTourId + " order by Schedule.begin_date asc";
                }
                else selectCmd = "SELECT Route.ID AS [Код], Route.name AS [Маршрут], Schedule.duration AS [Продолжительность],  Format(Schedule.begin_date, 'dd/mm/yy') AS [Отправление],  Format(Schedule.end_date, 'dd/mm/yy') AS [Прибытие], Schedule.ID AS [S_id] from Schedule, Route where Route.ID = Schedule.route_id and route_id =" + AppSettings.currentTourId + " order by Schedule.begin_date asc";
            }
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "schedules");

            dataGridSchedules.DataContext = ds;
        }

        private void showCb_Checked(object sender, RoutedEventArgs e)
        {
            updateView(null, null);
        }

        private void showCb_Unchecked(object sender, RoutedEventArgs e)
        {
            updateView(null, null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView row in dataGridSchedules.SelectedItems)
            {
                AppSettings.currentScheduleId = Convert.ToInt32(row.Row.ItemArray[5]);
                CurrentOrder.days = Convert.ToInt32(row.Row.ItemArray[2]);
                CurrentOrder.b_date = row.Row.ItemArray[3].ToString();
                CurrentOrder.e_date = row.Row.ItemArray[4].ToString();
            }

            string selectCmd = "SELECT Hotel.name as hotel, Country.country as country, City.City as city  from Hotel, Place, City, Country where Country.ID= City.country_id and Hotel.city_id = City.ID and Place.hotel_id = Hotel.ID and Place.route_id = " + AppSettings.currentTourId;

            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "hotels");

            CurrentOrder.hotels.Clear();
            CurrentOrder.cities.Clear();

            for (int i = 0; i < ds.Tables["hotels"].Rows.Count; i++)
            {
                CurrentOrder.hotels.Add(ds.Tables["hotels"].Rows[i][0].ToString());
                CurrentOrder.cities.Add(ds.Tables["hotels"].Rows[i][1].ToString() + ", " + ds.Tables["hotels"].Rows[i][2].ToString());
            }
            
            Order page = new Order();
            this.NavigationService.Navigate(page);

        }
        public void checkUserRights()
        {
            if (!AppSettings.isAdmin)
            {                
                deleteBtn.Visibility = Visibility.Hidden;
                updateBtn.Visibility = Visibility.Hidden;
                dataGridSchedules.IsReadOnly = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string e_d = edTb.Text;
            string b_d = bdTb.Text;
            string selectCmd1 = "SELECT Route.ID AS [Код ], Route.name AS [Маршрут], Schedule.duration AS [Продолжительность], Format(Schedule.begin_date, 'mm/dd/yy') AS [Отправление],  Format(Schedule.end_date, 'mm/dd/yy') AS [Прибытие], Schedule.ID AS [S_id] from Schedule, Route where Route.ID = Schedule.route_id and Schedule.begin_date>=Date() and Format(Schedule.begin_date, 'mm/dd/yy') >='" + b_d + "' and Format(Schedule.end_date, 'mm/dd/yy') <='" + e_d + "';";

            da = new OleDbDataAdapter(selectCmd1, connString);
            ds = new DataSet();
            da.Fill(ds, "schedules");
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            dataArray = DataGridUtil.DataGridToArray(dataGridSchedules);
            try
            {
                string b_date, e_date;

                b_date = dataArray[dataArray.GetLength(0) - 2, 3];
                e_date = dataArray[dataArray.GetLength(0) - 2, 4];

                DateTime dt1 = new DateTime();
                DateTime.TryParse(b_date, out dt1);

                DateTime dt2 = new DateTime();
                DateTime.TryParse(e_date, out dt2);

                TimeSpan time = dt2 - dt1;
                int dur = time.Days;

                if (!(AppUtil.isDate(b_date) && AppUtil.isDate(e_date))) throw new Exception();

                string selectCmd1 = "INSERT INTO Schedule values( " + getNewSchId() + ", '" + b_date + "', '" + e_date + "', " + AppSettings.currentTourId + ",	" + dur + ")";
                da = new OleDbDataAdapter(selectCmd1, connString);
                ds = new DataSet();
                da.Fill(ds, "info");

                CurrentOrder.b_date = b_date;
                CurrentOrder.e_date = e_date;


            }
            catch
            {
                MessageBox.Show("Неправильный формат даты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
                updateView(null, null);
        }

        public int getNewSchId()
        {
            dataArray = DataGridUtil.DataGridToArray(dataGridSchedules);
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Schedule";

            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "schedulesID");

            return Convert.ToInt32(ds.Tables["schedulesID"].Rows[0]["ID"]) + 1;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult хочуУдалить;
            хочуУдалить = MessageBox.Show("Вы действительно хотите удалить выделенную запись?",
                "Удаление информации о товаре", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (хочуУдалить.ToString() == "Yes")
            {
                dataArray = DataGridUtil.DataGridToArray(dataGridSchedules);
                int id = dataGridSchedules.SelectedIndex;
                selectCmd = "Delete FROM Schedule where id = " + dataArray[id, 5];
                da = new OleDbDataAdapter(selectCmd, connString);
                ds = new DataSet();
                da.Fill(ds, "schedules");
                updateView(null, null);
            }

        }

        private void dataGridSchedules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
