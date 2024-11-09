using CoalStorage.Inftastructure;
using CoalStorage.Inftastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    
}
await app.InitialiseDatabaseAsync();

app.UseOpenApi();
app.UseSwaggerUi();

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.AddRoutes();

app.Map("/", () => Results.Redirect("/swagger"));
app.Run();

public partial class Program { }