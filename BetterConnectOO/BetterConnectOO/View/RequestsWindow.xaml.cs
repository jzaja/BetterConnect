using BetterConnectOO.API;
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
    /// Interaction logic for RequestsWindow.xaml
    /// </summary>
    public partial class RequestsWindow : Window
    {
        private RequestsViewModel _vm;
        public RequestsWindow()
        {
            InitializeComponent();

            _vm = new RequestsViewModel();
            this.DataContext = _vm;
        }

        private void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clickedIndex = UserGrid.SelectedIndex;
            MessageBox.Show(clickedIndex.ToString());
        }
    }
}
