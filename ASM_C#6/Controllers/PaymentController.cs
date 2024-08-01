using ASM_C_6.DTO.Payment;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pm = await _paymentRepository.GetAll();
            return Ok(pm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var pm = await _paymentRepository.GetById(id);
            if (pm == null)
            {
                return NotFound();
            }
            return Ok(pm);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] PaymentDto paymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pm = await _paymentRepository.Create(paymentDto);
            return Ok(pm);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaymentDto paymentDto)
        {
            var pm = await _paymentRepository.GetById(id);
            if (pm == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var pmModel = await _paymentRepository.Update(id, paymentDto);
            return Ok("Đã cập nhật thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var pm = await _paymentRepository.GetById(id);
            if(pm == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var pmModel = await _paymentRepository.DeleteById(id);
            return Ok("Đã xóa thành công !");
        }
    }
}
