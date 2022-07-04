using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreComp.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Name can't be empty !")]
        [StringLength(30,ErrorMessage ="Maximum character limit is 30 !")]
        public string CategoryName { get; set; }
        public bool Status { get; set; }

        public Category()
        {
            this.Status = true;
        }


        public List<Product> Products { get; set; }
    }
}
