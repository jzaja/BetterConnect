using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterConnectOO.Models.Singleton
{
    public sealed class CurrentUser
    {
        public User user;
        private static CurrentUser instance;
        public static CurrentUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentUser();
                }
                return instance;
            }
        }

        private CurrentUser()
        {

        }

        public int Id
        {
            get
            {
                return user.id;
            }
        }

        public string Username
        {
            get
            {
                return user.username;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return user.phoneNumber;
            }
        }

        public string AllInterestsString
        {
            get
            {
                string result = "";
                int interestsCount = user.interests.Count;
                for (int i = 0; i < interestsCount; i++)
                {
                    Interest interest = user.interests.ElementAt(i);
                    result += interest.name;
                    if (i < interestsCount - 1)
                    {
                        result += Environment.NewLine;
                    }
                }
                return result;
            }
        }

    }
}
