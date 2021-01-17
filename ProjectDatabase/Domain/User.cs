using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public class User : BasicUser
    {
        public virtual string PhoneNumber { get; set; }
        public virtual IList<Interest> Interests { get; set; }
        public virtual ISet<Request> Requests { get; set; }

        public User()
        {
            Interests = new List<Interest>();
            Requests = new HashSet<Request>();
            isRegularUser = true;
        }

        public virtual void AddInterest(Interest interest)
        {
            interest.Users.Add(this);
            Interests.Add(interest);
        }

        public virtual void RemoveInterest(Interest interest)
        {
            interest.Users.Remove(this);
            Interests.Remove(interest);
        }

        public virtual void AddRequest(Request request)
        {
            Requests.Add(request);
        }

    }
}
