using Microsoft.EntityFrameworkCore;
using task1.Repositories;
using WebOptimizer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TrackRepository>();
builder.Services.AddScoped<TraineeRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<TraineeCourseRepository>();

builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddCssBundle(
        "/css/style.min.css",
        "css/bodyStyle.css",
        "css/headerStyle.css");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseWebOptimizer();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();