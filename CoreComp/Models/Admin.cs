using System.ComponentModel.DataAnnotations;

namespace CoreComp.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
