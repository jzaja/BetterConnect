using BetterConnectOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterConnectOO.ViewModels
{
    public class UserRequest
    {
        private User _user { get; set; }
        private Request _request { get; set; }

        public UserRequest(User user, Request request)
        {
            this._user = user;
            this._request = _request;
        }



    }
}
