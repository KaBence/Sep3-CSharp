namespace Shared.DTOs;

public class EditUserDto
{
    public string PhoneNumber { get; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public bool? Pesticides { get; set; }
    public string? FarmName { get; set; }
    
    public string? Password { get; set; }
    public string RepeatPassword { get; set; }

    public EditUserDto(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
}