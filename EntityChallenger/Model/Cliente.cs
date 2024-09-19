using System.ComponentModel.DataAnnotations;

namespace EntityChallenger.Model;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public ICollection<Livro> Livros{ get; set; }
}
