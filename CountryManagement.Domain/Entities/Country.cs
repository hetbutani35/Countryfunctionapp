using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryManagement.Domain.Entities
{
    public class Country
    {
        public int id { get; set; }
        public string countrycode { get; set; } = string.Empty;
        public string countryname { get; set; } = string.Empty;
        public DateTime createddate { get; set; }
        public int createdby { get; set; }
        public bool isactive { get; set; }

        public string IsValid(Country country)
        {
            StringBuilder error = new StringBuilder();
            if (countrycode == string.Empty)
                error.AppendLine("CountryCode Required.");
            else if (countrycode.Length > 3)
                error.AppendLine("CountryCode Nor More than 3 Character");
            if (countryname == string.Empty)
                error.AppendLine("CountryName Required.");
            else if (countryname.Length > 25)
                error.AppendLine("CountryName Nor More than 3 Character");

            return string.Empty;
        }
    }
}
