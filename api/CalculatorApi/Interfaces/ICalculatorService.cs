namespace CalculatorApi.Interfaces;

public interface ICalculatorService
{
    public double Add(int a, int b);

    public double Subtract(int a, int b);

    public double Multiply(int a, int b);

    public double Divide(int a, int b);

    public double Sqrt(int a);

    public double CalculateExpression(string expression);
}
