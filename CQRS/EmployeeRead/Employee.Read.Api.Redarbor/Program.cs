using Employee.Read.Application.Redarbor.UseCases;
using Employee.Read.Domain.Redarbor.Interfaces;
using Employee.Read.Infraestruture.Redarbor.Configuration;
using Employee.Read.Infraestruture.Redarbor.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbQueryProvider, DbQueryProvider>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IGetEmployeeByIdUserCase, GetEmployeeByIdUserCase>();
builder.Services.AddScoped<IGetEmployeesUserCase, GetEmployeesUserCase>();

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
