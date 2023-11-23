namespace Shared.DTOs;

public class EditCustomerDto
{
    public string PhoneNumber { get; } 
    public string? Password { get; set; }
    public string RepeatPassword { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
   
    
   

    public EditCustomerDto(string phoneNumber, string password, string repeatPassword, string firstName, string lastName, string address)
    {
        PhoneNumber = phoneNumber;
        Password = password;
        RepeatPassword = repeatPassword;
        FirstName = firstName;
        LastName = lastName;
        Address = address;

    }
}