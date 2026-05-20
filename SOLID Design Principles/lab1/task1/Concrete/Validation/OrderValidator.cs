namespace OrderSystem;

public class OrderValidator : IOrderValidator
{
    private readonly IOrderLogger _logger;
    public OrderValidator(IOrderLogger logger)
    {
        _logger = logger;
    }

    public bool IsValid(Order order)
    {
        if (order.Items.Count == 0) 
        {
            _logger.Log("No items.");
            return false; 
        }

        if (string.IsNullOrWhiteSpace(order.CustomerEmail))
        {
            _logger.Log("No email.");
            return false;
        }

        return true;
    }
}