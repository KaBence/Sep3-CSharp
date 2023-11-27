namespace Shared.DTOs.Search;

public class SearchProductDto
{
    public string? Type { get; set; }
    public double? Price { get; set; }
    public double? Amount { get; set; }

    public SearchProductDto()
    {
    }

    public SearchProductDto(string? type, double? price, double? amount)
    {
        Type = type;
        Price = price;
        Amount = amount;
    }
    
}