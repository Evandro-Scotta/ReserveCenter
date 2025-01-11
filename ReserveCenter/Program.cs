using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveCenter.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ReserveCenterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveCenterContext") ?? throw new InvalidOperationException("Connection string 'ReserveCenterContext' not found.")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
