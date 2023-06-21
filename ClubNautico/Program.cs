using ClubNautico.Data;
using ClubNautico.Services.Socios.Queries;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ClubNautico.DTO.Mapeo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddMediatR((config) => //TODO: REGISTRAMOS LOS SERVICIOS DE MEDIATR
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); //TODO: REGISTRAMOS LOS SERVICIOS DE MEDIATR DESDE EL ENSAMBLADO ACTUAL
});
builder.Services.AddFluentValidation((config) => //TODO: REGISTRAMOS LOS SERVICIOS DE FLUENT VALIDATION
{
    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // TODO: REGISTRAMOS LOS SERVICIOS DE FLUENT VALIDATION DESDE EL ENSAMBLADO ACTUAL
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();

app.UseCors((config) => //TODO: HABILITAMOS CORS PARA QUE PUEDA SER ACCEDIDO DESDE CUALQUIER ORIGEN
{
    config.AllowAnyOrigin();
    config.AllowAnyHeader();
});


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
