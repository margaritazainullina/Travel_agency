using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Voucher.xaml
    /// </summary>
    public partial class Voucher : Page
    {
        
        DataSet voucherDs;             //Набор данных
        OleDbDataAdapter voucherDa;    //Адаптер данных

        DataSet cityDs;             //Набор данных
        OleDbDataAdapter cityDa;    //Адаптер данных

        DataSet ds2;             //Набор данных
        OleDbDataAdapter da2;    //Адаптер данных
        string connString = myPublic.connString;
        string selCountry;
        string selCity;
        int selIdx = -1;

        public Voucher()
        {
            InitializeComponent();
            checkUserRights();            
            cityCmb.Visibility = Visibility.Collapsed;
            cityLbl.Visibility = Visibility.Collapsed;

            string selectCmd1 = "SELECT country FROM Country";
            da2 = new OleDbDataAdapter(selectCmd1, connString);
            ds2 = new DataSet();
            da2.Fill(ds2, "countries");

            DataRow row = ds2.Tables["countries"].NewRow();
            row["country"] = "Все страны";
           
            ds2.Tables[0].Rows.Add(row);
            countryCmb.DataContext = ds2;
            countryCmb.DisplayMemberPath = "country";

        }

        private void OnInit(object sender, EventArgs e)
        {
            string selectCmd = "SELECT Route.ID AS [Код маршрута], Route.name AS [Маршрут], Meal_type.full_name AS [Питание], Transport.transport AS [Транспорт], Route.price AS [Стоимость] FROM Route, Meal_type,Transport where Route.meal_type_id= Meal_type.ID and Transport.ID=route.transport_id;";
            voucherDa = new OleDbDataAdapter(selectCmd, connString);
            voucherDs = new DataSet();
            voucherDa.Fill(voucherDs, "routes");            
            dataGridRoutes.DataContext = voucherDs;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView row in dataGridRoutes.SelectedItems)
            {
                AppSettings.currentTourId = Convert.ToInt32(row.Row.ItemArray[0]);
                AppSettings.currentTourName = row.Row.ItemArray[1].ToString();
            }
            try
            {
                CurrentOrder.mealtype = voucherDs.Tables["routes"].Rows[dataGridRoutes.SelectedIndex]["Питание"].ToString();
                CurrentOrder.transport = voucherDs.Tables["routes"].Rows[dataGridRoutes.SelectedIndex]["Транспорт"].ToString();
                CurrentOrder.price = Convert.ToInt32(voucherDs.Tables["routes"].Rows[dataGridRoutes.SelectedIndex]["Стоимость"]);
                Schedule page = new Schedule();
                this.NavigationService.Navigate(page);
            }
            catch { }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView row in dataGridRoutes.SelectedItems)
            {
                AppSettings.currentTourId = Convert.ToInt32(row.Row.ItemArray[0]);
                AppSettings.currentTourName = row.Row.ItemArray[1].ToString();
            }
            Voucher_details page = new Voucher_details();
            page.Show();
        }

        public void checkUserRights()
        {
            dataGridRoutes.IsReadOnly = true;
            if (!AppSettings.isAdmin)
            {
                addBtn.Visibility = Visibility.Hidden;
                delBtn.Visibility = Visibility.Hidden;
            }
        }

        private void updateBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string t_name = tour_nTB.Text;
                string selectCmd = "SELECT Route.ID AS [Код маршрута], Route.name AS [Маршрут], Meal_type.full_name AS [Питание], Transport.transport AS [Транспорт], Route.price AS [Стоимость] FROM Route, Meal_type,Transport where Route.meal_type_id= Meal_type.ID and Transport.ID=route.transport_id and Route.name = '"+t_name+"'";
                voucherDa = new OleDbDataAdapter(selectCmd, connString);
                voucherDs = new DataSet();
                voucherDa.Fill(voucherDs, "routes");
                dataGridRoutes.DataContext = voucherDs;
            }
            catch (Exception ex) { MessageBox.Show("По запросу ничего не найдено", "Поиск", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
        }

        private void countryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            if (countryCmb.SelectedIndex != -1)
            {
                cityCmb.Visibility = Visibility.Visible;
                cityLbl.Visibility = Visibility.Visible;

                selIdx = countryCmb.SelectedIndex;
                selCountry = ds2.Tables["countries"].Rows[countryCmb.SelectedIndex]["country"].ToString();
                
                if (selCountry != "Все страны")
                {

                    string selectCmd1 = "SELECT City.city FROM City, Country WHERE Country.ID=City.country_id and Country.country = '" + selCountry + "'";
                    cityDa = new OleDbDataAdapter(selectCmd1, connString);
                    cityDs = new DataSet();
                    cityDa.Fill(cityDs, "cities");
                    cityCmb.DataContext = cityDs;
                    cityCmb.DisplayMemberPath = "city";
                    DataRow row = cityDs.Tables["cities"].NewRow();
                    row["city"] = "Все города";
                    cityCmb.DataContext = cityDs;
                    cityDs.Tables[0].Rows.Add(row);
                    cityCmb.DisplayMemberPath = "city";
                    
                    string selectCmd = "SELECT distinct Route.ID AS [Код маршрута], Route.name AS [Маршрут], Meal_type.full_name AS [Питание], Transport.transport AS [Транспорт], Route.price AS [Стоимость] FROM Route, Meal_type,Transport, Country, City ,Place, Hotel where Route.meal_type_id= Meal_type.ID and Transport.ID=route.transport_id and Route.ID=Place.route_id and Place.hotel_id = Hotel.ID and Country.ID = City.country_id and City.ID=Hotel.city_id  and Country.country =  '" + selCountry + "'";
                    voucherDa = new OleDbDataAdapter(selectCmd, connString);
                    voucherDs = new DataSet();
                    voucherDa.Fill(voucherDs, "routes");
                    dataGridRoutes.DataContext = voucherDs;                     
                }
                else
                {
                    try
                    {
                        cityCmb.Visibility = Visibility.Collapsed;
                        cityLbl.Visibility = Visibility.Collapsed;

                        string selectCmd = "SELECT distinct Route.ID AS [Код маршрута], Route.name AS [Маршрут], Meal_type.full_name AS [Питание], Transport.transport AS [Транспорт], Route.price AS [Стоимость] FROM Route, Meal_type,Transport, Country, City ,Place, Hotel where Route.meal_type_id= Meal_type.ID and Transport.ID=route.transport_id and Route.ID=Place.route_id and Place.hotel_id = Hotel.ID and Country.ID = City.country_id and City.ID=Hotel.city_id ";
                        voucherDa = new OleDbDataAdapter(selectCmd, connString);
                        voucherDs = new DataSet();
                        voucherDa.Fill(voucherDs, "routes");
                        dataGridRoutes.DataContext = voucherDs;
                    }
                    catch{}
                }
            }

        }

        private void hideCol(object sender, EventArgs e)
        {
            dataGridRoutes.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void cityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            try
            {
                selCity = cityDs.Tables["cities"].Rows[cityCmb.SelectedIndex]["city"].ToString();
                if (selCity != "Все города")
                {                  
                    string selectCmd = "SELECT Route.ID AS [Код маршрута], Route.name AS [Маршрут], Meal_type.full_name AS [Питание], Transport.transport AS [Транспорт], Route.price AS [Стоимость] FROM Route, Meal_type,Transport, City ,Place, Hotel where Route.meal_type_id= Meal_type.ID and Transport.ID=route.transport_id and Route.ID=Place.route_id and Place.hotel_id = Hotel.ID and City.ID=Hotel.city_id  and City.city =  '" + selCity + "'";
                    voucherDa = new OleDbDataAdapter(selectCmd, connString);
                    voucherDs = new DataSet();
                    voucherDa.Fill(voucherDs, "routes");
                    dataGridRoutes.DataContext = voucherDs;
                }
                else
                { 
                    selCity = "";
                    string selectCmd = "SELECT distinct Route.ID AS [Код маршрута], Route.name AS [Маршрут], Meal_type.full_name AS [Питание], Transport.transport AS [Транспорт], Route.price AS [Стоимость] FROM Route, Meal_type,Transport, Country, City ,Place, Hotel where Route.meal_type_id= Meal_type.ID and Transport.ID=route.transport_id and Route.ID=Place.route_id and Place.hotel_id = Hotel.ID and Country.ID = City.country_id and City.ID=Hotel.city_id  and Country.country =  '" + selCountry + "'"; 
                    voucherDa = new OleDbDataAdapter(selectCmd, connString);
                    voucherDs = new DataSet();
                    voucherDa.Fill(voucherDs, "routes");
                    dataGridRoutes.DataContext = voucherDs;
                }
            }
            catch{ }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            addNewRoute page = new addNewRoute();
            page.Show();
            OnInit(null, null);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            string[,] dataArray = DataGridUtil.DataGridToArray(dataGridRoutes);
            MessageBoxResult хочуУдалить;
            хочуУдалить = MessageBox.Show("Вы действительно хотите удалить выделенную запись?",
                "Удаление информации", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (хочуУдалить.ToString() == "Yes")
            {
                
                dataArray = DataGridUtil.ReadOnlyDataGridToArray(dataGridRoutes);
                int id = dataGridRoutes.SelectedIndex;
                string deleteCmd = "Delete FROM Route where ID = " + dataArray[id, 0];
                voucherDa = new OleDbDataAdapter(deleteCmd, connString);
                voucherDs = new DataSet();
                voucherDa.Fill(voucherDs, "routes");

                //каскадное удаление
                string deleteCmd2 = "Delete FROM Schedule where route_id = " + dataArray[id, 0];
                voucherDa = new OleDbDataAdapter(deleteCmd2, connString);
                voucherDs = new DataSet();
                voucherDa.Fill(voucherDs, "routes");
                OnInit(null, null);
            }
        }
    }
}