using System.Data;
using System.Data.OleDb;
using System.Windows;
namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Voucher_details.xaml
    /// </summary>
    public partial class Voucher_details : Window
    {
        //Общие объекты
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;    //Адаптер данных

        public Voucher_details()
        {
            InitializeComponent();
            string connString = myPublic.connString;
            string selectCmd = "SELECT City.city AS [Город], Hotel.name AS [Отель], Hotel.category AS [Категория отеля], Room_category.r_cat AS [Номер] FROM City, Hotel, Room_category, Place, Route WHERE City.ID=Hotel.city_id and Place.hotel_id = Hotel.id and Place.room_category = room_category.ID and Route.ID =Place.route_id and  Route.ID= " + AppSettings.currentTourId;
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "details");
            dataGridDetails.DataContext = ds;
            lbl.Content = "Информация о туре \""+AppSettings.currentTourName+"\"";
        }
    }
}
