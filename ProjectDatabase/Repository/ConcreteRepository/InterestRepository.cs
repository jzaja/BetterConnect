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

        public IList<Interest> GetAll()
        {
            return session.Query<Interest>().ToList();
        }

        public Interest Save(Interest interest)
        {
            using (var tx = session.BeginTransaction())
            {
                session.Save(interest);
                tx.Commit();
                return interest;
            }
        }

        public Interest Update(Interest interest)
        {
            using (var tx = session.BeginTransaction())
            {
                session.Merge(interest);
                return interest;
            }
        }

        public Interest GetByName(string name)
        {
            return session.Query<Interest>().Where(i => i.Name.ToLower().Equals(name.ToLower())).SingleOrDefault();
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

    }
}
