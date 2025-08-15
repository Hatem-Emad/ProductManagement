using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Product.DAL.Entities
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
