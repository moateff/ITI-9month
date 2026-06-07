using task1.Models;

namespace task1.ViewModels;

public class ChatViewModel
{
    public IEnumerable<Room> Rooms { get; set; } = new List<Room>();
    public IEnumerable<Message> Messages { get; set; } = new List<Message>();
    public IEnumerable<User> Users { get; set; } = new List<User>();
}