using Microsoft.AspNetCore.Identity;

namespace EntityChallenger.Model;

public class Admin : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public Admin() : base()
    {
        
    }
}
