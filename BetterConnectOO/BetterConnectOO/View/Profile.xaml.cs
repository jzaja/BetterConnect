using BetterConnectOO.Models;
using BetterConnectOO.Models.Singleton;
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

namespace BetterConnectOO.View
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window, AddInterestWindowDelegate
    {
        public Profile()
        {
            InitializeComponent();

            UsernameTextBlock.Text = "Username: " + CurrentUser.Instance.Username;
            PhoneNumberTextBlock.Text = "Phone number: " + CurrentUser.Instance.PhoneNumber;
            InterestsTextBlock.Text = "Vlastiti interesi: " + Environment.NewLine + CurrentUser.Instance.AllInterestsString;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            GeneralWindow generalWindow = new GeneralWindow();
            generalWindow.Show();
            ProfileWindow.Close();

        }

        private void OnEditButton(object sender, RoutedEventArgs e)
        {
            EditProfile window = new EditProfile();
            window._delegate = this;
            window.Show();
        }

        public void refreshUserInfo(User user)
        {
            CurrentUser.Instance.user = user;
            InterestsTextBlock.Text = "Vlastiti interesi: " + Environment.NewLine + CurrentUser.Instance.AllInterestsString;
        }

    }
}
