using BetterConnectOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BetterConnectOO.ViewModels
{
    class UsersViewModel
    {
        private IList<User> _users;

        public UsersViewModel()
        {
            _users = new List<User>
            {
                new User { Username = "desii", password = "nemaa", isRegularUser = true },
                new User { username = "misko", password = "nemaa", isRegularUser = true },
                new User { username = "maleni", password = "nemaa", isRegularUser = true },
            };
        }

        public IList<User> Users
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
