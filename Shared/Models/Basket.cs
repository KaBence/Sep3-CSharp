namespace Shared.Models;

public class Basket
{
    private List<OrderItem> list;
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
    public IEnumerable<OrderItem> getItemsFromBasket()
    {
        return list;
    }
    //add item to the list
    public void AddToBasket(OrderItem item)
    {
        list.Add(item);
    }
    
    //delete item from there
    public void deleteFromBasket(OrderItem item)
    {
        list.Remove(item);
    }

    public void ClearBasket()
    {
        list.Clear();
    }
}