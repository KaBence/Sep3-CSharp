namespace Shared.Models;

public class Review
{
    public string Text { get; set; }
    public double Star { get; set; }
    public string FarmerID { get; set; }
    public string CustomerID { get; set; }
    
    public IEnumerable<Comment> Comments { get; set; }
}