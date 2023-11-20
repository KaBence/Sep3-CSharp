using Shared.Models;
using Sep;
namespace Shared.DTOs;


public class DTOFactory
{
    //convert from dto to object and other

    public static DtoRegisterCustomer ToDtoCustomer(Customer x)
    {
        var DtoRegisterCustomer = new DtoRegisterCustomer
        {
            PhoneNumber = x.Phonenumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address
        };
        return DtoRegisterCustomer;
    }
}