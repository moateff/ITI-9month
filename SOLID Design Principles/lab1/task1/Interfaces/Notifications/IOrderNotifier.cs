namespace OrderSystem;

public interface IOrderNotifier
{
    void SendConfirmationEmail(Order order);
}