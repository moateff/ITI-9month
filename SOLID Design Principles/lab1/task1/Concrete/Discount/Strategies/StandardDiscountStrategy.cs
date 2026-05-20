namespace OrderSystem;

public class StandardDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscount(Order order)
    {
        return 0;
    }
}