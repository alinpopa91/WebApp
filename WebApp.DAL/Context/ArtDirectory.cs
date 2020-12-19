using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Context
{
    public partial class ArtDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Category { get; set; }
        public int? Visible { get; set; }
        public decimal? Price { get; set; }
        public string Size { get; set; }
        public string Original { get; set; }
        public bool? Signed { get; set; }
        public string Code { get; set; }
    }
}
