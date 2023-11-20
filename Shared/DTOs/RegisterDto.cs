namespace Shared.DTOs;

public class RegisterDto
{
    public string Phonenumber { get; }
    public string Password { get; }
    public string RepeatPassword { get; }
    public bool isFarmer { get; }

    public RegisterDto(string phonenumber, string password, string repeatPassword, bool isFarmer)
    {
        Phonenumber = phonenumber;
        Password = password;
        RepeatPassword = repeatPassword;
        this.isFarmer = isFarmer;
    }
}