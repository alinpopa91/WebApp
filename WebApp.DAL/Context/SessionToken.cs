using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Context
{
    public partial class SessionToken
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public Guid? Token { get; set; }
        public bool? Active { get; set; }
        public DateTime? Start { get; set; }
        public DateTime Expire { get; set; }
        public string Email { get; set; }
    }
}
