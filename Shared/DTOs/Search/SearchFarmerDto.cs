namespace Shared.DTOs.Search;

public class SearchFarmerDto
{
    public bool? Pesticides { get; set; }
    public string? FarmName { get; set; }
    public double? Rating { get; set; }

    public SearchFarmerDto(bool? pesticides, string? farmName, double? rating)
    {
        Pesticides = pesticides;
        FarmName = farmName;
        Rating = rating;
    }
    
    public SearchFarmerDto() { }
}