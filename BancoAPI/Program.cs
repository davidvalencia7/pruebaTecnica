
using Banco.Domain.Interfaces;
using Banco.Domain.Interfaces.Repository;
using Banco.Domain.Models;
using Banco.Persistance;
using Banco.Persistance.Data;
using Banco.Persistance.Repository;
using Banco.Services.Implementations;
using Banco.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "corspolice";
builder.Services.AddCors(p => p.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BancoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

//Inyección de dependencias
builder.Services.AddScoped<DbContext, BancoContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IGeneroService, GeneroService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<ICuentaService, CuentaService>();
builder.Services.AddTransient<ITipoCuentaService, TipoCuentaService>();
builder.Services.AddTransient<IMovimientoService, MovimientoService>();
builder.Services.AddTransient<ITipoMovimientoService, TipoMovimientoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
