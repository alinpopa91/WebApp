using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Context
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }
        public int? RoleId { get; set; }
    }
}
