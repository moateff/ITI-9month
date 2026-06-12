using Grpc.Net.Client;
using PaymentService.gRPC;
using InventoryService.gRPC;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5089, o =>
    {
        // Allow HTTP/1.1 for gRPC-Web/Preflight OPTIONS, and HTTP/2 for traditional gRPC
        o.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders(
                "Grpc-Status",
                "Grpc-Message",
                "Grpc-Encoding",
                "Grpc-Accept-Encoding");
    });
});

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddControllers();

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

// 1. CORS MUST come first 
app.UseCors("AllowAll");

// 2. gRPC-Web middleware comes immediately after CORS
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

// Comment out or remove HTTPS redirect if you are explicitly testing on http://localhost:5089
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 3. Keep your service mapped cleanly
app.MapGrpcService<OrderingService.API.Services.OrderService>()
    .RequireCors("AllowAll");
    
app.MapGrpcReflectionService();

app.Run();