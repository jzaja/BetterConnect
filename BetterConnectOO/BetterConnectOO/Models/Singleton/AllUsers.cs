using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterConnectOO.Models.Singleton
{
    public sealed class AllUsers
    {
        private static IList<User> _allUsers;
        private static AllUsers instance;
        public static AllUsers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AllUsers();
                }
                return instance;
            }
        }

        private AllUsers()
        {

        }

        public void Set(IList<User> users)
        {
            _allUsers = users;
        }

        public IList<User> Get()
        {
            return _allUsers;
        }

    }
}
