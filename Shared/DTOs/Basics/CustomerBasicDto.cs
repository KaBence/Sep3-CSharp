namespace Shared.DTOs.Basics;

public class CustomerBasicDto
{
    public string PhoneNumber { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    public CustomerBasicDto(string phoneNumber, string firstName, string lastName, string address)
    {
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
}