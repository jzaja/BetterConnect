using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using ProjectDatabase.Domain;
using ProjectDatabase.HibernateHelper;

namespace ProjectDatabase.Repository.ConcreteRepository
{
    public class UserRepository : IUserRepository
    {
        private ISession session;
        public UserRepository(INHibernateHelper helper)
        {
            session = helper.OpenSession();
        }

        public IList<User> GetAll()
        {
            return session.Query<User>().ToList();
        }

        public BasicUser Get(int id)
        {
            return session.Get<BasicUser>(id);
        }

        public User GetUser(int id)
        {
            return session.Get<User>(id);
        }

        public BasicUser GetByUsername(string username)
        {
            var result = session.Query<BasicUser>().Where(u => u.Username.ToLower().Equals(username.ToLower())).ToList();
            if (IsResultListEmpty(result))
            {
                return null;
            }

            return result.First();
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            var result = session.Query<User>().Where(u => u.PhoneNumber.Equals(phoneNumber)).ToList();
            if (IsResultListEmpty(result))
            {
                return null;
            }

            return result.First();
        }

        public bool ExistsByUsernameOrPhoneNumber(string username, string phoneNumber)
        {
            bool exists = session.Query<User>().Any(u => u.Username.ToLower().Equals(username.ToLower()) || u.PhoneNumber.Equals(phoneNumber));
            return exists;
        }

        private bool IsResultListEmpty(IList<BasicUser> userList)
        {
            return !userList.Any();
        }

        private bool IsResultListEmpty(IList<User> userList)
        {
            return !userList.Any();
        }

        public long RowCount()
        {
            return session.QueryOver<BasicUser>().RowCountInt64();
        }

        public BasicUser Save(BasicUser user)
        {
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Save(user);
                tx.Commit();
                return user;
            }
        }

        public void Update(BasicUser user)
        {
            using (var tx = session.BeginTransaction())
            {
                //session.Update(user);
                session.Merge(user);
                tx.Commit();
            }
        }

        public User Delete(User user)
        {
            using (var tx = session.BeginTransaction())
            {
                session.Delete(user);
                tx.Commit();
                return user;
            }
        }

        public long AdminRowCount()
        {
            return session.QueryOver<Admin>().RowCountInt64();
        }

        public long UsersRowCount()
        {
            return session.QueryOver<User>().RowCountInt64();
        }

    }
}
