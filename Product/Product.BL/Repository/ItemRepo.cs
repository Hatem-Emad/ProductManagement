using Product.BL.DTO;
using Product.BL.Interface;
using Product.DAL.Context;
using Product.DAL.Entities;

namespace Product.BL.Repository
{
    public class ItemRepo : IItemRepo
    {
        private ProductContext _context;
        public ItemRepo(ProductContext context)
        {
            _context = context;

        }
        public IEnumerable<ItemDTO> Get()
        {
            var ItemDTOs = _context.Item.Select(i => new ItemDTO
            {
                ID = i.ID,
                Name = i.Name,
                CategoryId = i.CategoryId,
                Description = i.Description,
            });

            return ItemDTOs;

        }

        public ItemDTO GetById(int id)
        {
            var ItemDTO = _context.Item.Where(x => x.ID == id).Select(i => new ItemDTO
            {
                ID = i.ID,
                Name = i.Name,
                CategoryId = i.CategoryId,
                Description = i.Description,
            }).FirstOrDefault();

            return ItemDTO;
        }
        public Item Post(ItemDTO obj)
        {
            var newItem = new Item
            {
                Name = obj.Name,
                CategoryId = obj.CategoryId,
                Description = obj.Description
            };

            _context.Item.Add(newItem);
            _context.SaveChanges();

            return newItem;
        }

        public Item Put(ItemDTO obj)
        {
            var existingItem = _context.Item.FirstOrDefault(i => i.ID == obj.ID);
            if (existingItem == null)
                return null;

            existingItem.Name = obj.Name;
            existingItem.CategoryId = obj.CategoryId;
            existingItem.Description = obj.Description;

            _context.SaveChanges();
            return existingItem;
        }
        public Item Patch(ItemDTO obj)
        {
            var existingItem = _context.Item.FirstOrDefault(i => i.ID == obj.ID);
            if (existingItem == null)
                return null;

            if (!string.IsNullOrEmpty(obj.Name))
                existingItem.Name = obj.Name;

            if (obj.CategoryId != 0)
                existingItem.CategoryId = obj.CategoryId;

            if (!string.IsNullOrEmpty(obj.Description))
                existingItem.Description = obj.Description;

            _context.SaveChanges();
            return existingItem;
        }

        public void Delete(int id)
        {
            var existingItem = _context.Item.FirstOrDefault(i => i.ID == id);
            if (existingItem != null)
            {
                _context.Item.Remove(existingItem);
                _context.SaveChanges();
            }
        }


    }
}
