namespace OrderSystem;

public interface IOrderEmailSender
{
    void SendConfirmationEmail(Order order); 
}