using System.ComponentModel.DataAnnotations;

namespace CoreComp.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }


        [Required(ErrorMessage = "Can't be empty !")]
        public string ProdName { get; set; }


        [Required(ErrorMessage = "Can't be empty !")]
        public int ProdPrice { get; set; }


        [Required(ErrorMessage = "Can't be empty !")]
        public int ProdStock { get; set; }
        public string ImageUrl { get; set; }


        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
