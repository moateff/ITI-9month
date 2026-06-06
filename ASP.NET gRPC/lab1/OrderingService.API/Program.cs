using Grpc.Net.Client;
using PaymentService.gRPC;
using InventoryService.gRPC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton(_ =>
{
    var channel = GrpcChannel.ForAddress("http://localhost:5130");
    return new Payment.PaymentClient(channel);
});

builder.Services.AddSingleton(_ =>
{
    var channel = GrpcChannel.ForAddress("http://localhost:5245");
    return new Inventory.InventoryClient(channel);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
