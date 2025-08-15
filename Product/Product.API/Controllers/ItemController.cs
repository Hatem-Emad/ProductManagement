using Microsoft.AspNetCore.Mvc;
using Product.BL.DTO;
using Product.BL.Interface;
using Product.DAL.Entities;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepo _itemRepo;

        public ItemController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _itemRepo.Get();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemRepo.GetById(id);
            if (item == null)
                return NotFound($"Item with ID {id} not found.");

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdItem = _itemRepo.Post(obj);

            return Ok(createdItem);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ItemDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedItem = _itemRepo.Put(obj);
            if (updatedItem == null)
                return NotFound($"Item with ID {obj.ID} not found.");

            return Ok(updatedItem);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] ItemDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedItem = _itemRepo.Patch(obj);
            if (updatedItem == null)
                return NotFound($"Item with ID {obj.ID} not found.");

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _itemRepo.GetById(id);
            if (existingItem == null)
                return NotFound($"Item with ID {id} not found.");

            _itemRepo.Delete(id);
            return NoContent();
        }
    }
}
