using Google.Protobuf.Collections;
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
    
    //** Orders **\\
    public static DtoOrder toDtoOrder(OrderCreateDto order)
    {
        return new DtoOrder
        {
            CustomerId = order.CustomerID,
        };
    }
    
    //** Receipts **\\ 
    
    public static DtoReceipt toDtoReceipt(ReceiptCreateDto x)
    {
        return new DtoReceipt
        {
            Amount = x.Amount,
            Price = x.Price,
            PaymentMethod = x.PaymentMethod,
            PaymentDate = x.PaymentDate,
            Text = x.Text,
            FarmerId = x.FarmerId,
            CustomerId = x.CustomerId
        };
    }

    public static Order toOrder(DtoOrder order)
    {
        return new Order
        {
            CustomerID = order.CustomerId,
            Date = order.Date,
            OrderID = order.OrderId,
            Status = order.Status
        };
    }
    
    //** OrderItems **\\
    public static DtoOrderItem toDtoOrderItem(OrderItem orderItem)
    {
        return new DtoOrderItem
        {
            OrderId = orderItem.OrderID,
            Amount = orderItem.Amount,
            ProductId = orderItem.ProductID
        };
    }

    public static OrderItem ToOrderItem(DtoOrderItem orderItem)
    {
        return new OrderItem
        {
            OrderID = orderItem.OrderId,
            Amount = orderItem.Amount,
            ProductID = orderItem.ProductId
        };
    }

    public static Receipt toReceipt(DtoReceipt dto)
    {
        return new Receipt
        {
           OrderID = dto.OrderId,
           CustomerID = dto.CustomerId,
           FarmerID = dto.FarmerId,
           amount = dto.Amount,
           PaymentDate = dto.PaymentDate,
           PaymentMethod = dto.PaymentMethod,
           price = dto.Price,
           Text = dto.Text
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
    
    public static getAllProductsByFarmerRequest CreateGetProductByFarmerRequest(string id,SearchProductDto dto)
    {
        return new getAllProductsByFarmerRequest()
        {
            Farmer = id,
            Type = dto.Type ?? "",
            Amount = dto.Amount ?? 0.0,
            Price = dto.Price ?? 0.0
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
    
    //** Orders **\\
    
    public static createOrderRequest CreateOrderRequest(OrderCreateDto dto)
    {
        RepeatedField<DtoOrderItem> orderItems = new RepeatedField<DtoOrderItem>();
        for (int i = 0; i < dto.OrderItems.Count; i++)
        {
            orderItems.Add(toDtoOrderItem(dto.OrderItems[i]));
        }
        return new createOrderRequest
        {
            NewOrder = toDtoOrder(dto),
            OrderItems = { orderItems },
            Note = dto.Note,
            PaymentMethod = dto.PaymentMethod
        };
    }
    
    
    //** Receipts **\\ 
    
    public static createReceiptRequest CreateReceiptRequest(DtoReceipt dto)
    {
        return new createReceiptRequest
        {
            NewReceipt = dto
        };
    }

    public static getAllReceiptsRequest CreateGetAllReceiptsRequest(SearchReceiptDto dto)
    {
        return new getAllReceiptsRequest
        {
            User = dto.CustomerID
        };
    }

    public static getReceiptByIdRequest CreateGetReceiptByIdRequest(SearchReceiptDto dto)
    {
        return new getReceiptByIdRequest
        {
            OrderId = dto.OrderID,
            CustomerId = dto.CustomerID,
            FarmerId = dto.FarmerID
        };
    }
    
    
}