namespace Shared.DTOs.Update;

public class AcceptOrder
{
    public bool approve { set; get; }
    public int orderId { set; get; }

    public AcceptOrder(bool approve, int orderId)
    {
        this.approve = approve;
        this.orderId = orderId;
    }

    public AcceptOrder()
    {
    }
}