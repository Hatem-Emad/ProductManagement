using Product.BL.DTO;
using Product.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BL.Interface
{
    public interface IItemRepo
    {
        public IEnumerable<ItemDTO> Get();
        public ItemDTO GetById(int id);
        public Item Post(ItemDTO obj);
        public Item Put(ItemDTO obj);
        public Item Patch(ItemDTO obj);
        public void Delete(int id);
    }
}
