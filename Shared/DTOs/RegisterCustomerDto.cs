namespace Shared.DTOs;

public class RegisterCustomerDto
{
    public string Phonenumber { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
}