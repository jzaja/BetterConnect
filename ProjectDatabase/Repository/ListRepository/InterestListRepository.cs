using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Repository.ListRepository
{
    public class InterestListRepository : IInterestRepository
    {
        private IList<Interest> _interests = new List<Interest>();

        public IList<Interest> GetAll()
        {
            return _interests;
        }

        public Interest GetByName(string name)
        {
            foreach (Interest i in _interests)
            {
                if (i.Name.ToLower().Equals(name.ToLower()))
                {
                    return i;
                } 
            }

            return null;
        }

        public ISet<User> GetUsersByInterestName(string interestName)
        {
            Interest interest = GetByName(interestName);

            if (interest == null)
            {
                return null;
            }

            return interest.Users;
        }

        public Interest Save(Interest interest)
        {
            interest.Id = IdGenerator.getId();
            _interests.Add(interest);
            return interest;
        }

        public Interest Update(Interest interest)
        {
            foreach (Interest i in _interests)
            {
                if (i.Id == interest.Id)
                {
                    i.Users = interest.Users;
                    return i;
                }
            }

            return null;
        }
    }
}
