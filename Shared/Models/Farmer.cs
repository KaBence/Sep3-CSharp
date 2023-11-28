namespace Shared.Models;

public class Farmer
{
    public string Phonenumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public bool Pesticides { get; set; }
    public string FarmName { get; set; }
    public double Rating { get; set; }

    public string toString()
    {
        if (Pesticides)
        {
            return $"{FarmName}: {Rating}, using Pesticides";
        }

        return $"{FarmName}: {Rating}, not using Pesticides";
    }
}