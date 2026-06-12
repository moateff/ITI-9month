using Grpc.Core;
using PaymentService.gRPC;
using InventoryService.gRPC;

namespace OrderingService.API.Services;
public class OrderService : Order.OrderBase
{
    private readonly Payment.PaymentClient _payment;
    private readonly Inventory.InventoryClient _inventory;

    private readonly ILogger<OrderService> _logger;

    public OrderService(
        Payment.PaymentClient payment,
        Inventory.InventoryClient inventory,
        ILogger<OrderService> logger)
    {
        _payment = payment;
        _inventory = inventory;
        _logger = logger;
    }

    public override Task<OrderResponse> Create(OrderRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Order started for UserId: {UserId}", request.UserId);
        
        var items = new List<InventoryService.gRPC.Item>();
        var totalPrice = 0;

        foreach (var item in request.Items)
        {
            _logger.LogInformation(
                "Adding item {ItemId} with quantity {Quantity} and price {Price}",
                item.Id, item.Quantity, item.Price);

            items.Add(new InventoryService.gRPC.Item
            {
                Id = item.Id,
                Quantity = item.Quantity
            });

            totalPrice += item.Price * item.Quantity;
        }

        _logger.LogInformation("Total price calculated: {TotalPrice}", totalPrice);

        _logger.LogInformation("Calling Inventory service...");

        var inventoryResult = _inventory.Deduct(new InventoryService.gRPC.DeductRequest
        {
            Items = { items }
        });

        if (!inventoryResult.Success)
        {
            _logger.LogError("Inventory failed: {Message}", inventoryResult.Message);
            
            return Task.FromResult(new OrderResponse
            {
                Success = false,
                Message = inventoryResult.Message
            });
        }

        _logger.LogInformation("Calling Payment service...");
        var paymentResult = _payment.Deduct(new PaymentService.gRPC.DeductRequest
        {
            Id = request.UserId,
            TotalPrice = totalPrice
        });

        if (!paymentResult.Success)
        {
            _logger.LogError("Payment failed: {Message}", paymentResult.Message);
            
            var rollbackResult = _inventory.Rollback(new InventoryService.gRPC.DeductRequest
            {
                Items = { items }
            });

            if (!rollbackResult.Success)
            {
                _logger.LogError("Inventory rollback failed: {Message}", rollbackResult.Message);
            }
            else
            {
                _logger.LogInformation("Inventory rollback successful");
            }

            return Task.FromResult(new OrderResponse
            {
                Success = false,
                Message = paymentResult.Message
            });
        }

        
        _logger.LogInformation("Payment successful for UserId: {UserId}", request.UserId);

        _logger.LogInformation("Order completed successfully");


        return Task.FromResult(new OrderResponse
        {
            Success = true,
            Message = "Order created successfully"
        });
    }
}