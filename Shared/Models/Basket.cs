namespace Shared.Models;

public class Basket
{
    private IEnumerable<OrderItem> list;
    public static  Basket instance;

    private Basket()
    {
        list = new List<OrderItem>();
        
    }

    public static Basket getInstance()
    {
        if (instance == null)
        {
            instance = new Basket();
        }

        return instance;
    }
    
    //get items from the list
    //add item to the list
    //delete item from there
    
}