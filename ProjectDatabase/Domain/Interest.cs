using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public class Interest
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<User> Users { get; set; }

        public Interest()
        {
            Users = new List<User>();
        }

    }
}
