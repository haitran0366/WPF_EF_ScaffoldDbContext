using System;
using System.Collections.Generic;

#nullable disable

namespace WPF_EF_ScaffoldDbContext.Models
{
    public partial class TblCountry
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Greeting { get; set; }
    }
}
