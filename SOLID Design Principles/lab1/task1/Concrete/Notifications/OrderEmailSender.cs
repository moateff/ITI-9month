namespace OrderSystem;

public class OrderEmailSender : IOrderNotifier, IOrderEmailSender
{
    private readonly IEmailSender _emailer;

    public OrderEmailSender(IEmailSender emailer)
    {
        _emailer = emailer;
    }

    public void SendConfirmationEmail(Order order)
    {
        _emailer.Send(order.CustomerEmail, $"Order {order.Id} Confirmed", "...");
    }
}