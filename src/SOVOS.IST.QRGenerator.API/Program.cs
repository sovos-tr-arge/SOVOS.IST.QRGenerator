

IConfigurationRoot? configuration = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json")
   .AddEnvironmentVariables()
   .Build();


Log.Logger = new LoggerConfiguration()
      .ReadFrom.Configuration(configuration)
      .Enrich.FromLogContext()
      .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Added Endpoints
app.MapQRGenerateEndpoints();

app.Run();