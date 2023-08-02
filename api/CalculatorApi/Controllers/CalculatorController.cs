using CalculatorApi.Filters;
using CalculatorApi.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("calc")]
[InvalidInputException]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;

    public CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    [HttpGet("add")]
    public double Add([FromQuery] int a, int b)
    {
        return _calculatorService.Add(a, b);
    }

    [HttpGet("sub")]
    public double Subtract([FromQuery] int a, int b)
    {
        return _calculatorService.Subtract(a, b);
    }

    [HttpGet("mul")]
    public double Multiply([FromQuery] int a, int b)
    {
        return _calculatorService.Multiply(a, b);
    }

    [HttpGet("div")]
    public double Divide([FromQuery] int a, int b)
    {
        return _calculatorService.Divide(a, b);
    }

    [HttpGet("sqrt")]
    public double Sqrt([FromQuery] int a)
    {
        return _calculatorService.Sqrt(a);
    }

    [HttpGet("expr")]
    public double CalculateExpression([FromQuery] string expression)
    {
        return _calculatorService.CalculateExpression(expression);
    }
}