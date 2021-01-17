using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectDatabase.Domain
{
    public class Interest
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        [JsonIgnore]
        public virtual ISet<User> Users { get; set; }

        public Interest()
        {
            Users = new HashSet<User>();
        }

        public virtual void AddUser(User user)
        {
            if (!Users.Contains(user))
            {
                Users.Add(user);
            }
            user.Interests.Add(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Interest;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Name.ToLower().Equals(other.Name.ToLower());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Name.GetHashCode();

                return hash;
            }
        }

    }
}
