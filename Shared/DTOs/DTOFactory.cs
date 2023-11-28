using Shared.Models;
using Sep;
using Shared.DTOs.Create;
using Shared.DTOs.Search;

namespace Shared.DTOs;


public class DTOFactory
{
    //** Creating The Dtos **\\ 
    
    //** Users **\\ 

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
    public static DtoRegisterCustomer ToDtoCustomerForEditing(EditCustomerDto x)
    {
        var DtoRegisterCustomer = new DtoRegisterCustomer
        {
            PhoneNumber = x.PhoneNumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address
        };
        return DtoRegisterCustomer;
    }
    public static DtoRegisterFarmer ToDtoFarmerForEditing(EditFarmerDto x)
    {
        var DtoRegisterFarmer = new DtoRegisterFarmer
        {
            PhoneNumber = x.PhoneNumber,
            Password = x.Password,
            RepeatPassword = x.RepeatPassword,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Address = x.Address,
            FarmName = x.FarmName,
            Pesticides = x.Pesticides
            
        };
        return DtoRegisterFarmer;
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

    public static Customer toCustomer(DtoCustomer x)
    {
        var customer = new Customer
        {
            Address = x.Address,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Phonenumber = x.PhoneNumber
        };
        return customer;
    }

    public static Farmer toFarmer(DtoFarmer x)
    {
        var farmer = new Farmer
        {
            Phonenumber = x.PhoneNumber,
            Address = x.Address,
            FirstName = x.FirstName,
            LastName = x.LastName,
            FarmName = x.FarmName,
            Pesticides = x.Pesticides,
            Rating = x.Rating

        };
        return farmer;
    }
    
    
    //** Products **\\ 
    
    public static DtoProduct toDtoProduct(ProductCreateDto x)
    {
        return new DtoProduct
        {
            Amount = x.Amount,
            ExpirationDate = x.ExpirationDate,
            FarmerId = x.FarmerID,
            PickedDate = x.PickedDate,
            Price = x.Price,
            Type = x.Type
        };
    }

    public static Product toProduct(DtoProduct dto)
    {
        return new Product
        {
            Amount = dto.Amount,
            Availability = dto.Availability,
            ExpirationDate = dto.ExpirationDate,
            FarmerID = dto.FarmerId,
            PickedDate = dto.PickedDate,
            Price = dto.Price,
            ProductID = dto.Id,
            Type = dto.Type
        };
    }

   /* public static ProductSearchParameters ToProductSearchParameters(SearchProductDto x)
    {
        return new ProductSearchParameters
        {
            Amount = x.Amount,
            Price = x.Price,
            Type = x.Type ?? ""
        };
    }*/

    //** Creating the requests ** \\
    
    //** Users **\\ 
    
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

    public static getAllCustomersRequest CreateGetAllCustomersRequest()
    {
        return new getAllCustomersRequest();
    }

    public static getAllFarmersRequest CreateGetAllFarmersRequest(SearchFarmerDto dto)
    {
        int pestTemp = 0;
        if (dto.Pesticides==null)
        {
            pestTemp = 0;
        }
        else if (dto.Pesticides==true)
        {
            pestTemp = 1;
        }
        else
        {
            pestTemp = 2;
        }

        return new getAllFarmersRequest
        {
            Pesticides =  pestTemp, //will this not make a problem with filtering?
            FarmName = dto.FarmName ?? "",
            Rating = dto.Rating ?? 0
        };
    }
    public static getCustomerByPhoneRequest CreateGetCustomerByPhoneRequest(string phoneNumber)
    {
        return new getCustomerByPhoneRequest
        {
            CustomersPhone = phoneNumber
        };
    }

    public static getFarmerByPhoneRequest CreateGetFarmerByPhoneRequest(string phoneNumber)
    {
        return new getFarmerByPhoneRequest
        {
            FarmersPhone = phoneNumber
        };
    }

    public static editCustomerRequest CreateEditCustomerRequest(DtoRegisterCustomer dto)
    {
        return new editCustomerRequest
        {
            EditedCustomer = dto
        };
    }

    public static editFarmerRequest CreateEditFarmerRequest(DtoRegisterFarmer dto)
    {
        return new editFarmerRequest
        {
            EditedFarmer = dto
        };
    }
    
    
    //** Products **\\ 

    public static createProductRequest CreateProductRequest(DtoProduct dto)
    {
        return new createProductRequest
        {
            NewProduct = dto
        };
    }

    public static getAllProductsRequest CreateGetAllProductsRequest(SearchProductDto dto)
    {
        return new getAllProductsRequest
        {
            Type = dto.Type ?? "",
            Amount = dto.Amount ?? 0.0,
            Price = dto.Price ?? 0.0
        };
    }

    public static getProductByIdRequest CreateGetProductByIdRequest(int id)
    {
        return new getProductByIdRequest
        {
            Id = id
        };
    }
    
    public static getAllProductsByFarmerRequest CreateGetProductByFarmerRequest(string id)
    {
        return new getAllProductsByFarmerRequest()
        {
            Farmer = id
        };
    }

    public static updateProductRequest CreateUpdateProductRequest(DtoProduct dto)
    {
        return new updateProductRequest
        {
            Product = dto
        };
    }
    
    public static deleteProductRequest DeleteProductRequest(int id)
    {
        return new deleteProductRequest
        {
            Id = id
        };
    }
}