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
using BetterConnectOO.API;
using BetterConnectOO.Models;

namespace BetterConnectOO
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void LoginScreenButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Registration.Close();
        }

        private async void Registration_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string repeatedPassword = RepeatPasswordTextBox.Password;
            string phoneNumber = PhoneNumberTextBox.Text;

            if (password.Equals(repeatedPassword))
            {
                User user = await APIManager.RegisterNewUser(username, password, phoneNumber);
                
                if (user == null)
                {
                    MessageBox.Show("Missing credentials or user with that credentials already exists!");
                } else
                {
                    GeneralWindow window = new GeneralWindow();
                    window.Show();
                    Registration.Close();
                }
            } else
            {
                MessageBox.Show("Passwords not matching!");
            }
        }
    }
}
