using ASM_C_6.DTO.ProductItem;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductItemRepository _productItemRepository;

        public ProductItemController(IProductItemRepository productItemRepository)
        {
            _productItemRepository = productItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _productItemRepository.GetAll();
            return Ok(item);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var item = await _productItemRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Created(ProductItemDto productItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = await _productItemRepository.Create(productItemDto);
            return Ok(item);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductItemDto productItemDto)
        {
            var item = await _productItemRepository.GetById(id);
            if (item == null)
            {
                return BadRequest("Không tìm thấy id !");

            }
            var itemModel = await _productItemRepository.Update(id, productItemDto);
            return Ok("Đã cập nhật thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var item = await _productItemRepository.GetById(id);
            if (item == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var itemModel = await _productItemRepository.DeleteById(id);
            return Ok("Đã xóa thành công !");
        }
    }
}
