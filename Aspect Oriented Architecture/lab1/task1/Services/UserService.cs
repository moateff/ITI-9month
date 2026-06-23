using task1.Interfaces;
using task1.Aspects;

namespace task1.Services;

public class UserService : IUserService
{
    [LoggingAspect]
    public string GetUser(int id)
    {
        Thread.Sleep(100);
        return $"User {id}";
    }
}