using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public class SendRequestDTO
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
