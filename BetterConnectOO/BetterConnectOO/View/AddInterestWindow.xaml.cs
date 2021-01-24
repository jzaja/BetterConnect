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
    /// Interaction logic for AddInterestWindow.xaml
    /// </summary>
    /// 

    public partial class AddInterestWindow : Window
    {
        //public AddInterestWindowDelegate _delegate;

        public AddInterestWindow()
        {
            InitializeComponent();
        }

        private async void OnAdd(object sender, RoutedEventArgs e)
        {
            string interestName = InterestTextBox.Text;
            if (string.IsNullOrEmpty(interestName) || interestName.Count() == 0)
            {
                MessageBox.Show("Interest cannot be empty");
            }

            User user = await APIManager.AddInterest(interestName, CurrentUser.Instance.Id);
            if (user == null)
            {
                MessageBox.Show("This interest already exists!");
            } else
            {
                // obavijesti parent window, uzmi usera dobivenog iz responsa i stavi ga za current usera
                //_delegate.refreshUserInfo(user);
                this.Close();
            }
        }
    }
}
