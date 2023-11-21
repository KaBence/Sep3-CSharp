using Shared.Models;
using Sep;
namespace Shared.DTOs;


public class DTOFactory
{
    //convert from dto to object and other

    public static DtoRegisterCustomer ToDtoCustomer(RegisterCustomerDto x)
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

    public static DtoRegisterFarmer ToDtoFarmer(RegisterFarmerDto x)
    {
        var DtoRegisterFarmer = new DtoRegisterFarmer
        {
            PhoneNumber = x.PhoneNumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address,
            Pesticides = x.Pesticides,
            FarmName = x.FarmName
        };
        return DtoRegisterFarmer;
    }

    public static DtoLogin toDtoLogin(LoginDto x)
    {
        var dtoLogin = new DtoLogin
        {
            Password = x.Password,
            PhoneNumber = x.Phonenumber
        };
        return dtoLogin;
    }

    public static loginRequest CreateLoginRequest(DtoLogin dto)
    {
        return new loginRequest
        {
            Login = dto
        };
    }

    public static registerCustomerRequest CreateRegisterCustomerRequest(DtoRegisterCustomer dto)
    {
        return new registerCustomerRequest
        {
            NewCustomer = dto
        };
    }

    public static registerFarmerRequest CreateRegisterFarmerRequest(DtoRegisterFarmer dto)
    {
        return new registerFarmerRequest
        {
            NewFarmer = dto
        };
    }
}