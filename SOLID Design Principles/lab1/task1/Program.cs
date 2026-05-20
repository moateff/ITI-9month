using OrderSystem;

var Orders = new List<Order>()
{
    new Order() 
    { 
        CustomerEmail = "ahmed@gamil.com", 
        OrderType = OrderType.Standard, 
        TotalAmount = 300, 
        Items = new List<OrderItem>()
        {
            new OrderItem() { ProductName = "T-Shirt", Quantity = 1, UnitPrice = 100 },
            new OrderItem() { ProductName = "Jeans", Quantity = 1, UnitPrice = 100 },
            new OrderItem() { ProductName = "Shoes", Quantity = 1, UnitPrice = 100 }
        }
    },
    new Order()
    {
        CustomerEmail = "mohamed@gamil.com",
        OrderType = OrderType.Premium,
        TotalAmount = 100,
        Items = new List<OrderItem>()
        {
            new OrderItem() { ProductName = "Sweater", Quantity = 1, UnitPrice = 100 },
        }
    },
    new Order()
    {
        CustomerEmail = "sara@gamil.com",
        OrderType = OrderType.Bulk,
        TotalAmount = 200,
        Items = new List<OrderItem>()
        {
            new OrderItem() { ProductName = "Shoes", Quantity = 1, UnitPrice = 100 },
            new OrderItem() { ProductName = "Pants", Quantity = 1, UnitPrice = 100 }
        }
    }
};

foreach (var order in Orders)
{
    var orderProcessor = CreateOrderProcessor(order.OrderType);
    orderProcessor.ProcessOrder(order);
}

static OrderProcessor CreateOrderProcessor(OrderType orderType)
{
    var storage = new OrderStorage(new SqlOrderStorage());
    var emailer = new OrderEmailSender(new SmtpEmailSender());
    var logger = new ConsoleOrderLogger();
    var validator = new OrderValidator(logger);
    var discount = CreateDiscoutService(orderType);
    return new OrderProcessor(storage, emailer, logger, validator, discount);
}

static OrderDiscount CreateDiscoutService(OrderType orderType)
{
    if (orderType == OrderType.Premium) return new OrderDiscount(new PremiumDiscountStrategy());
    if (orderType == OrderType.Bulk) return new OrderDiscount(new BulkDiscountStrategy());
    return new OrderDiscount(new StandardDiscountStrategy());
}