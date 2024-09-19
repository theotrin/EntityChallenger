using EntityChallenger.Data.Dtos;
using EntityChallenger.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityChallenger.Controllers;

[ApiController]
[Route("[Controller]")]
public class AdminController : ControllerBase
{
    private AdminServices _adminService;

    public AdminController(AdminServices adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CreateAdmin(CreateAdminDto dto)
    {
        await _adminService.Cadastra(dto);
        return Ok("Usuario Cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginAdmDto dto)
    {
        var token = await _adminService.Login(dto);
        return Ok(token);

    }
}
