namespace Shared.DTOs;

public class EditFarmerDto
{
    public string PhoneNumber { get; } 
    public string? Password { get; set; }
    public string RepeatPassword { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public bool? Pesticides { get; set; }
    public string? FarmName { get; set; }
   
    
   

    public EditFarmerDto(string phoneNumber, string password, string repeatPassword, string firstName, string lastName, string address, bool pesticides, string farmName)
    {
        PhoneNumber = phoneNumber;
        Password = password;
        RepeatPassword = repeatPassword;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Pesticides = pesticides;
        FarmName = farmName;
    }

    public EditFarmerDto()
    {
        
    }
}