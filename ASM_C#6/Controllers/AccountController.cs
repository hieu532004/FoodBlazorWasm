using ASM_C_6.Data;
using ASM_C_6.DTO.Account;
using ASM_C_6.Interface;
using ASM_C_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

[Route("api/accountemp")]
[ApiController]
public class AccountEmpController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IAccountRepository _accountEmpRepository;
    private readonly DataContext _dataContext;

    public AccountEmpController(IConfiguration configuration, IAccountRepository accountEmpRepository, DataContext context)
    {
        _configuration = configuration;
        _accountEmpRepository = accountEmpRepository;
        _dataContext = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var acc = await _accountEmpRepository.GetAll();
        return Ok(acc);
    }
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var acc = await _accountEmpRepository.GetById(id);
        if (acc == null)
        {
            return NotFound();
        }
        return Ok(acc);
    }


    private async Task<Account> GetUser(string username, string password)
    {
        return await _dataContext.Accounts.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await GetUser(loginDto.UserName, loginDto.Password);

        if (user != null)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new List<Claim>
                {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, "Admin")
                },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: signinCredentials
            ); ;

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }

        return Unauthorized();
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromForm] AccountDto accountEmpDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var acc = await _accountEmpRepository.Create(accountEmpDto);
        return Ok(acc);
    }
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AccountDto accountEmpDto)
    {
        var acc = await _accountEmpRepository.GetById(id);
        if (acc == null)
        {
            return BadRequest("không tìm thấy id");
        }
        var accDto = await _accountEmpRepository.Update(id, accountEmpDto);
        return Ok("Đả cập nhật thành công");
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteById([FromRoute] int id)
    {
        var acc = await _accountEmpRepository.GetById(id);
        if (acc == null)
        {
            return BadRequest("không tìm thấy id");
        }
        var accModels = await _accountEmpRepository.DeleteById(id);
        return Ok("Đả xóa thành công");
    }
}
