using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatababaseTest
{
    public class Generator
    {
        public static User GenerateUser(string username, string password, string phoneNumber)
        {
            return new User { Username = username, Password = password, PhoneNumber = phoneNumber };
        }

        public static Interest GenerateInterest(string interestName)
        {
            return new Interest { Name = interestName };
        }

    }
}
