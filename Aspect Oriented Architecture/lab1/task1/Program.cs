using Castle.DynamicProxy;
using task1.Decorators;
using task1.Interceptors;
using task1.Interfaces;
using task1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Decorators Logging
// builder.Services.AddScoped<UserService>();

// builder.Services.AddScoped<IUserService>(sp =>
// {
//     var service = sp.GetRequiredService<UserService>();
//     var logger = sp.GetRequiredService<ILogger<LoggingUserService>>();

//     return new LoggingUserService(service, logger);
// });


// Interceptors Logging
// builder.Services.AddSingleton<ProxyGenerator>();
// builder.Services.AddScoped<LoggingInterceptor>();

// builder.Services.AddScoped<IUserService>(sp =>
// {
//     var proxyGenerator = sp.GetRequiredService<ProxyGenerator>();
//     var interceptor = sp.GetRequiredService<LoggingInterceptor>();

//     IUserService service = new UserService();

//     return proxyGenerator.CreateInterfaceProxyWithTarget(
//         service,
//         interceptor);
// });


// Aspects Logging
builder.Services.AddScoped<IUserService, UserService>();


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
