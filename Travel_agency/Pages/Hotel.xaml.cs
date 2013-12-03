using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Voucher_details.xaml
    /// </summary>
    public partial class Hotel : Page
    {
        DataSet hotelDs;             //Набор данных
        OleDbDataAdapter hotelDa;    //Адаптер данных

        DataSet cityDs;             //Набор данных
        OleDbDataAdapter cityDa;    //Адаптер данных

        DataSet ds2;             //Набор данных
        OleDbDataAdapter da2;    //Адаптер данных
        string connString = myPublic.connString;
        string selCountry;
        string selCity;
        string hotelName;

        public Hotel()
        {
            InitializeComponent();

            cityCmb.Visibility = Visibility.Collapsed;
            cityLbl.Visibility = Visibility.Collapsed;

            updateHotelInfo();

            string selectCmd1 = "SELECT country FROM Country";
            da2 = new OleDbDataAdapter(selectCmd1, connString);
            ds2 = new DataSet();
            da2.Fill(ds2, "countries");
            
            DataRow row = ds2.Tables[0].NewRow();
            row["country"] = "Все страны";
            countryCmb.DataContext = ds2;
            countryCmb.DisplayMemberPath = "country";
            ds2.Tables[0].Rows.Add(row);

        }

        private void hideCol(object sender, EventArgs e)
        {
           dataGridHotels.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void updateHotelInfo()
        {
            string selectCmd;

            try
            {
                if (selCountry != "" && selCountry != null)
                {
                    if (selCity != "" && selCity != null) selectCmd = "SELECT Hotel.ID AS [Код отеля], Country.country AS [Страна], City.city AS [Город], Hotel.name AS [Отель], Hotel.category AS [Категория] from Hotel, Country, City where Country.ID = City.country_id and Hotel.city_id = City.ID and City.city='" + selCity + "'";
                    else selectCmd = "SELECT Hotel.ID AS [Код отеля], Country.country AS [Страна], City.city AS [Город], Hotel.name AS [Отель], Hotel.category AS [Категория] from Hotel, Country, City where Country.ID = City.country_id and Hotel.city_id = City.ID and Country.id=City.country_id and Country.country='" + selCountry + "'";
                }
                else selectCmd = "SELECT Hotel.ID AS [Код отеля], Country.country AS [Страна], City.city AS [Город], Hotel.name AS [Отель], Hotel.category AS [Категория] from Hotel, Country, City where Country.ID = City.country_id and Hotel.city_id = City.ID";

                if (hotelName != "" && hotelName != null) selectCmd += " and Hotel.name = '" + hotelName + "'";
                hotelDa = new OleDbDataAdapter(selectCmd, connString);
                hotelDs = new DataSet();
                hotelDa.Fill(hotelDs, "hotels");
                dataGridHotels.DataContext = hotelDs;

            }
            catch (Exception ex) { }
        }

        private void dataGridHotels_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                foreach (DataRowView row in dataGridHotels.SelectedItems)
                {
                    AppSettings.currentHotelId = Convert.ToInt32(row.Row.ItemArray[0]);
                    AppSettings.currentHotelName = row.Row.ItemArray[3].ToString();
                }
                hotelLbl.Content = "Информация про отель \""+AppSettings.currentHotelName+"\"";
                setSeason(null, null);
            }
            catch (Exception ex) { };
        }


        private void setSeason(object sender, RoutedEventArgs e)
        {
            string selectCmdRoom;
            if ((bool)lowRb.IsChecked)
            {
                selectCmdRoom = "SELECT distinct Room_category.r_cat AS [Категория номера], Hotel_fee.fee AS [Стоимость] FROM Hotel_fee, Room_category WHERE Hotel_fee.category_id = Room_category.ID and Hotel_fee.season_id=2 and Hotel_fee.hotel_id = " + AppSettings.currentHotelId + " order by Hotel_fee.fee asc";
            }
            else
            {
                selectCmdRoom = "SELECT distinct Room_category.r_cat AS [Категория номера],  Hotel_fee.fee AS [Стоимость] FROM Hotel_fee, Room_category WHERE Hotel_fee.category_id = Room_category.ID and Hotel_fee.season_id=1 and Hotel_fee.hotel_id = " + AppSettings.currentHotelId + " order by Hotel_fee.fee asc";
            }

            hotelDa = new OleDbDataAdapter(selectCmdRoom, connString);
            hotelDs = new DataSet();
            hotelDa.Fill(hotelDs, "hotelDetails");
            dataGridHotelDetails.DataContext = hotelDs;
        }
        
        private void countryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cityCmb.Visibility = Visibility.Visible;
            cityLbl.Visibility = Visibility.Visible;

            selCountry = ds2.Tables["countries"].Rows[countryCmb.SelectedIndex]["country"].ToString();

            string selectCmd1="";

            if (selCountry != "Все страны") selectCmd1 = "SELECT city FROM City, Country WHERE Country.ID=City.country_id and Country.country = '" + selCountry + "'";
            
            else  selectCmd1 = "SELECT city FROM City, Country WHERE Country.ID=City.country_id";
            cityDa = new OleDbDataAdapter(selectCmd1, connString);
            cityDs = new DataSet();
            cityDa.Fill(cityDs, "cities");

            DataRow row = cityDs.Tables["cities"].NewRow();
            row["city"] = "Все города";
            cityCmb.DataContext = cityDs;
            cityDs.Tables[0].Rows.Add(row);
            cityCmb.DisplayMemberPath = "city";
            selCity = "";
            hotelName = "";

            if (selCountry == "Все страны")
            {
                selCountry = "";
                cityCmb.Visibility = Visibility.Collapsed;
                cityLbl.Visibility = Visibility.Collapsed;
            }
            else {
                cityCmb.SelectedIndex = cityDs.Tables["cities"].Rows.Count-1;
            }
            //обновить данные об отелях
            updateHotelInfo();
        }

        private void cityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selCity = cityDs.Tables["cities"].Rows[cityCmb.SelectedIndex]["city"].ToString();
                if (selCity == "Все города") selCity = "";
                hotelName = "";
                updateHotelInfo();
            }
            catch (Exception ex) { }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        { }

        private void updateBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hotelName = tour_nTB.Text;
                updateHotelInfo();
            }
            catch (Exception ex) 
            {                
                hotelName = "";
                updateHotelInfo();
                MessageBox.Show("По запросу ничего не найдено", "Поиск", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    }
}