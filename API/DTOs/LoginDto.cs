using System.ComponentModel.DataAnnotations;

namespace API.DTOs;


public class LoginDto{
    public required String Username { get; set; }

    public required String Password { get; set; }

    
}