namespace Shared.DTOs;

public class RegisterCustomerDto
{

    public string Phonenumber { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    
    public RegisterCustomerDto(string phonenumber, string password, string repeatPassword,string firstName, string lastName, string address)
    {
        Phonenumber = phonenumber;
        Password = password;
        RepeatPassword = repeatPassword;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
}