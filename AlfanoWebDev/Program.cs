using Microsoft.EntityFrameworkCore;
using AlfanoWebDev.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddRazorPages();

// 2. Setup SQLite (This fixes the 'UseSqlite' error once Step 1 is done)
var connectionString = "Data Source=PortfolioData.db";
builder.Services.AddDbContext<AlfanoDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AlfanoDbContext>();
    DbInitializer.Initialize(context);
}
// 3. Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// This ensures your site starts on the right page
app.Run();