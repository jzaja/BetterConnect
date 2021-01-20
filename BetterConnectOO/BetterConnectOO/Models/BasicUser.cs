using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BetterConnectOO.Models
{
    public abstract class BasicUser : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRegularUser { get; set; }

        public int id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
                OnPropertyChanged("id");
            }
        }

        public string username
        {
            get
            {
                return Username;
            }
            set
            {
                Username = value;
                OnPropertyChanged("username");
            }
        }

        public string password
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
                OnPropertyChanged("password");
            }
        }

        public bool isRegularUser
        {
            get
            {
                return IsRegularUser;
            }
            set
            {
               IsRegularUser = value;
                OnPropertyChanged("isRegularUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
