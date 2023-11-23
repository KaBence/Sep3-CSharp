namespace Shared.DTOs.Basics;

public class FarmerBasicDto
{
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public bool Pesticides { get; set; }
    public string FarmName { get; set; }

    public FarmerBasicDto( string phoneNumber, string firstName, string lastname, string address, bool pesticides, string farmName)
    {
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        Lastname = lastname;
        Address = address;
        Pesticides = pesticides;
        FarmName = farmName;
    }
    
}