using ASM_C_6.DTO.Customer;
using ASM_C_6.DTO.Employee;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustormerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustormerController (ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ctm = await _customerRepository.GetAll();
            return Ok(ctm);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var ctm = await _customerRepository.GetById(id);
            if (ctm == null)
            {
                return NotFound("Không tim thấy id");
            }
            return Ok(ctm);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody]CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cmt = await _customerRepository.Create(customerDto);
            return Ok(cmt);
            
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CustomerDto customerDto)
        {
            var ctm = await _customerRepository.GetById(id);
            if(ctm == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var ctmModel = await _customerRepository.Update(id, customerDto);
            return Ok("Đã cập nhật thành công !");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute]int id)
        {
            var ctm = await _customerRepository.GetById(id);
            if (ctm == null)
            {
                return BadRequest("không tìm thấy id !");
            }
            var ctmDele = await _customerRepository.DeleteById(id); 
            return Ok("Đã xóa thành công !");
        }   
    }
}
