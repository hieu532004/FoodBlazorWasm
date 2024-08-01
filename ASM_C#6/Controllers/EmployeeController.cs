using ASM_C_6.DTO.Employee;
using ASM_C_6.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASM_C_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emp = await _employeeRepository.GetAll();
            return Ok(emp);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var emp = await _employeeRepository.GetById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emp = await _employeeRepository.Create(employeeDto);
            return Ok(emp);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, EmployeeDto employeeDto)
        {
            var emp = await _employeeRepository.GetById(id);
            if (emp == null)
            {
                return BadRequest("Không tim thấy id");
            }
            var empModel = await _employeeRepository.Update(id, employeeDto);
            return Ok("Đã cập nhật thành công");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var emp = await _employeeRepository.GetById(id);
            if (emp == null)
            {
                return BadRequest("Không tìm thấy id !");
            }
            var empModel = await _employeeRepository.DeleteById(id);
            return Ok("Đã xóa thành công");
        }
    }
}