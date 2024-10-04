using CardsService.Sdk;
using CardsService.Sdk.Interceptors;
using ProtoBuf.Grpc.ClientFactory;

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

builder.Services
    .AddTransient<DomainExceptionInterceptor>()
    .AddCodeFirstGrpcClient<ICardsService>(x =>
    {
        x.Address = builder.Configuration.GetValue<Uri>("Services:CardsService:Url");
    })
    .AddInterceptor<DomainExceptionInterceptor>();

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
