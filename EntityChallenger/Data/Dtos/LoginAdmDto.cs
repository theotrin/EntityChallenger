using System.ComponentModel.DataAnnotations;

namespace EntityChallenger.Data.Dtos;

public class LoginAdmDto
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}
