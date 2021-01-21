using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BetterConnectOO.Models
{
    public class User : BasicUser
    {
        public string PhoneNumber { get; set; }
        public IList<Interest> Interests { get; set; }
        public string InterestsString { get; set; }

        public string phoneNumber
        {
            get
            {
                return PhoneNumber;
            }
            set
            {
                PhoneNumber = value;
                OnPropertyChanged("phoneNumber");
            }
        }

        public IList<Interest> interests
        {
            get
            {
                return Interests;
            }
            set
            {
                Interests = value;
                OnPropertyChanged("interests");
            }
        }

        public string interestsString
        {
            get
            {
                if (interests != null)
                {
                    string finalString = "";
                    for (int i = 0; i < interests.Count; i++)
                    {
                        finalString += interests.ElementAt(i).name;
                        if (i < interests.Count - 1)
                        {
                            finalString += ", ";
                        }
                    }

                    InterestsString = finalString;
                }

                return InterestsString;
            }
            set
            {
                InterestsString = value;
                OnPropertyChanged("interestsString");
            }
        }

        public void AddInterest(Interest interest)
        {
            if (interests == null)
            {
                interests = new List<Interest>();
            }

            //interest.Users.Add(this);
            interests.Add(interest);

            string finalString = "";

            for (int i = 0; i < interests.Count; i++)
            {
                finalString += interests.ElementAt(i).name;
                if (i < interests.Count - 1)
                {
                    finalString += ", ";
                }
            }
            interestsString = finalString;
        }

        public void RemoveInterest(Interest interest)
        {
            interest.Users.Remove(this);
            Interests.Remove(interest);
        }

    }
}
