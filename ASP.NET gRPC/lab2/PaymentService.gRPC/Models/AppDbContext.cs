namespace PaymentService.gRPC.Models;

public class AppDbContext
{
    public List<User> Users = new List<User>
    {
        new User { Id = 1, Balance = 5 },
        new User { Id = 2, Balance = 10 },
        new User { Id = 3, Balance = 20 }
    };
}