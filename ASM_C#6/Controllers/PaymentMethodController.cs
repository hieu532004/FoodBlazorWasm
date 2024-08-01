using ASM_C_6.DTO.PaymentMethod;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            var pmm = await _paymentMethodRepository.GetAll();
            return Ok(pmm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBById([FromRoute] int id)
        {
            var pmm = await _paymentMethodRepository.GetById(id);
            if (pmm == null)
            {
                return NotFound();
            }
            return Ok(pmm);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] PaymentMethodDto paymentMethodDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pmm = await _paymentMethodRepository.Create(paymentMethodDto);
            return Ok(pmm);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaymentMethodDto paymentMethodDto)
        {
            var pmm = await _paymentMethodRepository.GetById(id);
            if (pmm == null)
            { return BadRequest("Không tìm thấy id !"); }

            var pmmModel = await _paymentMethodRepository.Update(id, paymentMethodDto);
            return Ok("Đã cập nhật thành công !");
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var pmm = await _paymentMethodRepository.GetById(id);
            if (pmm == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var pmmModel = await _paymentMethodRepository.DeleteById(id);
            return Ok("Đã xóa thành công !");
        }
    }
}
