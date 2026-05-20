namespace OrderSystem;

public class PremiumDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscount(Order order)
    {
        return 0.10m;
    }
}