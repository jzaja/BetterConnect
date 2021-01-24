using BetterConnectOO.Models;
using BetterConnectOO.View;
using BetterConnectOO.ViewModels;
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

namespace BetterConnectOO
{
    /// <summary>
    /// Interaction logic for GeneralWindow.xaml
    /// </summary>
    public partial class GeneralWindow : Window
    {
        private UsersViewModel _vm;

        public GeneralWindow()
        {
            InitializeComponent();

            _vm = new UsersViewModel();
            DataContext = _vm;
        }

        private void EditProfile(object sender, RoutedEventArgs e)
        {
            BetterConnectOO.View.Profile profile = new BetterConnectOO.View.Profile();
            profile.Show();
            GeneralWindow1.Close();
        }

        private void OnSendRequest(object sender, RoutedEventArgs e)
        {
            User clickedUser = (User)((sender as Button).DataContext);
            _vm.SendRequest(clickedUser.id);
        }

        private void OnRequests(object sender, RoutedEventArgs e)
        {
            RequestsWindow window = new RequestsWindow();
            window.Show();
        }
    }
}
