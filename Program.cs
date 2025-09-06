using MinimalApi.Infraestrutura.DB;
using MinimalApi.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IAdministradorServico,
        AdministradorServico>();

        builder.Services.AddDbContext<DbContexto>(options =>
        {
            options.UseMySql(
                builder.Configuration.GetConnectionString("mysql"),
                ServerVersion.AutoDetect(
                    builder.Configuration.GetConnectionString("mysql")
                )
            );
        });

        var app = builder.Build();

        app.MapGet("/", () => "Hello World! Minimal API is running.");

        app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) =>
        {
            if (administradorServico.Login(loginDTO)! == null)
            {
                return Results.Ok("Login realizado com sucesso");
            }
            return Results.Unauthorized();
        });

        app.Run();
    }
}