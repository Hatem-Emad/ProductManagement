using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Product.DAL.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}
