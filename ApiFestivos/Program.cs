using Festivos.Core.Repositorios; // Aseg�rate de incluir esta directiva
using Festivos.Core.Servicios; // Aseg�rate de incluir esta directiva
using Festivos.Infraestructura.Persistencia; // Aseg�rate de incluir esta directiva
using Festivos.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Festivos.Aplicacion.Servicios; // Si est�s usando AutoMapper, tambi�n necesitas esto

var builder = WebApplication.CreateBuilder(args);

//***** Add services to the container. *****

// Configuraci�n del Mapeador de objetos (si lo necesitas)
var mapperConfig = new MapperConfiguration(cfg =>
{
    //cfg.AddProfile<MappingProfile>(); // Descomenta y agrega tu perfil de mapeo si lo necesitas
});

IMapper mapper = new Mapper(mapperConfig);
builder.Services.AddSingleton(mapper);

// Configuraci�n de CORS
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

// Configuraci�n de controladores
builder.Services.AddControllers();

// Configuraci�n de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("PoliticaCors");

app.MapControllers();

app.Run();
