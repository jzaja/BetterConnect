using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Repository
{
    public interface IInterestRepository
    {
        IList<Interest> GetAll();
        Interest Save(Interest interest);
        Interest Update(Interest interest);
        Interest GetByName(string name);
        ISet<User> GetUsersByInterestName(string interestName);
    }
}
