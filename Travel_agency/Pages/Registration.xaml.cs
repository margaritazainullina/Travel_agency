using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace Travel_agency.Pages
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        int id;
        string name;
        string login;
        string password;
        string position;

        string connString = myPublic.connString;
        DataSet empDs;             //Набор данных
        OleDbDataAdapter empDa;    //Адаптер данных

        DataSet empDs1;             //Набор данных
        OleDbDataAdapter empDa1;    //Адаптер данных
        OleDbCommandBuilder cb;

        public Registration()
        {
            InitializeComponent();
            cb = new OleDbCommandBuilder(empDa1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //получаем id нового сотрудника
                id = getNewEmpId();
                name = nameTb.Text;
                login = loginTb.Text;
                password = passwordTb.Text;
                if (positionCb.SelectedIndex == 0) position = "manager";
                else position = "admin";

                string hash;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = Md5.GetMd5Hash(md5Hash, password);
                }

                string selectCmd = "SELECT * From Employee";

                empDa1 = new OleDbDataAdapter(selectCmd, connString);
                empDs1 = new DataSet();
                empDa1.Fill(empDs1, "employees");

                string selectCmd1 = "INSERT INTO Employee values(" + id + ",'" + name + "','" + position + "','" + login + "','" + hash + "')";

                empDa1 = new OleDbDataAdapter(selectCmd1, connString);
                empDs1 = new DataSet();
                empDa1.Fill(empDs1, "employees");

                nameTb.Text = "";
                loginTb.Text = "";
                passwordTb.Text = "";
                MessageBox.Show("Регистрация прошла успешно", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось зарегистрировать нового пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public int getNewEmpId()
        {
            string connString = myPublic.connString;
            string selectCmd = "SELECT max(ID) as ID From Employee";

            empDa = new OleDbDataAdapter(selectCmd, connString);
            empDs = new DataSet();
            empDa.Fill(empDs, "employeesID");

            return Convert.ToInt32(empDs.Tables["employeesID"].Rows[0]["ID"]) + 1;
        }
    }
}