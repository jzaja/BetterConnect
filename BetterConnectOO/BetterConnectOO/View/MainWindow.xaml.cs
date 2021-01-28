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
using BetterConnectOO.Models.Singleton;
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

            if (logedUser != null)
            {
                CurrentUser.Instance.user = logedUser;
                GeneralWindow generalWindow = new GeneralWindow();

                generalWindow.Show();
                Login.Close();
            } else
            {
                MessageBox.Show("Invalid credentials!");
            }
        }

        private async void OnFillDatabase(object sender, RoutedEventArgs e)
        {
            User user1 = await APIManager.RegisterNewUser("misko", "pass", "0919292933");
            User user2 = await APIManager.RegisterNewUser("lordWilly35", "pass", "099564372");
            User user3 = await APIManager.RegisterNewUser("DBDFan", "pass", "0955148986");
            User user4 = await APIManager.RegisterNewUser("erenjeger", "pass", "098345672");
            User user5 = await APIManager.RegisterNewUser("ervin123", "pass", "098765432");
            User user6 = await APIManager.RegisterNewUser("TheKing97", "pass", "098352872");
            User user7 = await APIManager.RegisterNewUser("OverwatchFan", "pass", "0914638397");

            await APIManager.AddInterest("čitanje", user1.id);
            await APIManager.AddInterest("igrice", user1.id);
            await APIManager.AddInterest("slatkiši", user1.id);

            await APIManager.AddInterest("politika", user2.id);

            await APIManager.AddInterest("Dead by Deadlight", user3.id);
            await APIManager.AddInterest("igrice", user3.id);

            await APIManager.AddInterest("manga", user4.id);
            await APIManager.AddInterest("anime", user4.id);
            await APIManager.AddInterest("AOT", user4.id);

            await APIManager.AddInterest("anime", user5.id);
            await APIManager.AddInterest("AOT", user5.id);

            await APIManager.AddInterest("igrice", user6.id);
            await APIManager.AddInterest("politika", user6.id);
            await APIManager.AddInterest("manga", user6.id);

            await APIManager.AddInterest("Overwatch", user7.id);
            await APIManager.AddInterest("igrice", user7.id);

            await APIManager.SendRequest(user1.id, user3.id);
            await APIManager.SendRequest(user1.id, user6.id);
            await APIManager.SendRequest(user1.id, user7.id);

            await APIManager.SendRequest(user2.id, user6.id);

            await APIManager.SendRequest(user3.id, user7.id);

            await APIManager.SendRequest(user4.id, user5.id);
            await APIManager.SendRequest(user4.id, user1.id);

            await APIManager.SendRequest(user7.id, user6.id);

            await APIManager.SendRequest(user6.id, user5.id);
            await APIManager.SendRequest(user6.id, user4.id);

            MessageBox.Show("Baza napunjena.");
        }
    }
}
