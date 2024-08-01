using ASM_C_6.DTO.Shipping;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingRepository _shippingRepository;

        public ShippingController(IShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sp = await _shippingRepository.GetAll();
            return Ok(sp);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var sp = await _shippingRepository.GetById(id);
            if (sp == null)
            {
                return NotFound();
            }
            return Ok(sp);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] ShippingDto shippingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sp = await _shippingRepository.Create(shippingDto);
            return Ok(sp);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ShippingDto shippingDto)
        {
            var sp = await _shippingRepository.GetById(id);
            if (sp == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var spModel = await _shippingRepository.Update(id, shippingDto);
            return Ok("Đã cập nhật thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var sp = await _shippingRepository.GetById(id);
            if (sp == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var spModel = await _shippingRepository.DeleteById(id);
            return Ok("Đã xóa thành công !");
        }
    }
}
