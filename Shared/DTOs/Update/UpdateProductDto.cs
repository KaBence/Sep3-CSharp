namespace Shared.DTOs.Update;

public class UpdateProductDto
{
    public int Id { get; }
    public bool Availability { get; set; }
    public double Amount { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public string PickedDate { get; set; }
    public string ExpirationDate { get; set; }

    public UpdateProductDto(int id )
    {
        Id = id;
    }
    

    public UpdateProductDto(int id, bool availability, double amount, string type, double price, string pickedDate, string expirationDate)
    {
        Id = id;
        Availability = availability;
        Amount = amount;
        Type = type;
        Price = price;
        PickedDate = pickedDate;
        ExpirationDate = expirationDate;
    }
}