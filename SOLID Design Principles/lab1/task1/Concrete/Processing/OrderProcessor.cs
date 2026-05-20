namespace OrderSystem;

public class OrderProcessor : IOrderProcessor
{
    private readonly IOrderStorage _storage;
    private readonly IOrderEmailSender _emailer;
    private readonly IOrderLogger _logger;

    private readonly OrderValidator _validator;
    private readonly OrderDiscount _discount;

    public OrderProcessor(IOrderStorage orderStorage, IOrderEmailSender orderEmailSender,
        IOrderLogger logger, OrderValidator validator, OrderDiscount discount)
    {
        _storage = orderStorage;
        _emailer = orderEmailSender;
        _logger = logger;
        _validator = validator;
        _discount = discount;
    }

    public void ProcessOrder(Order order)
    {
        _logger.Log($"Processing order {order.Id}");

        if (!_validator.IsValid(order))
        {
            _logger.Log("Invalid order.");
            return;
        }

        var finalAmount = _discount.CalculateDiscount(order);

        _storage.Save(order);

        _emailer.SendConfirmationEmail(order);
    }
}