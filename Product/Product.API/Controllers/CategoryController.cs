using Microsoft.AspNetCore.Mvc;
using Product.BL.DTO;
using Product.BL.Interface;
using Product.DAL.Entities;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _CategoryRepo;

        public CategoryController(ICategoryRepo CategoryRepo)
        {
            _CategoryRepo = CategoryRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Categorys = _CategoryRepo.Get();
            return Ok(Categorys);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Category = _CategoryRepo.GetById(id);
            if (Category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(Category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCategory = _CategoryRepo.Post(obj);

            return Ok(createdCategory);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CategoryDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCategory = _CategoryRepo.Put(obj);
            if (updatedCategory == null)
                return NotFound($"Category with ID {obj.ID} not found.");

            return Ok(updatedCategory);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] CategoryDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCategory = _CategoryRepo.Patch(obj);
            if (updatedCategory == null)
                return NotFound($"Category with ID {obj.ID} not found.");

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingCategory = _CategoryRepo.GetById(id);
                if (existingCategory == null)
                    return NotFound($"Category with ID {id} not found.");

                _CategoryRepo.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
