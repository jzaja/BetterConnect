using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public class Admin : BasicUser
    {
        public virtual string AdminRole { get; set; }

        public Admin()
        {
            AdminRole = "admin";
            IsRegularUser = false;
        }
    }
}
