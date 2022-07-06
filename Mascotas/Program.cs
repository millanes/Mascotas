using Mascotas.Middleware;
using Mascotas.Models;
using Mascotas.Repositories;
using Microsoft.AspNetCore.Http.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<Gato>();
builder.Services.AddSingleton<GatoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Use(async (context, next) =>
//{
//    app.Logger.LogInformation($"Method: {context.Request.Method}, URL: {context.Request.GetDisplayUrl()}");
//    await next.Invoke();
//    app.Logger.LogInformation($"Status Code: {context.Response.StatusCode}, Content-Type: {context.Response.ContentType}");
//});

app.UseMiddleware<LoggerGatosMiddleware>();

app.Run();
