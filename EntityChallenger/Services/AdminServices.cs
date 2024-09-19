using AutoMapper;
using EntityChallenger.Data.Dtos;
using EntityChallenger.Model;
using Microsoft.AspNetCore.Identity;

namespace EntityChallenger.Services;

public class AdminServices
{
    private TokenService _tokenService;
    private SignInManager<Admin> _signInManager;
    private IMapper _mapper;
    private UserManager<Admin> _userManager;

    public AdminServices(IMapper mapper, UserManager<Admin> userManager, TokenService tokenService, SignInManager<Admin> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    public SignInManager<Admin> SignInManager { get => _signInManager; set => _signInManager = value; }

    public async Task Cadastra(CreateAdminDto dto)
    {
        Admin admin = _mapper.Map<Admin>(dto);

        IdentityResult result = await _userManager.CreateAsync(admin, dto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastar usuário!");
        }
    }

    public async Task<string> Login(LoginAdmDto dto)
    {
        var resultado = await SignInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha no Login");
        }

        var usuario = SignInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario!);

        return token;
    }
}
