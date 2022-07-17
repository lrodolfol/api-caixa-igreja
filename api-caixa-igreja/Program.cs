using api_caixa_igreja.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CaixaIgrejaMysql");
//var connectionString = builder.Configuration.GetConnectionString("CaixaIgrejaMysqlDocker");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseLazyLoadingProxies()
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerenciador de Todo's", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
        Console.WriteLine("Auto-Migration executado com sucesso");
    }catch(Exception ex)
    {
        //ILOGGER
        Console.WriteLine("Ocorreu erro ao executar o auto-migration.");
        Console.WriteLine("Verifique se a string de conexão esta corretamente configurada.");
        Console.WriteLine("Por favor, tente executar o comando 'Add-Migration 'migration' manualmente");
        Console.WriteLine(ex.Message);
    }
}

app.Run();