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
            int count = 0;
            foreach (BasicUser u in _users)
            {
                if (!u.IsRegularUser)
                {
                    count++;
                }
            }

            return count;
        }

        public User Delete(User user)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByUsernameOrPhoneNumber(string username, string phoneNumber)
        {
            foreach (BasicUser u in _users)
            {

                if (u is User)
                {
                    User user = (User)u;
                    if (user.Username.Equals(username) || user.PhoneNumber.Equals(phoneNumber))
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        public BasicUser Get(int id)
        {
            foreach (BasicUser u in _users)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }

            return null;
        }

        public IList<BasicUser> GetAll()
        {
            return _users;
        }

        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();
            foreach (BasicUser u in _users)
            {
                if (u.IsRegularUser)
                {
                    users.Add((User) u);
                }
            }

            return users;
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            foreach (User u in _users)
            {
                if (u.PhoneNumber == phoneNumber)
                {
                    return u;
                }
            }

            return null;
        }

        public BasicUser GetByUsername(string username)
        {
            foreach (User u in _users)
            {
                if (u.Username.ToLower().Equals(username.ToLower()))
                {
                    return u;
                }
            }

            return null;
        }

        public User GetUser(int id)
        {
            foreach (BasicUser u in _users)
            {
                if (u.Id == id)
                {
                    return (User) u;
                }
            }

            return null;
        }

        public long RowCount()
        {
            return _users.Count;
        }

        public BasicUser Save(BasicUser user)
        {
            user.Id = IdGenerator.getId();
            _users.Add(user);
            return user;
        }

        public void Update(BasicUser user)
        {
            foreach (BasicUser u in _users)
            {
                if (u.Id == user.Id)
                {
                    u.Username = user.Username;
                    u.Password = user.Password;
                }
            }
        }

        public long UsersRowCount()
        {
            int count = 0;
            foreach (BasicUser u in _users)
            {
                if (u.IsRegularUser)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
