using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Organizador.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "organizador.API v1");
    });

    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "organizador.API v1");
});

app.MapGet("/Usuario", (string nome) => new Usuario(){});

app.MapPost("/Usuario", (string nome) => new Usuario(){});

app.MapPut("/Usuario", (string nome) => new Usuario(){});

app.MapDelete("/Usuario", (string nome) => new Usuario(){});

app.Run();
