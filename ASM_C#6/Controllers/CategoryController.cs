using ASM_C_6.DTO.Category;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ct = await _categoryRepository.GetAll();
            return Ok(ct);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ct = await _categoryRepository.GetById(id);
            if (ct == null)
            {
                return NotFound();
            }
            return Ok(ct);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ct = await _categoryRepository.Create(categoryDto);
            return Ok(ct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDto categoryDto)
        {
            var ct = await _categoryRepository.GetById(id);
            if (ct == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var ctModel = await _categoryRepository.Update(id, categoryDto);
            return Ok("Đã cập nhạt thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id )
        {
           var ct = await _categoryRepository.GetById(id);
            if (ct == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
           var ctModel = await _categoryRepository.DeleteById(id);
           return Ok("Đã xóa thành công !");
        }
    }
}
