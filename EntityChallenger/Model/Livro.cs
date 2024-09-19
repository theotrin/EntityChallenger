using System.ComponentModel.DataAnnotations;

namespace EntityChallenger.Model;

public class Livro
{
    [Key]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public DateTime DataPublicacao { get; set; }
    public bool EstaEmprestado { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}
