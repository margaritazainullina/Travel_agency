using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for addNewRoute.xaml
    /// </summary>
    public partial class addNewRoute : Window
    {
        DataSet voucherDs;             //Набор данных
        OleDbDataAdapter voucherDa;    //Адаптер данных

        DataSet routeDs;             //Набор данных
        OleDbDataAdapter routeDa;    //Адаптер данных

        string connString = myPublic.connString;
        string name;
        double price;
        int id, tr_id, meal_id;

        public addNewRoute()
        {
            InitializeComponent();
        }
        private void OnInit(object sender, EventArgs e)
        {
            string selectCmd = "SELECT Country.country AS [Страна], City.City AS [Город], Hotel.ID  AS [h_id], Room_category.ID AS [r_id], Hotel.name  AS [Отель], Hotel.category  AS [Категория отеля], Room_category.r_cat  AS [Категория комнаты], Hotel_fee.fee  AS [Стоимость] FROM Room_category INNER JOIN (((Country INNER JOIN City ON Country.[ID] = City.[country_id]) INNER JOIN Hotel ON City.[ID] = Hotel.[city_id]) INNER JOIN Hotel_fee ON Hotel.[ID] = Hotel_fee.[hotel_id]) ON Room_category.[ID] = Hotel_fee.[category_id]; ";
            voucherDa = new OleDbDataAdapter(selectCmd, connString);
            voucherDs = new DataSet();
            voucherDa.Fill(voucherDs, "place");
            placeDataGrid.DataContext = voucherDs;
        }

        private void hideCol(object sender, EventArgs e)
        {
            placeDataGrid.Columns[2].Visibility = Visibility.Collapsed;
            placeDataGrid.Columns[3].Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            try
            {
                name = nameTb.Text;
                price = Convert.ToDouble(priceTb.Text);
                tr_id = transpCB.SelectedIndex + 1;
                meal_id = mealCB.SelectedIndex + 1;
                id = getNewRouteId();

                //добавление в таблицу route
                string insertCmd = "INSERT INTO Route values( " + id + ", '" + name + "'," + price + ", " + meal_id + ", " + tr_id + ")";
                voucherDa = new OleDbDataAdapter(insertCmd, connString);
                voucherDs = new DataSet();
                voucherDa.Fill(voucherDs, "info");


                //добавление в таблицу place
                foreach (DataRowView row in placeDataGrid.SelectedItems)
                {
                    string insertCmd1 = "INSERT INTO Place values( " + row["h_id"] + ", " + id + ", " + row["r_id"] + " )";
                    routeDa = new OleDbDataAdapter(insertCmd1, connString);
                    routeDs = new DataSet();
                    routeDa.Fill(routeDs, "placesIns");
                }
                MessageBox.Show("Новая путевка успешно добавлена", "ОК", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        public int getNewRouteId()
        {
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Route";

            voucherDa = new OleDbDataAdapter(selectCmd, connString);
            voucherDs = new DataSet();
            voucherDa.Fill(voucherDs, "routesID");

            return Convert.ToInt32(voucherDs.Tables["routesID"].Rows[0]["ID"]) + 1;
        }

        public int getNewPlaceId()
        {
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Place";

            voucherDa = new OleDbDataAdapter(selectCmd, connString);
            voucherDs = new DataSet();
            voucherDa.Fill(voucherDs, "placesID");

            return Convert.ToInt32(voucherDs.Tables["placesID"].Rows[0]["ID"]) + 1;
        }
    }
}
