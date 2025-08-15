using Product.BL.DTO;
using Product.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BL.Interface
{
    public interface ICategoryRepo
    {
        public IEnumerable<CategoryDTO> Get();
        public CategoryDTO GetById(int id);
        public Category Post(CategoryDTO obj);
        public Category Put(CategoryDTO obj);
        public Category Patch(CategoryDTO obj);
        public void Delete(int id);
    }
}
