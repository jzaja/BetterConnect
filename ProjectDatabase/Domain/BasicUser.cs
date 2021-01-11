using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public abstract class BasicUser
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}
