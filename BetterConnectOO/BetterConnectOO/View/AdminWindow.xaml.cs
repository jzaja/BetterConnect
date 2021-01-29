using BetterConnectOO.Models;
using BetterConnectOO.Models.Singleton;
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

namespace BetterConnectOO.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private UsersViewModel _vm;
        public AdminWindow()
        {
            InitializeComponent();

            _vm = new UsersViewModel();
            DataContext = _vm;
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            string searchedInterest = InterestSearchTextBox.Text;
            _vm.SearchUsersWithInterest(searchedInterest);
        }

        private void OnBlock(object sender, RoutedEventArgs e)
        {
            User clickedUser = (User)((sender as Button).DataContext);
            _vm.BlockUser(clickedUser);
        }

        private void OnLogout(object sender, RoutedEventArgs e)
        {
            CurrentUser.Instance.user = null;

            MainWindow window = new MainWindow();
            window.Show();

            this.Close();
        }
    }
}
