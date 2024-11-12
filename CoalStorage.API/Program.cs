using CoalStorage.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();


if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}
//FIRST
app.UseRouting();

//SECONDARY
app.addSwagger();

app.addAuthentificaionNAuthorization();



app.MapControllers();
//END
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();

public partial class Program { }