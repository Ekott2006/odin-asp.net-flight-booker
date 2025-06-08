using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helper;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<DataRepository>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// builder.Services.AddDbContext<DataContext>(options => options.UseSqlite("Data Source=flight_booker.db"));

WebApplication app = builder.Build();

// TODO: SEEDING DB HERE to prevent stack overflow error
using (IServiceScope scope = app.Services.CreateScope())
{
    DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await SeedDatabase.SeedFlightData(context);
    if (!context.Flights.Any()) throw new Exception("Unable to Seed Database");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
