using System.Security.Cryptography;
using Kiri.Api.Data;
using Kiri.Api.Endpoints;
using Kiri.Api.Middlewares;
using Kiri.Api.Repositories;
using Kiri.Api.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, cfg) =>
    cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>()
    .AddSingleton<IUrlShortenerService, UrlShortenerService>()
    .AddSingleton<IShortenedUrlService, ShortenedUrlService>()
    .AddSingleton<IShortenedUrlRepo, ShortenedUrlRepo>()
    .AddSingleton<DbInitializer>()
    .AddSingleton<IDbConnectionFactory>(_ => new PgsqlConnectionFactory(
        builder.Configuration.GetValue<string>("Database:ConnectionString")!));
        
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints();
var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();
app.Run();
