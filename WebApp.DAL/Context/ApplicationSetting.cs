using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Context
{
    public partial class ApplicationSetting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public string Secret = "aaa";
    }
}
