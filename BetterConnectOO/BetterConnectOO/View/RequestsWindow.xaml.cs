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
    /// 
    public partial class RequestsWindow : Window, AcceptDeclineWindowDelegate
    {
        private RequestsViewModel _vm;
        public RequestsWindow()
        {
            InitializeComponent();

            _vm = new RequestsViewModel();
            this.DataContext = _vm;
        }

        private async void UserGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clickedIndex = UserGrid.SelectedIndex;
            var userSender = _vm.ReceivedRequestUsers.ElementAt(clickedIndex);
            var selectedRequest = _vm._receivedRequests.ElementAt(clickedIndex);
            Request request = await APIManager.GetRequest(selectedRequest.SenderId, selectedRequest.ReceiverId);

            if (!request.IsConfirmed && !request.IsDeclined)
            {
                AcceptDeclineWindow window = new AcceptDeclineWindow();
                window._delegate = this;
                window.SetUsername(userSender.username);
                window.SetRequest(request);
                window.Show();
            }
            else
            {
                if (request.IsConfirmed)
                {
                    MessageBox.Show("You already confirmed this request.");
                }
                else
                {
                    if (request.IsDeclined)
                    {
                        MessageBox.Show("You already declined this request.");
                    }
                }
            }
        }

        public void RequestAccepted()
        {
            MessageBox.Show("You confirmed the request!");
        }

        public void RequestDeclined()
        {
            MessageBox.Show("You declined the request!");
        }

        private async void UserGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clickedIndex = UserGrid1.SelectedIndex;
            var userReceiver = _vm.SentRequestUsers.ElementAt(clickedIndex);
            var selectedRequest = _vm._sentRequests.ElementAt(clickedIndex);
            Request request = await APIManager.GetRequest(selectedRequest.SenderId, selectedRequest.ReceiverId);

            if (!request.IsConfirmed && !request.IsDeclined)
            {
                MessageBox.Show("Zahtjev je još na čekanju.");
            }
            else
            {
                if (request.IsConfirmed)
                {
                    MessageBox.Show("Čestitamo! Korisnik: " + userReceiver.username + " je prihvatio Vaš zahtjev. Mobilni broj korisnika je: " + userReceiver.phoneNumber);
                }
                else
                {
                    if (request.IsDeclined)
                    {
                        MessageBox.Show("Nažalost, korisnik: " + userReceiver.username + " je odbio Vaš zahtjev.");
                    }
                }
            }
        }
    }
}
