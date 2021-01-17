using NHibernate;
using ProjectDatabase.Domain;
using ProjectDatabase.HibernateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDatabase.Repository.ConcreteRepository
{
    public class InterestRepository : IInterestRepository
    {
        private ISession session;

        public InterestRepository(INHibernateHelper helper)
        {
            session = helper.OpenSession();
        }

        public Interest Save(Interest interest)
        {
            if (GetByName(interest.Name) != null)
            {
                return null;
            }

            using (var tx = session.BeginTransaction())
            {
                session.Save(interest);
                tx.Commit();
                return interest;
            }
        }

        public Interest GetByName(string name)
        {
            return session.Query<Interest>().Where(i => i.Name.ToLower().Equals(name.ToLower())).SingleOrDefault();
        }

        public IList<User> GetUsersByInterestName(string interestName)
        {
            Interest interest = GetByName(interestName);
            return interest.Users;
        }

    }
}
