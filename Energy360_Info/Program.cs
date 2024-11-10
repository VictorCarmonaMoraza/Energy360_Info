using Data.DbContext_Conection;
using Data.IRepository;
using Data.IServices;
using Data.Repository;
using Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRenewableEnergyPlantService, RenewableEnergyPlantService>();
builder.Services.AddScoped<IRenewableEnergyPlantRepository, RenewableEnergyPlantRepository>();

//Obtenemos valores de cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Configura el servicio CORS para permitir solicitudes desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS con la política que hemos configurado
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
