using Grpc.Core;
using InventoryService.gRPC.Models;

namespace InventoryService.gRPC.Services;

public class InventoryService : Inventory.InventoryBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<InventoryService> _logger;

    public InventoryService(AppDbContext context, ILogger<InventoryService> logger)
    {
        _logger = logger;
        _context = context;
    }

    public override Task<DeductResponse> Deduct(DeductRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Inventory Deduct started. Items count: {Count}", request.Items.Count);

        if (!request.Items.Any())
        {
            _logger.LogWarning("No items found in request");
            return Task.FromResult(new DeductResponse
            {
                Success = false,
                Message = "No items found in request"
            });
        }

        // Validation phase
        foreach (var item in request.Items)
        {
            _logger.LogInformation("Validating ItemId: {ItemId}, Quantity: {Quantity}", item.Id, item.Quantity);

            var dbItem = _context.Items.FirstOrDefault(x => x.Id == item.Id);

            if (dbItem == null)
            {
                _logger.LogWarning("Item not found: {ItemId}", item.Id);

                return Task.FromResult(new DeductResponse
                {
                    Success = false,
                    Message = $"Item {item.Id} not found"
                });
            }

            if (item.Quantity <= 0)
            {
                _logger.LogWarning("Invalid quantity for ItemId: {ItemId}, Quantity: {Quantity}",
                    item.Id, item.Quantity);

                return Task.FromResult(new DeductResponse
                {
                    Success = false,
                    Message = "Quantity must be positive"
                });
            }

            if (dbItem.Quantity < item.Quantity)
            {
                _logger.LogWarning(
                    "Insufficient stock for ItemId: {ItemId}. Stock: {Stock}, Requested: {Requested}",
                    item.Id, dbItem.Quantity, item.Quantity);

                return Task.FromResult(new DeductResponse
                {
                    Success = false,
                    Message = $"Not enough stock for item {item.Id}"
                });
            }
        }

        _logger.LogInformation("Validation passed. Applying deduction...");

        // Deduction phase
        foreach (var item in request.Items)
        {
            var dbItem = _context.Items.First(x => x.Id == item.Id);

            _logger.LogInformation(
                "Deducting ItemId: {ItemId}. Before: {BeforeQty}, Deducting: {Quantity}",
                item.Id, dbItem.Quantity, item.Quantity);

            dbItem.Quantity -= item.Quantity;

            _logger.LogInformation(
                "ItemId: {ItemId} new quantity: {NewQuantity}",
                item.Id, dbItem.Quantity);
        }

        _logger.LogInformation("Inventory deduction completed successfully");

        return Task.FromResult(new DeductResponse
        {
            Success = true,
            Message = "Deducted successfully"
        });
    }
}