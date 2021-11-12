using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HMID
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void login_click(object sender, MouseButtonEventArgs e)
        {
            if(login.Text == "Username")
                login.Text = "";
        }

        private void password_click(object sender, MouseButtonEventArgs e)
        {
            if(password.Password == "Password")
                password.Password = "";
        }

        private void btn_login_click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "") 
                MessageBox.Show("введите данные");
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void btn_registration_click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
