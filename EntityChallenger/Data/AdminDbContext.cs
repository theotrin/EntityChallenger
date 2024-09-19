using EntityChallenger.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityChallenger.Data;

public class AdminDbContext : IdentityDbContext<Admin>
{
    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
    {
    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

}
