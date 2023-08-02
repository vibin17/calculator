using CalculatorApi.Dto;

namespace CalculatorApi.Interfaces;

public interface ICalculatorService
{
    public CalculatorResult Add(int a, int b);

    public CalculatorResult Subtract(int a, int b);

    public CalculatorResult Multiply(int a, int b);

    public CalculatorResult Divide(int a, int b);

    public CalculatorResult Sqrt(int a);

    public CalculatorResult CalculateExpression(string expression);
}
