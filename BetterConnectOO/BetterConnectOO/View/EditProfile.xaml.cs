using BetterConnectOO.API;
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
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    /// 

    public interface AddInterestWindowDelegate
    {
        void refreshUserInfo(User user);
    }

    public partial class EditProfile : Window
    {
        public AddInterestWindowDelegate _delegate; 

        public EditProfile()
        {
            InitializeComponent();

            string allUsersInterests = CurrentUser.Instance.AllInterestsString;
            if (allUsersInterests != null)
            {
                AllInterestsLabel.Content = allUsersInterests;
            }
        }

        private void BackToProfile(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void OnAddInterest(object sender, RoutedEventArgs e)
        {
            string interestName = AddInterestTextBox.Text;
            if (!IsInputValid(interestName))
            {
                ShowErrorMessage();
            }
            else
            {
                User user = await APIManager.AddInterest(interestName, CurrentUser.Instance.Id);
                if (user == null)
                {
                    MessageBox.Show("Ovaj interes već postoji!");
                }
                else
                {
                    // obavijesti parent window, uzmi usera dobivenog iz responsa i stavi ga za current usera
                    AddInterestTextBox.Text = "";
                    _delegate.refreshUserInfo(user);
                    AllInterestsLabel.Content = CurrentUser.Instance.AllInterestsString;
                }
            }

        }

        private async void OnRemoveInterest(object sender, RoutedEventArgs e)
        {
            string interestName = RemoveInterestTextBox.Text;
            if (!IsInputValid(interestName))
            {
                ShowErrorMessage();
            }
            else
            {
                User user = await APIManager.RemoveInterest(interestName, CurrentUser.Instance.Id);
                if (user == null)
                {
                    MessageBox.Show("Ovaj interes niste ni imali!");
                }
                else
                {
                    RemoveInterestTextBox.Text = "";
                    // obavijesti parent window, uzmi usera dobivenog iz responsa i stavi ga za current usera
                    _delegate.refreshUserInfo(user);
                    AllInterestsLabel.Content = CurrentUser.Instance.AllInterestsString;
                }
            }
        }

        private bool IsInputValid(string input)
        {
            return !(string.IsNullOrEmpty(input) || input.Count() == 0);
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("Interes ne može biti prazan!");
        }

    }
}
