using Microsoft.EntityFrameworkCore;
using Product.BL.DTO;
using Product.BL.Interface;
using Product.DAL.Context;
using Product.DAL.Entities;

namespace Product.BL.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private ProductContext _context;
        public CategoryRepo(ProductContext context)
        {
            _context = context;

        }
        public IEnumerable<CategoryDTO> Get()
        {
            var CategoryDTOs = _context.Category.Select(i => new CategoryDTO
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description,
            });

            return CategoryDTOs;

        }

        public CategoryDTO GetById(int id)
        {
            var CategoryDTO = _context.Category.Include(c => c.Items)
                .Where(x => x.ID == id)
                .Select(i => new CategoryDTO
                {
                    ID = i.ID,
                    Name = i.Name,
                    Description = i.Description,
                    Items = i.Items.Select(item => new ItemDTO
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description,
                        CategoryId = item.CategoryId
                    }).ToList()
                }).FirstOrDefault();

            return CategoryDTO;
        }
        public Category Post(CategoryDTO obj)
        {
            var newCategory = new Category
            {
                Name = obj.Name,
                Description = obj.Description
            };

            _context.Category.Add(newCategory);
            _context.SaveChanges();

            return newCategory;
        }

        public Category Put(CategoryDTO obj)
        {
            var existingCategory = _context.Category.FirstOrDefault(i => i.ID == obj.ID);
            if (existingCategory == null)
                return null;

            existingCategory.Name = obj.Name;
            existingCategory.Description = obj.Description;

            _context.SaveChanges();
            return existingCategory;
        }
        public Category Patch(CategoryDTO obj)
        {
            var existingCategory = _context.Category.FirstOrDefault(i => i.ID == obj.ID);
            if (existingCategory == null)
                return null;

            if (!string.IsNullOrEmpty(obj.Name))
                existingCategory.Name = obj.Name;

            if (!string.IsNullOrEmpty(obj.Description))
                existingCategory.Description = obj.Description;

            _context.SaveChanges();
            return existingCategory;
        }

        public void Delete(int id)
        {
            var existingCategory = _context.Category.FirstOrDefault(i => i.ID == id);
            if (existingCategory != null)
            {
                bool IsUsed = _context.Item.Any(i => i.CategoryId == id);
                if (IsUsed)
                    throw new Exception("This Category is used in at least one item");
                _context.Category.Remove(existingCategory);
                _context.SaveChanges();
            }
        }

    }
}
