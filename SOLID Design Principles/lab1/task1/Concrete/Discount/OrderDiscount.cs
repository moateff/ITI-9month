namespace OrderSystem;

public class OrderDiscount
{
    private readonly IDiscountStrategy _discountStrategy;
    public OrderDiscount(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal CalculateDiscount(Order order)
    {
        var discount = _discountStrategy.GetDiscount(order);
        return order.TotalAmount - (order.TotalAmount * discount);
    }
}