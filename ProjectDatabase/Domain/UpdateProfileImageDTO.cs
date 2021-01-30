using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Domain
{
    public class UpdateProfileImageDTO
    {
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
    }
}
