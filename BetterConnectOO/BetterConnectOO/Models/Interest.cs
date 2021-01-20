using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BetterConnectOO.Models
{
    public class Interest : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ISet<User> Users { get; set; }

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

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }

        public ISet<User> users
        {
            get
            {
                return Users;
            }
            set
            {
                Users = value;
                OnPropertyChanged("users");
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


        /*
        public override bool Equals(object obj)
        {
            var other = obj as Interest;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Name.ToLower().Equals(other.Name.ToLower());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Name.GetHashCode();

                return hash;
            }
        }
        */
    }
}
