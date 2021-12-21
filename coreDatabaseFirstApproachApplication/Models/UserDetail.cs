using System;
using System.Collections.Generic;

#nullable disable

namespace coreDatabaseFirstApproachApplication.Models
{
    public partial class UserDetail
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
