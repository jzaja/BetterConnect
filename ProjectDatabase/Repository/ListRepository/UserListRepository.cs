using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Repository.ListRepository
{
    public class UserListRepository : IUserRepository
    {
        private IList<BasicUser> _users = new List<BasicUser>();

        public long AdminRowCount()
        {
            throw new NotImplementedException();
        }

        public User Delete(User user)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByUsernameOrPhoneNumber(string username, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public BasicUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            IList<User> users = new List<User>();
            foreach (User u in _users)
            {
                if (u.isRegularUser)
                {
                    System.Diagnostics.Debug.WriteLine("dodajem");
                    users.Add(u);
                }
            }

            return users;
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public BasicUser GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public long RowCount()
        {
            throw new NotImplementedException();
        }

        public BasicUser Save(BasicUser user)
        {
            _users.Add(user);
            return user;
        }

        public void Update(BasicUser user)
        {
            throw new NotImplementedException();
        }

        public long UsersRowCount()
        {
            throw new NotImplementedException();
        }
    }
}
