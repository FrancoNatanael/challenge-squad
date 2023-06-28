using Clima.Application.Servicios;
using Clima.Domain.Entidades;
using Clima.Domain.Helper;
using Clima.Domain.Repositorio;
using Clima.Infrastructure.Context;
using Clima.Infrastructure.RepositorioEF;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddDbContext<ClimaContexto>();
builder.Services.AddScoped(typeof(ServicioConsultaClima));
builder.Services.AddScoped(typeof(HelperReporteClima));
builder.Services.AddScoped(typeof(ServicioLoginUsuario));
builder.Services.AddScoped(typeof(HelperLogin));
builder.Services.AddScoped<IRepositorioClima, ClimaRepositorio>();
builder.Services.AddScoped<IRepositorioUsuario, UsuarioRepositorio>();

var app = builder.Build();

using (var dbContext = new ClimaContexto())
{
    dbContext.InsertData();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseCors();
app.MapControllers();

app.Run();
