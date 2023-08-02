using CalculatorApi.Interfaces;
using CalculatorApi.Services;

using Expressions.Calculator;
using Expressions.Containers;
using Expressions.Interfaces;
using Expressions.Parser;
using Expressions.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IArithmeticsContainer, ArithmeticsContainer>();
builder.Services.AddTransient<IExpressionValidator, ExpressionValidator>();
builder.Services.AddTransient<ICalculatorService, CalculatorService>();
builder.Services.AddTransient<IExpressionParser, ExpressionParser>();
builder.Services.AddTransient<IRplCalculator, RplCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
