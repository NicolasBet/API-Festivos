using Festivos.Core.Servicios;
using Festivos.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register dependencies for FestivosServicios and FestivoRepositorio
builder.Services.AddScoped<IFestivosServicios, IFestivosServicios>();
builder.Services.AddScoped<IFestivoRepositorio, FestivoRepositorio>();
builder.Services.AddDbContext<FestivosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuring Swagger/OpenAPI
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
app.MapControllers();
app.Run();
