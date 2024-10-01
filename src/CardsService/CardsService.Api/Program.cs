using CardsService.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ProtoBuf.Grpc.Server;

AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((options) =>
{
    // trying to use Http1AndHttp2 causes http2 connections to fail with invalid protocol error
    // according to Microsoft dual http version mode not supported in unencrypted scenario: https://learn.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-3.0
    options.ConfigureEndpointDefaults(lo => lo.Protocols = HttpProtocols.Http2);
});

// Add services to the container.
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<InMemoryCardsService>();

app.Run();
