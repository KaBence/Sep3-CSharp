namespace Shared.DTOs.Create;

public class ProductCreateDto
{
    public string Type { get; set; }
    public double Price { get; set; }
    public string PickedDate { get; set; }
    public string ExpirationDate { get; set; }
    public string FarmerID { get; set; }
    public double Amount { get; set; }

    public ProductCreateDto(string type, double price, string pickedDate, string expirationDate, string farmerId, double amount)
    {
        Type = type;
        Price = price;
        PickedDate = pickedDate;
        ExpirationDate = expirationDate;
        FarmerID = farmerId;
        Amount = amount;
    }

    public ProductCreateDto()
    {
    }
}