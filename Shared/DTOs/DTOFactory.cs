﻿using Google.Protobuf.Collections;
using Shared.Models;
using Sep;
using Shared.DTOs.Basics;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.DTOs.Update;

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
    

    public static Receipt toReceipt(DtoReceipt x)
    {
        return new Receipt
        {
            CustomerID = x.CustomerId,
            FarmerID = x.FarmerId,
            OrderID = x.OrderId,
            PaymentDate = x.PaymentDate,
            PaymentMethod = x.PaymentMethod,
            price = x.Price,
            Processed = x.Processed,
            Text = x.Text,
            status = x.Status
        };
    }

    
    //** OrderItems **\\
    
    
    public static DtoOrderItem toDtoOrderItem(OrderItem orderItem)
    {
        return new DtoOrderItem
        {
            OrderId = orderItem.OrderID,
            Amount = orderItem.Amount,
            ProductId = orderItem.ProductID,
            FarmName = orderItem.FarmerName,
            Price = orderItem.Price
        };
    }

    public static OrderItem ToOrderItem(DtoOrderItem orderItem)
    {
        return new OrderItem
        {
            OrderID = orderItem.OrderId,
            Amount = orderItem.Amount,
            ProductID = orderItem.ProductId,
            FarmerName = orderItem.FarmName,
            Price = orderItem.Price,
            Type = orderItem.Type
        };
    }
    
    
    //** Comments **\\
    
    
    public static Comment toComment(DtoComment comment)
    {
        return new Comment
        {
            CommentId = comment.CommentId,
            Text = comment.Text,
            FarmerId = comment.FarmerId,
            CustomerId = comment.CustomerId,
            OrderId = comment.OrderId,
            Username = comment.Username
        };
    }

    public static DtoComment toDtoComment(CommentCreateDto dto)
    {
        return new DtoComment
        {
            CustomerId = dto.CustomerId,
            FarmerId = dto.FarmerId,
            Text = dto.Text,
            OrderId = dto.OrderId,
            Username = dto.Username
        };
    }
    
    
    //** Reviews **\\
    
    
    public static DtoReview toDtoReview(ReviewCreateDto review)
    {
        return new DtoReview
        {
            CustomerId = review.CustomerId,
            FarmerId = review.FarmerId,
            Star = review.Star,
            Text = review.Text,
            OrderId = review.OrderId
        };
    }
    
    public static Review toReview(DtoReview dto)
    {
        List<Comment> comments = new List<Comment>();
        for (int i = 0; i < dto.Comments.Count; i++)
        {
            comments.Add(toComment(dto.Comments[i]));
        }
        return new Review
        {
            FarmerID = dto.FarmerId,
            CustomerID = dto.CustomerId,
            Star = dto.Star,
            Text = dto.Text,
            OrderId = dto.OrderId,
            Comments = comments
        };
    }

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
        if (dto.Pesticides == null)
        {
            pestTemp = 0;
        }
        else if (dto.Pesticides == true)
        {
            pestTemp = 1;
        }
        else
        {
            pestTemp = 2;
        }

        return new getAllFarmersRequest
        {
            Pesticides = pestTemp,
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
    
    
    //**receipts**\\ 
    
    
    public static getReceiptsByCustomerRequest CreateGetReceiptsByCustomerRequest(string customerId)
    {
        return new getReceiptsByCustomerRequest
        {
            Customer = customerId
        };
    }

    public static getPendingReceiptsByFarmerRequest CreateGetPendingReceiptsByFarmerRequest(string farmerId)
    {
        return new getPendingReceiptsByFarmerRequest
        {
            Farmer = farmerId
        };
    }

    public static getApprovedReceiptsByFarmerRequest CreateGetApprovedReceiptsByFarmerRequest(string farmerId)
    {
        return new getApprovedReceiptsByFarmerRequest
        {
            Farmer = farmerId
        };
    }

    public static getRejectedReceiptsByFarmerRequest CreateGetRejectedReceiptsByFarmerRequest(string farmerID)
    {
        return new getRejectedReceiptsByFarmerRequest
        {
            Farmer = farmerID
        };
    }
    //**Product**\\
    public static getProductByIdRequest CreateGetProductByIdRequest(int id)
    {
        return new getProductByIdRequest
        {
            Id = id
        };
    }

    public static getAllProductsByFarmerRequest CreateGetProductByFarmerRequest(string id, SearchProductDto dto)
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
        for (int i = 0; i < dto.OrderItems.Count(); i++)
        {
            orderItems.Add(toDtoOrderItem(dto.OrderItems.ElementAt(i)));
        }

        return new createOrderRequest
        {
 
            NewOrder = toDtoOrder(dto),
            OrderItems = { orderItems },
            Note = dto.Note,
            PaymentMethod = dto.PaymentMethod
            
        };
    }

    public static farmersApprovalRequest acceptOrder(AcceptOrder order)
    {
        return new farmersApprovalRequest
        {
            Approve = order.approve,
            OrderId = order.orderId
        };
    }

    public static getAllOrderItemsFromOrderRequest CreateGetAllOrderItemsFromOrderRequest(int orderId)
    {
        return new getAllOrderItemsFromOrderRequest
        {
            OrderId = orderId
        };
    }

    public static getAllOrderItemsByGroupRequest CreateGetAllOrderItemsByGroupRequest(int orderId)
    {
        return new getAllOrderItemsByGroupRequest
        {
            OrderId = orderId
        };
    }
    
    //** Comment **\\
    public static putCommentRequest PostCommentRequest(DtoComment x)
    {
        return new putCommentRequest
        {
            Comment = x
        };
    }
    
    //** Reviews **\\ 
    public static postReviewRequest CreatePostReviewRequest(DtoReview x)
    {
        return new postReviewRequest
        {
            Review = x
        };
    }

    public static getAllReviewsByFarmerRequest CreateGetAllReviewsByFarmerRequest(string x)
    {
        return new getAllReviewsByFarmerRequest
        {
            Farmer = x
        };
    }
}