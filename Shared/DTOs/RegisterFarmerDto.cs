namespace Shared.DTOs;

public class RegisterFarmerDto
{
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public bool Pesticides { get; set; }
 

    public RegisterFarmerDto(string phoneNumber, string password, string repeatPassword, string firstName,
        string lastName, string address, bool pesticides)
    {
        PhoneNumber = phoneNumber;
        Password = password;
        RepeatPassword = repeatPassword;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Pesticides = pesticides;
    }
    
}