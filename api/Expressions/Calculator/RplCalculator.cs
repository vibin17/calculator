using Expressions.Interfaces;
using Expressions.Models;

namespace Expressions.Calculator;

public class RplCalculator : IRplCalculator
{
    public double Calculate(Stack<RplElement> rplExpression)
    {
        return Walk();

        double Walk()
        {
            var current = rplExpression.Pop();

            if (current.Operation is not null)
            {
                var right = Walk();
                var left = Walk();

                var result = current.Operation.Function(left, right);

                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new DivideByZeroException();

                return result;
            }

            return current.Number;
        }
    }
}