using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using Travel_agency.Pages;

namespace Travel_agency
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        DataSet ds;             //Набор данных
        OleDbDataAdapter da;
        string connString = myPublic.connString;
       

        public void HideButtons()
        {
            Routes_btn.Visibility = Visibility.Collapsed;
            Reports_btn.Visibility = Visibility.Collapsed;
            Employees_btn.Visibility = Visibility.Collapsed;
            Hotels_btn.Visibility = Visibility.Collapsed;
            Statistics_btn.Visibility = Visibility.Collapsed;
        }
        public void ShowButtons()
        {
            Routes_btn.Visibility = Visibility.Visible;
            Hotels_btn.Visibility = Visibility.Visible;
            if (AppSettings.isAdmin)
            {
                Reports_btn.Visibility = Visibility.Visible;
                Employees_btn.Visibility = Visibility.Visible;
                Statistics_btn.Visibility = Visibility.Visible;
            }
        }
        public void Authorise(string login, string password)
        {
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = Md5.GetMd5Hash(md5Hash, password);
            }

            string selectCmd = "SELECT * FROM Employee WHERE (((login)='" + login + "') AND ((password)='" + hash + "'))";
            da = new OleDbDataAdapter(selectCmd, connString);
            ds = new DataSet();
            da.Fill(ds, "Employee");
            Passw.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Collapsed;
            EnterBtn.Content = "Выход";
            Lb1.DataContext = ds;
            connString = myPublic.connString;
            DataRowView das = (DataRowView)Lb1.Items[0];
            AppSettings.userId = Convert.ToInt32(das.Row.ItemArray[0]);
            AppSettings.userName = das.Row.ItemArray[1].ToString();
            lbl1.Content = "Оператор: " + AppSettings.userName + ".";
            AppSettings.isAuthorised = true;
            if (das.Row.ItemArray[2].ToString() == "admin")
            {
                AppSettings.isAdmin = true;
                lbl2.Content = "Тип учетной записи: администратор.";
            }
            else
            {
                AppSettings.isAdmin = false;
                lbl2.Content = "Тип учетной записи: менеждер.";
            }
        }

        public void AuthorisationError()
        {
            lbl2.Visibility = Visibility.Visible;
            Passw.Visibility = Visibility.Visible;
            Passw.Password = "";
            Login.Visibility = Visibility.Visible;
            EnterBtn.Content = "Вход";
            AppSettings.isAuthorised = false;
            MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void Exit()
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {

                AppSettings.isAuthorised = false;
                AppSettings.isAdmin = false;
                AppSettings.userName = "";
                lbl2.Visibility = Visibility.Visible;
                Passw.Visibility = Visibility.Visible;
                Passw.Password = "";
                Login.Text = "";
                lbl1.Content = "Логин";
                lbl2.Content = "Пароль";
                Login.Visibility = Visibility.Visible;
                EnterBtn.Content = "Вход";
                string connString = myPublic.connString;
                HideButtons();
            }
        }


        public MainPage()
        {
            InitializeComponent();
            HideButtons();
            ShowButtons();
            if (AppSettings.isAuthorised)
            {
                Passw.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Collapsed;
                EnterBtn.Content = "Выход";
                
                lbl1.Content = "Оператор: " + AppSettings.userName + ".";
                if (AppSettings.isAdmin)
                {
                    lbl2.Content = "Тип учетной записи: администратор.";
                }
                else
                {
                    lbl2.Content = "Тип учетной записи: менеждер.";
                }
            }
            else
            {
                HideButtons();
            }
            

        }


        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EnterBtn.Content.ToString() == "Вход")
            {
                try
                {
                    Authorise(Login.Text, Passw.Password);
                    ShowButtons();
                }
                catch
                {
                    AuthorisationError();
                }
            }
            else
            {
                Exit();
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Voucher page = new Voucher();
            this.NavigationService.Navigate(page);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppSettings.currentTourId = -1;
            AppSettings.currentTourName = "";
            Schedule page = new Schedule();
            this.NavigationService.Navigate(page);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Report page = new Report();
            this.NavigationService.Navigate(page);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Registration page = new Registration();
            page.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Hotel page = new Hotel();
            this.NavigationService.Navigate(page);
        }

        private void Charts_btn_Click(object sender, RoutedEventArgs e)
        {
            Statistics page = new Statistics();
            this.NavigationService.Navigate(page);
        }

    }
}