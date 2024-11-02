using Festivos.Core.Repositorios; 
using Festivos.Core.Servicios; 
using Festivos.Infraestructura.Persistencia; 
using Festivos.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Festivos.Aplicacion;
using Festivos.Aplicacion.Servicios; 

var builder = WebApplication.CreateBuilder(args);

//***** Add services to the container. *****

// Configuración del Mapeador de objetos 
var mapperConfig = new MapperConfiguration(cfg =>
{
    //cfg.AddProfile<MappingProfile>(); // Descomenta y agrega tu perfil de mapeo si lo necesitas
});

IMapper mapper = new Mapper(mapperConfig);
builder.Services.AddSingleton(mapper);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Agregar dependencias de servicios y repositorios
builder.Services.AddScoped<IFestivosServicios, FestivoServicios>();
builder.Services.AddScoped<IFestivosRepositorios, FestivosRepositorio>();

// Configurar DbContext
builder.Services.AddDbContext<FestivosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuración de controladores
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Festivos v1"); // Endpoint del archivo de configuración Swagger
        c.RoutePrefix = string.Empty; // Hace que Swagger sea la página de inicio
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("PoliticaCors");

app.MapControllers();

app.Run();
