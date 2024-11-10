using CoalStorage.Inftastructure;
using CoalStorage.Inftastructure.Data;
using CoalStorage.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

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

app.ConfigureStorageEndpoints();
app.Run();

public partial class Program { }