using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Repository
{
    public interface IInterestRepository
    {
        Interest Save(Interest interest);
        Interest GetByName(string name);
        IList<User> GetUsersByInterestName(string interestName);
    }
}
