using Microsoft.EntityFrameworkCore;

namespace commerce.Models
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class UserProduct
    {
        public int UserId { get; set; }
        public User User { get; set; }  
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
