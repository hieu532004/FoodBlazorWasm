using ASM_C_6.DTO.Customer;
using ASM_C_6.DTO.Product;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prd = await _productRepository.GetAll();
            return Ok(prd);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var prd = await _productRepository.GetById(id);
            if (prd == null)
            {
                return NotFound();
            }
            return Ok(prd);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prd = await _productRepository.Create(productDto);
            return Ok(prd);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] ProductDto productDto )
        {
            var prd = await _productRepository.GetById(id);
            if(prd == null)
            {
                return BadRequest("Không tìm thấy id!");
            }
            var prdModel = await _productRepository.Update(id, productDto);
            return Ok("Đã cập nhạt thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute]int id)
        {
            var prd = await _productRepository.GetById(id);
            if (prd == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var prdModel = await _productRepository.DeleteById(id);
            return Ok("Đã xóa thành công !");
        }
    }
}
