using CalculatorApi.Interfaces;

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

    public double CalculateExpression(string expression)
    {
        var rpl = _expressionParser.Parse(expression);
       
        return _rplCalculator.Calculate(rpl);
    }
}