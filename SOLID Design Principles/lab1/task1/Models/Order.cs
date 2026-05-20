namespace OrderSystem;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerEmail { get; set; } = string.Empty;
    public OrderType OrderType { get; set; } = OrderType.Standard; 
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}