using CalculatorApi.Dto;
using CalculatorApi.Interfaces;

using Expressions.Exceptions;
using Expressions.Interfaces;

namespace CalculatorApi.Services;

public class CalculatorService : ICalculatorService
{
    private readonly IExpressionParser _expressionParser;
    private readonly IRplCalculator _rplCalculator;

    public CalculatorService(IExpressionParser expressionParser, IRplCalculator rplCalculator)
    {
        _expressionParser = expressionParser;
        _rplCalculator = rplCalculator;
    }

    public CalculatorResult Add(int a, int b) =>
        new() { Result = a + b };

    public CalculatorResult Subtract(int a, int b) =>
        new() { Result = a - b };

    public CalculatorResult Multiply(int a, int b) =>
        new() { Result = a * b };

    public CalculatorResult Divide(int a, int b)
    {
        if (b is 0)
            throw new IllegalInputException("Attempt to divide by zero");

        return new() { Result = a / (double)b };
    }

    public CalculatorResult Pow(int a, int b) =>
        new() { Result = Math.Pow(a, b) };

    public CalculatorResult Root(int a, int b) =>
        new() { Result = Math.Pow(a, 1/(double)b) };

    public CalculatorResult CalculateExpression(string expression)
    {
        var rpl = _expressionParser.Parse(expression);

        return new() { Result = _rplCalculator.Calculate(rpl) };
    }
}