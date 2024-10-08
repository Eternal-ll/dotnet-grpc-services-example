using GatewayService.Api.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    var files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
    foreach (var file in files)
    {
        x.IncludeXmlComments(file, true);
    }
});

builder.Services.AddCardsService(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UsePathBase("/api");

app.UseHealthChecks("/heathz");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
