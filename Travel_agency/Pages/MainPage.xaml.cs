using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Travel_agency
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EnterBtn.Content.ToString() == "Вход")
            {
                try
                {
                    string connString = myPublic.connString;
                    string selectCmd = "SELECT name FROM Employee WHERE (((login)='" + Login.Text + "') AND ((password)='" + Pasw.Text + "'))";
                    da = new OleDbDataAdapter(selectCmd, connString);
                    ds = new DataSet();
                    da.Fill(ds, "Employee");
                    lbl2.Visibility = Visibility.Collapsed;
                    Pasw.Visibility = Visibility.Collapsed;
                    Login.Visibility = Visibility.Collapsed;

                    EnterBtn.Content = "Выход";
                    Lb1.DataContext = ds;
                    connString = myPublic.connString;
                    DataRowView das = (DataRowView)Lb1.Items[0];
                }
                catch
                {
                    lbl2.Visibility = Visibility.Visible;
                    Pasw.Visibility = Visibility.Visible;
                    Pasw.Text = "";
                    Login.Text = "";
                    Login.Visibility = Visibility.Visible;
                    EnterBtn.Content = "Вход";
                    MessageBox.Show("Не удалось авторизироваться!");
                }
            }
            else
            {
                DataRowView das = (DataRowView)Lb1.Items[0];
                lbl1.Content = "Вы успешно авторизовались";
                lbl2.Visibility = Visibility.Visible;
                Pasw.Visibility = Visibility.Visible;
                Pasw.Text = "";
                Login.Text = "";
                Login.Visibility = Visibility.Visible;
                EnterBtn.Content = "Вход";
                string connString = myPublic.connString;
                
            }
             
               
        }
    }
}
