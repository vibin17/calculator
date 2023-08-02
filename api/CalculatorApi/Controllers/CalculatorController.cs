using CalculatorApi.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("calc")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;

    public CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    [HttpGet("expression")]
    public double Get([FromQuery] string expression)
    {
        return _calculatorService.CalculateExpression(expression);
    }
}