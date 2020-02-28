using System;
using System.Collections.Generic;

namespace LoginSito.Models.Entities
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
