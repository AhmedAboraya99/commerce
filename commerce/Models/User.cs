using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace commerce.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80)]
        public string Name { get; set; }
        [Required( ErrorMessage= "This mail is required")]
        public string Email {  get; set; }
        [MinLength(8)]
        
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "The password" )]
        public string Password { get; set; }

        public List<Product> Products { get; set; }
    }
}
