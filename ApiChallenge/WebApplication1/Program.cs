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
    //if (dbContext.Pais.Count() == 0 && dbContext.Ciudad.Count() == 0 && dbContext.ReporteClima.Count() == 0 && dbContext.Usuario.Count() == 0)

    //{
    //    var paises = new List<Pais>
    //                    {
    //                        new Pais { Nombre = "Estados Unidos" ,Id = 1},
    //                        new Pais { Nombre = "Argentina" , Id = 2}
    //                    };

    //    dbContext.Pais.AddRange(paises);

    //    var ciudades = new List<Ciudad>
    //                {
    //                new Ciudad { Nombre = "Nueva York", Id = 1, IdPais = 1 },
    //                new Ciudad { Nombre = "Buenos Aires", Id = 2, IdPais = 1 }
    //                };

    //    dbContext.Ciudad.AddRange(ciudades);

    //    var reportesClima = new List<ReporteClima>
    //                {
    //                new ReporteClima {Id = 1, DiaSemana = "Lunes", Humedad = (decimal)75.6, VelocidadViento = (decimal)10.2, ProbPrecipitaciones = (decimal) 30.5, Grados = (decimal) 25.7, Estado = "Soleado", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 2, DiaSemana = "Martes", Humedad = (decimal)62.8, VelocidadViento = (decimal) 14.3, ProbPrecipitaciones = (decimal) 20.1, Grados = (decimal) 28.2, Estado = "Nublado", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 3, DiaSemana = "Miercoles", Humedad = (decimal)80.2, VelocidadViento = (decimal) 8.7, ProbPrecipitaciones = (decimal) 15.8, Grados = (decimal) 23.5, Estado = "Lluvioso", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 4, DiaSemana = "Jueves", Humedad = (decimal) 69.5, VelocidadViento = (decimal) 12.1, ProbPrecipitaciones = (decimal) 40.2, Grados = (decimal) 21.8, Estado = "Nublado", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 5, DiaSemana = "Viernes", Humedad = (decimal) 57.3, VelocidadViento = (decimal) 9.8, ProbPrecipitaciones = (decimal) 10.5, Grados = (decimal) 30.1, Estado = "Soleado", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 6, DiaSemana = "Sabado", Humedad = (decimal) 68.9, VelocidadViento = (decimal) 11.5, ProbPrecipitaciones =  (decimal) 25.6, Grados = (decimal) 26.4, Estado = "Parcialmente nublado", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 7,DiaSemana = "Domingo", Humedad = (decimal) 74.1, VelocidadViento = (decimal) 13.2, ProbPrecipitaciones = (decimal) 5.7, Grados = (decimal) 29.8, Estado = "Soleado", Ciudad = 1, Pais = 1 },
    //                new ReporteClima {Id = 8, DiaSemana = "Lunes", Humedad = (decimal) 45.6, VelocidadViento = (decimal) 13.2, ProbPrecipitaciones = (decimal) 20.5, Grados = (decimal) 35.7, Estado = "Soleado", Ciudad = 2, Pais = 2 },
    //                new ReporteClima {Id = 9, DiaSemana = "Martes", Humedad = (decimal) 60.8, VelocidadViento = (decimal) 24.3, ProbPrecipitaciones = (decimal) 24.1, Grados = (decimal) 38.2, Estado = "Nublado", Ciudad = 2, Pais = 2 },
    //                new ReporteClima {Id = 10, DiaSemana = "Miercoles", Humedad = (decimal) 70.2, VelocidadViento = (decimal) 7.7, ProbPrecipitaciones = (decimal) 11.8, Grados = (decimal) 13.5, Estado = "Lluvioso", Ciudad = 2, Pais = 2 },
    //                new ReporteClima {Id = 11, DiaSemana = "Jueves", Humedad = (decimal) 62.5, VelocidadViento = (decimal) 12.1, ProbPrecipitaciones = (decimal) 40.2, Grados = (decimal) 11.8, Estado = "Nublado", Ciudad = 2, Pais = 2 },
    //                new ReporteClima {Id = 12, DiaSemana = "Viernes", Humedad = (decimal) 47.3, VelocidadViento = (decimal) 4.8, ProbPrecipitaciones = (decimal) 10.5, Grados = (decimal) 30.1, Estado = "Soleado", Ciudad = 2, Pais = 2 },
    //                new ReporteClima {Id = 13, DiaSemana = "Sabado", Humedad = (decimal) 68.9, VelocidadViento = (decimal) 21.5, ProbPrecipitaciones = (decimal) 25.6, Grados = (decimal) 36.4, Estado = "Parcialmente nublado", Ciudad = 2, Pais = 2 },
    //                new ReporteClima {Id = 14, DiaSemana = "Domingo", Humedad = (decimal) 84.1, VelocidadViento = (decimal)11.2, ProbPrecipitaciones = (decimal) 7.7, Grados = (decimal) 19.8, Estado = "Soleado", Ciudad = 2, Pais = 2 }
    //                };
    //    dbContext.ReporteClima.AddRange(reportesClima);

    //    var usuarios = new List<Usuario>
    //                {
    //                new Usuario {Id = 1, Nombre = "franco", Password = "123", Mail = "franco@gmail.com" },
    //                new Usuario {Id = 2, Nombre = "usuario", Password = "999", Mail = "usuario@gmail.com" }
    //                };
    //    dbContext.Usuario.AddRange(usuarios);

    //    dbContext.SaveChanges();
    //}
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
