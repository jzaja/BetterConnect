using System;
using System.Collections.Generic;
using System.Text;

namespace BetterConnectOO.Models
{
    public abstract class BasicUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isRegularUser { get; set; }
    }
}
