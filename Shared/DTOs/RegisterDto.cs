namespace Shared.DTOs;

public class RegisterDto
{
    public string Phonenumber { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public bool isFarmer { get; set; }
}