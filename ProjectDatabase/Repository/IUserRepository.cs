using System;
using System.Collections.Generic;
using System.Text;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        BasicUser Get(int id);
        BasicUser GetByUsername(string username);
        User GetByPhoneNumber(string phoneNumber);
        bool ExistsByUsernameOrPhoneNumber(string username, string phoneNumber);
        BasicUser Save(BasicUser user);
        void Update(BasicUser user);
        User Delete(User user);
        long RowCount();
        long AdminRowCount();
        long UsersRowCount();
        User GetUser(int id);
    }
}
