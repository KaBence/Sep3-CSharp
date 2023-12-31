﻿using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Basics;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ReceiptController: ControllerBase
{
    private readonly IReceiptLogic receiptLogic;

    public ReceiptController(IReceiptLogic receiptLogic)
    {
        this.receiptLogic = receiptLogic;
    }
    

    [HttpGet("ByCustomer/{customerId:required}")]
    public async Task<ActionResult<IEnumerable<CustomerSendReceiptDto>>> GetAllReceiptsByCustomer([FromRoute] string customerId)
    {
        try
        {
            IEnumerable<CustomerSendReceiptDto> receipts = await receiptLogic.GetAllReceiptsByCustomerAsync(customerId);
            return Ok(receipts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("PendingByFarmer/{farmerId:required}")]
    public async Task<ActionResult<IEnumerable<SendReceiptDto>>> getPendingRecieptsForFarmer(
        [FromRoute] string farmerId)
    {
        try
        {
            IEnumerable<SendReceiptDto> pendingReceipts = await receiptLogic.getPendingReceipts(farmerId);
            return Ok(pendingReceipts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("AcceptedByFarmer/{farmerId:required}")]
    public async Task<ActionResult<IEnumerable<SendReceiptDto>>> getAcceptedReciepts([FromRoute] string farmerId)
    {
        try
        {
            IEnumerable<SendReceiptDto> acceptedReceipts = await receiptLogic.getAcceptedReceipts(farmerId);
            return Ok(acceptedReceipts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("RejectedByFarmer/{farmerId:required}")]
    public async Task<ActionResult<IEnumerable<SendReceiptDto>>> getRejectedReciepts([FromRoute] string farmerId)
    {
        try
        {
            IEnumerable<SendReceiptDto> rejectedReceipts = await receiptLogic.GetRejectedReceipts(farmerId);
            return Ok(rejectedReceipts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}