using Employee.Write.Api.Redarbor.Helpers;
using Employee.Write.Application.Redarbor.UseCases;
using Employee.Write.Domain.Redarbor.Interfaces;
using Employee.Write.Infraestructure.Redarbor.Configuration;
using Employee.Write.Infraestructure.Redarbor.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbEmployeeContext>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IInsertEmployeeUseCase, InsertEmployeeUseCase>();
builder.Services.AddScoped<IUpdateEmployeeUseCase, UpdateEmployeeUseCase>();
builder.Services.AddScoped<IDeleteEmployeeUseCase, DeleteEmployeeUseCase>();

builder.Services.AddScoped<IAuthenticateHelper, AuthenticateHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
