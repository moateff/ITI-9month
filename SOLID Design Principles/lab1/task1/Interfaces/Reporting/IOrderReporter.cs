namespace OrderSystem;

public interface IOrderReporter
{
    string GenerateReport(IEnumerable<Order> orders); 
    string ExportToCsv(IEnumerable<Order> orders);
}