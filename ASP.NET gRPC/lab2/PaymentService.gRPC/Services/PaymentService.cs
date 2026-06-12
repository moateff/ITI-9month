using Grpc.Core;
using PaymentService.gRPC.Models;

namespace PaymentService.gRPC.Services;

public class PaymentService : Payment.PaymentBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<PaymentService> _logger;

    public PaymentService(AppDbContext context, ILogger<PaymentService> logger)
    {
        _logger = logger;
        _context = context;
    }

    public override Task<DeductResponse> Deduct(DeductRequest request, ServerCallContext context)
    {
        _logger.LogInformation(
            "Payment request started for UserId: {UserId}, TotalPrice: {TotalPrice}",
            request.Id, request.TotalPrice);

        var dbUser = _context.Users.FirstOrDefault(x => x.Id == request.Id);

        if (dbUser == null)
        {
            _logger.LogWarning("User not found: {UserId}", request.Id);

            return Task.FromResult(new DeductResponse
            {
                Success = false,
                Message = $"[Payment] User {request.Id} not found"
            });
        }

        _logger.LogInformation("User found: {UserId}, Balance: {Balance}",
            dbUser.Id, dbUser.Balance);

        if (request.TotalPrice <= 0)
        {
            _logger.LogWarning("Invalid total price: {TotalPrice} for UserId: {UserId}",
                request.TotalPrice, request.Id);

            return Task.FromResult(new DeductResponse
            {
                Success = false,
                Message = "[Payment] Total price must be positive"
            });
        }

        if (dbUser.Balance < request.TotalPrice)
        {
            _logger.LogWarning(
                "Insufficient balance for UserId: {UserId}. Balance: {Balance}, Required: {TotalPrice}",
                request.Id, dbUser.Balance, request.TotalPrice);

            return Task.FromResult(new DeductResponse
            {
                Success = false,
                Message = $"[Payment] Not enough balance for user {request.Id}"
            });
        }

        dbUser.Balance -= request.TotalPrice;

        _logger.LogInformation(
            "Balance deducted successfully for UserId: {UserId}. New Balance: {Balance}",
            request.Id, dbUser.Balance);

        _logger.LogInformation("Payment completed successfully for UserId: {UserId}", request.Id);

        return Task.FromResult(new DeductResponse
        {
            Success = true,
            Message = "[Payment] Balance deducted successfully"
        });
    }
}