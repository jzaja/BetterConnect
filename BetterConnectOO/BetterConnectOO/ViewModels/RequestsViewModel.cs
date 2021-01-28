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
using BetterConnectOO.ViewModels;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BetterConnectOO.Models.Singleton;

namespace BetterConnectOO.ViewModels
{
    class RequestsViewModel
    {
        public IList<Request> _receivedRequests;
        public IList<Request> _sentRequests;

        private ObservableCollection<User> _receivedRequestUsers { get; set; }
        private ObservableCollection<User> _sentRequestUsers { get; set; }
        /*
         * Received requests.
         */
        public ObservableCollection<User> ReceivedRequestUsers
        {
            get
            {
                return _receivedRequestUsers;
            }
            set
            {
                _receivedRequestUsers = value;
            }
        }
        /*
         * Sent requests.
         */
        public ObservableCollection<User> SentRequestUsers
        {
            get
            {
                return _sentRequestUsers;
            }
            set
            {
                _sentRequestUsers = value;
            }
        }

        public RequestsViewModel()
        {
            ReceivedRequestUsers = new ObservableCollection<User>();
            SentRequestUsers = new ObservableCollection<User>();

            FetchRequests();
        }

        private async Task FetchRequests()
        {
            int myId = CurrentUser.Instance.Id;

            IList<Request> receivedRequests = await APIManager.GetReceivedRequests(myId);
            _receivedRequests = receivedRequests; 
            IList<Request> sentRequests = await APIManager.GetSentRequests(myId);
            _sentRequests = sentRequests;

            receivedRequests.Select(request => GetById(request.SenderId)).ToList().ForEach(ReceivedRequestUsers.Add);
            sentRequests.Select(request => GetById(request.ReceiverId)).ToList().ForEach(SentRequestUsers.Add);
        }

        private User GetById(int userId)
        {
            IList<User> allUsers = AllUsers.Instance.Get();
            foreach (User user in allUsers)
            {
                if (user.id == userId)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
