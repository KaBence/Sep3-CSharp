﻿using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<Order> CreateAsync(OrderCreateDto dto);
    
    Task<IEnumerable<Order>> GetAsync(SearchOrderDto searchParameters);
    Task<Order?> GetByIdAsync(int id,int customerId);

    
    Task DeleteAsync(int id);

    Task UpdateAsync(string status);
}