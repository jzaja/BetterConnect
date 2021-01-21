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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BetterConnectOO.API;
using BetterConnectOO.Models;
using BetterConnectOO.ViewModels;

namespace BetterConnectOO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NoAccountButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Login.Close();
        }

        private async void LoginButton(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            User logedUser = await APIManager.LoginUser(username, password);

            //if (logedUser != null)
            //{
                GeneralWindow generalWindow = new GeneralWindow();

                generalWindow.Show();
                Login.Close();
            //} else
            //{
               // MessageBox.Show("Invalid credentials!");
            //}
        }

    }
}
