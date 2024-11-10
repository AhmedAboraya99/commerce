using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace commerce.DTOs
{
    public class UserDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<int> ProductId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> ProductName { get; set; } = null;
    }
}
