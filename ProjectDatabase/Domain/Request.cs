using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public class Request
    {
        public virtual int SenderId { get; set; }
        public virtual int ReceiverId { get; set; }
        public virtual int ConfirmationsNum { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Request;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.SenderId == other.SenderId &&
                this.ReceiverId == other.ReceiverId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ SenderId.GetHashCode();
                hash = (hash * 31) ^ ReceiverId.GetHashCode();

                return hash;
            }
        }

    }
}
