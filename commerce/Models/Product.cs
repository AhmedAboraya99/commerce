using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace commerce.Models

{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000.00, ErrorMessage =" this price out of range")]
        public double Price { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Quntity { get; set; }

        //[JsonIgnore]
        public ICollection<User> user { get; set; }

    }
}
