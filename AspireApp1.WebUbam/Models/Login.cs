using System.ComponentModel.DataAnnotations;

namespace AspireApp1.WebUbam.Models;

public class Login
{
    [Required]
    [Display(Name = "Usuario")]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Contraseña")]
    public string Password { get; set; }
    
}