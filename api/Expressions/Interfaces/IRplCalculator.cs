using Expressions.Models;

namespace Expressions.Interfaces;

public interface IRplCalculator
{
    public double Calculate(IReadOnlyCollection<RplElement> rplExpression);
}