namespace OrderSystem;

public class BulkDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscount(Order order)
    {
        return 0.20m;
    }
}