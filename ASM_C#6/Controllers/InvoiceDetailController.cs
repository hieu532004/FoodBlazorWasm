using ASM_C_6.DTO.InvoiceDetail;
using ASM_C_6.Interface;
using ASM_C_6.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailController(InvoiDetailRepository invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ivd = await _invoiceDetailRepository.GetAll();
            return Ok(ivd);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ivd = await _invoiceDetailRepository.GetById(id);
            if (ivd == null)
            {
                return NotFound();
            }
            return Ok(ivd);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] InvoiceDetailDto invoiceDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ivd = await _invoiceDetailRepository.Create(invoiceDetailDto);
            return Ok(ivd);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] InvoiceDetailDto invoiceDetailDto)
        {
            var ivd = await _invoiceDetailRepository.GetById(id);
            if (ivd == null)
            {
                return BadRequest("Không tìm thấy id !");

            }
            var ivdModel = await _invoiceDetailRepository.Update(id, invoiceDetailDto);
            return Ok("Đã cập nhật thành công !");
        }
    }
}
