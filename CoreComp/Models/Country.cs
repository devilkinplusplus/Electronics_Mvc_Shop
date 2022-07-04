using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreComp.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
