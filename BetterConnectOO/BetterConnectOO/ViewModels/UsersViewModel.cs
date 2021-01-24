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
    class UsersViewModel
    {
        private ObservableCollection<User> _users { get; set; }
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
            }
        }

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();
            FetchUsers();
        }   

        public async void FetchUsers()
        {
            IList<User> allUsers = await APIManager.GetAllUsers();

            int currentUserId = CurrentUser.Instance.Id;
            allUsers.ToList().Where(user => user.id != currentUserId).ToList().ForEach(Users.Add);

            //allUsers.ToList().ForEach(Users.Add);
        }

        public async void SendRequest(int receiverId)
        {
            int myId = CurrentUser.Instance.Id;
            Request sent = await APIManager.SendRequest(myId, receiverId);

            if (sent == null)
            {
                MessageBox.Show("Request already sent!");
            }
            else
            {
                MessageBox.Show("Request sent!");
            }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }

    }
}
