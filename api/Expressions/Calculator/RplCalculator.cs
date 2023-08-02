using Expressions.Enums;
using Expressions.Exceptions;
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
                var left = 0d;

                if (rplExpression.Count > 0)
                    left = Walk();

                else if (current.Operation.Type is not 
                    (ArithmeticOperationType.Add or ArithmeticOperationType.Subtract))
                    throw new InvalidInputException("Illegal unary operation");

                var result = current.Operation.Function(left, right);

                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new InvalidInputException("Attempt to divide by zero");

                return result;
            }

            return current.Number;
        }
    }
}