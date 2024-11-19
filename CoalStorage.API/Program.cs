var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddInfrastructureServices(configuration);


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
app.AddStorageEndpoints();
app.AddCommonEndpoints();
//app.AddAuthEndpoints();
app.AddAreaEndpoints();

app.Run();

public partial class Program { }