namespace OrderSystem;

public class SmtpEmailSender : IEmailSender
{ 
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine($"[SMTP] {to}"); 
    }
}