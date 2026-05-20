namespace OrderSystem;

public class OrderReportService : IOrderReporter
{
    public string GenerateReport(IEnumerable<Order> orders)
    {
        return $"Orders: {orders.Count()} | Revenue: {orders.Sum(o => o.TotalAmount):C}";
    }

    public string ExportToCsv(IEnumerable<Order> orders)
    {
        return string.Join("\n", orders.Select(o => $"{o.Id},{o.CustomerEmail}, {o.TotalAmount}"));
    }
}