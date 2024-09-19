﻿using System.ComponentModel.DataAnnotations;

namespace EntityChallenger.Data.Dtos;

public class CreateAdminDto
{
    [Required]
    public string Username { get; set; }

    [Required] 
    public DateTime DataNascimento { get; set; }

    [Required]
    public string Cpf { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
}
