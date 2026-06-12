using Microsoft.AspNetCore.Mvc;
using OrderingService.API.DTOs;
using PaymentService.gRPC;
using InventoryService.gRPC;

namespace OrderingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly Payment.PaymentClient _payment;
    private readonly Inventory.InventoryClient _inventory;
    private readonly ILogger<OrderController> _logger;

    public OrderController(
        Payment.PaymentClient payment,
        Inventory.InventoryClient inventory,
        ILogger<OrderController> logger)
    {
        _payment = payment;
        _inventory = inventory;
        _logger = logger;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(OrderDto order)
    {
        _logger.LogInformation("Order started for UserId: {UserId}", order.UserId);

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for UserId: {UserId}", order.UserId);
            return BadRequest(ModelState);
        }

        var items = new List<InventoryService.gRPC.Item>();
        var totalPrice = 0;

        foreach (var item in order.Items)
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
        var inventoryResult = await _inventory.DeductAsync(new InventoryService.gRPC.DeductRequest
        {
            Items = { items }
        });

        if (!inventoryResult.Success)
        {
            _logger.LogError("Inventory failed: {Message}", inventoryResult.Message);
            return BadRequest(inventoryResult);
        }

        _logger.LogInformation("Inventory deduction successful");

        _logger.LogInformation("Calling Payment service...");
        var paymentResult = await _payment.DeductAsync(new PaymentService.gRPC.DeductRequest
        {
            Id = order.UserId,
            TotalPrice = totalPrice
        });

        if (!paymentResult.Success)
        {
            _logger.LogError("Payment failed: {Message}", paymentResult.Message);

            var rollbackResult = await _inventory.RollbackAsync(new InventoryService.gRPC.DeductRequest
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

            return BadRequest(paymentResult);
        }

        _logger.LogInformation("Payment successful for UserId: {UserId}", order.UserId);

        _logger.LogInformation("Order completed successfully");

        return Ok(paymentResult);
    }
}