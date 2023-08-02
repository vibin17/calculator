using CalculatorApi.Dto;
using CalculatorApi.Filters;
using CalculatorApi.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("calc")]
[IllegalInputException]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;

    public CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    [HttpGet("add")]
    public CalculatorResult Add(
        [FromQuery][Required] int a, 
        [FromQuery][Required] int b)
    {
        return _calculatorService.Add(a, b);
    }

    [HttpGet("sub")]
    public CalculatorResult Subtract(
        [FromQuery][Required] int a, 
        [FromQuery][Required] int b)
    {
        return _calculatorService.Subtract(a, b);
    }

    [HttpGet("mul")]
    public CalculatorResult Multiply(
        [FromQuery][Required] int a, 
        [FromQuery][Required] int b)
    {
        return _calculatorService.Multiply(a, b);
    }

    [HttpGet("div")]
    public CalculatorResult Divide(
        [FromQuery][Required] int a, 
        [FromQuery][Required] int b)
    {
        return _calculatorService.Divide(a, b);
    }

    [HttpGet("sqrt")]
    public CalculatorResult Sqrt([FromQuery][Required] int a)
    {
        return _calculatorService.Sqrt(a);
    }

    [HttpGet("expr")]
    public CalculatorResult CalculateExpression([FromQuery][Required] string expression)
    {
        return _calculatorService.CalculateExpression(expression);
    }
}