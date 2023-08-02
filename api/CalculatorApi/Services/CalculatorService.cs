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

    public double Add(int a, int b) =>
        a + b;

    public double Subtract(int a, int b) =>
        a - b;

    public double Multiply(int a, int b) =>
        a * b;

    public double Divide(int a, int b)
    {
        if (b is 0)
            throw new InvalidInputException("Attempt to divide by zero");

        return a / (double)b;
    }


    public double Sqrt(int a) =>
        Math.Sqrt(a);

    public double CalculateExpression(string expression)
    {
        var rpl = _expressionParser.Parse(expression);

        return _rplCalculator.Calculate(rpl);
    }
}