
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using MinhaSolutionTransacoesAPI.Data;
using MinhaSolutionTransacoesAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Configurações banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    var connectionString = builder.Configuration.GetSection("ConnectionString:DefaultConnection").Value;
    
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//=============================================================================
//INJEÇÃO DE DEPENDENCIA:
//=============================================================================
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ITransacoesRepository, TransacoesRepository>();
//=============================================================================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha Transações Bancarias API v1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();