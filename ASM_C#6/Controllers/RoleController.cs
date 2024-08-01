using ASM_C_6.DTO.Role;
using ASM_C_6.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/role")]
[ApiController]
public class RoleController : Controller
{
    private readonly IRoleRepository _roleRepository;

    public RoleController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    [Authorize(Policy = "AdminPolicy")]
    [HttpPost("admin/create")]
    public IActionResult CreateAdminOnly()
    {
        // Logic chỉ được thực thi nếu người dùng có vai trò Admin
        return Ok("Admin action executed successfully.");
    }

    //  [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var role = await _roleRepository.GetAll();
        var roleDtos = role.Select(s => s.ToRoleDto());
        return Ok(role);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var role = await _roleRepository.GetById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] RoleDto roleDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var role = await _roleRepository.Create(roleDto);
        return Ok(role);
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RoleDto roleDto)
    {
        var role = await _roleRepository.GetById(id);
        if (role == null)
        {
            return BadRequest("không tìm thấy id");
        }
        var rolemodel = await _roleRepository.Update(id, roleDto);
        return Ok("Đả cập nhật thành công");
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        var role = await _roleRepository.GetById(id);
        if (role == null)
        {
            return BadRequest("không tìm thấy id");
        }
        var roleModels = await _roleRepository.DeleteById(id);
        return Ok("Đả xóa thành công");
    }


}
