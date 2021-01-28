using BetterConnectOO.API;
using BetterConnectOO.Models;
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
    /// Interaction logic for AcceptDeclineWindow.xaml
    /// </summary>
    /// 

    public interface AcceptDeclineWindowDelegate
    {
        void RequestAccepted();
        void RequestDeclined();
    }

    public partial class AcceptDeclineWindow : Window
    {
        private Request _request;
        public AcceptDeclineWindowDelegate _delegate;

        public AcceptDeclineWindow()
        {
            InitializeComponent();
        }

        public void SetUsername(string username)
        {
            UsernameLabel.Content = username;
        }

        public void SetRequest(Request request)
        {
            this._request = request;
        }

        private async void OnAccept(object sender, RoutedEventArgs e)
        {
            Request confirmed = await APIManager.ApproveRequest(_request.SenderId, _request.ReceiverId);
            _delegate.RequestAccepted();
            this.Close();
        }

        private async void OnDecline(object sender, RoutedEventArgs e)
        {
            Request declined = await APIManager.DeclineRequest(_request.SenderId, _request.ReceiverId);
            _delegate.RequestDeclined();
            this.Close();
        }
    }
}
