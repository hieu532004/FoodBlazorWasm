using ASM_C_6.DTO.Invoice;
using ASM_C_6.Interface;
using ASM_C_6.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var iv = await _invoiceRepository.GetAll();
            return Ok(iv);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var iv = await _invoiceRepository.GetById(id);
            if (iv == null)
            {
                return NotFound();
            }
            return Ok(iv);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] InvoiceDto invoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var iv = await _invoiceRepository.Create(invoiceDto);
            return Ok(iv);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] InvoiceDto invoiceDto)
        {
            var iv = await _invoiceRepository.GetById(id);
            if (iv == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var ivModel = await _invoiceRepository.Update(id, invoiceDto);
            return Ok("Đã cập nhật thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var iv = await _invoiceRepository.GetById(id);
            if (iv == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var ivMoodel = await _invoiceRepository.DeleteById(id);
            return Ok("Đã xóa thành công !");
        }
    }
}
