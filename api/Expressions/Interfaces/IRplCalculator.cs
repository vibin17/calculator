using Expressions.Models;

namespace Expressions.Interfaces;

public interface IRplCalculator
{
    public double Calculate(Stack<RplElement> rplExpression);
}