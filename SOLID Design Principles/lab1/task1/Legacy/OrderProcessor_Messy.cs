namespace OrderSystem_Messy;

// ── Entities ────────────────────────────────────────────
public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerEmail { get; set; } = string.Empty;
    public string OrderType { get; set; } = string.Empty; // "Standard", "Premium", "Bulk"
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

// ── [VIOLATION 1: ISP] One fat interface forces ALL methods on every implementor
public interface IOrderService
{
    void ProcessOrder(Order order); // processing concern
    void SendConfirmationEmail(Order order); // notification concern
    string GenerateReport(IEnumerable<Order> orders); // reporting concern
    string ExportToCsv(IEnumerable<Order> orders); // export concern
}

// ── [VIOLATION 2: SRP + DIP] God class with 5 responsibilities
public class OrderProcessor : IOrderService
{
    // [VIOLATION 3: DIP] Hardcoded concrete dependencies
    private readonly SqlOrderStorage _storage = new SqlOrderStorage();
    private readonly SmtpEmailSender _emailer = new SmtpEmailSender();
    private readonly FileOrderLogger _logger = new FileOrderLogger();

    public void ProcessOrder(Order order)
    {
        _logger.Log($"Processing order {order.Id}");

        // Responsibility: Validation (should be a separate class)
        if (order.Items.Count == 0) { _logger.Log("No items."); return; }
        if (string.IsNullOrWhiteSpace(order.CustomerEmail)) { return; }

        // Responsibility: Discount calculation
        var discount = GetDiscount(order);
        var finalAmount = order.TotalAmount - (order.TotalAmount * discount);

        // Responsibility: Persist
        _storage.Save(order);
        
        // Responsibility: Notify
        SendConfirmationEmail(order);
    }
    
    // [VIOLATION 4: OCP] Every new order type = edit this method
    private decimal GetDiscount(Order order)
    {
        if (order.OrderType == "Standard") return 0.00m; // edit here for new types
        else if (order.OrderType == "Premium") return 0.10m;
        else if (order.OrderType == "Bulk")
        return 0.20m;
        else return 0.00m;
    }
    
    public void SendConfirmationEmail(Order order) =>
        _emailer.Send(order.CustomerEmail, $"Order {order.Id} Confirmed", "...");
    
    public string GenerateReport(IEnumerable<Order> orders) =>
        $"Orders: {orders.Count()} | Revenue: {orders.Sum(o => o.TotalAmount):C}";
    
    public string ExportToCsv(IEnumerable<Order> orders) =>
        string.Join("\n", orders.Select(o => $"{o.Id},{o.CustomerEmail}, {o.TotalAmount}"));
}

// ── [VIOLATION 5: LSP] ArchiveOrderStorage breaks base class contract
public class SqlOrderStorage
{
    public virtual void Save(Order o) => Console.WriteLine($"[SQL] Saved {o.Id}");
    public virtual IEnumerable<Order> GetAll() => Enumerable.Empty<Order>();
}

public class ArchiveOrderStorage : SqlOrderStorage // read-only, yet inherits Save()
{
    public override void Save(Order order)
        // BREAKS the contract!
        => throw new NotSupportedException("Read-only archive — Save() not supported.");

    public override IEnumerable<Order> GetAll() =>
        Enumerable.Empty<Order>(); // simulates fetching from archive
}

// ── Concrete infrastructure classes ──────────────────────
public class SmtpEmailSender { public void Send(string to, string sub, string body)
    => Console.WriteLine($"[SMTP] {to}"); }

public class FileOrderLogger { public void Log(string msg) =>
    Console.WriteLine($"[LOG] {msg}"); }