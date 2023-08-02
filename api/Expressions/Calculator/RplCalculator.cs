using Expressions.Exceptions;
using Expressions.Interfaces;
using Expressions.Models;

namespace Expressions.Calculator;

public class RplCalculator : IRplCalculator
{
    public double Calculate(IReadOnlyCollection<RplElement> rplExpression)
    {
        var stack = new Stack<RplElement>();

        foreach (var current in rplExpression)
        {
            if (current.Operation is not null)
            {
                var right = stack.Pop().Number;
                var left = 0d;

                if (stack.Count > 0)
                    left = stack.Pop().Number;

                else if (!current.Operation.MayBeUnary)
                    throw new IllegalInputException("Illegal unary operation");

                var result = current.Operation.Function(left, right);

                if (double.IsNaN(result) || double.IsInfinity(result))
                    throw new IllegalInputException("Attempt to divide by zero");

                stack.Push(new() { Number = result });

                continue;
            }

            stack.Push(current);
        }

        if (stack.Count > 1)
            throw new InvalidOperationException("More than 1 element in stack");

        return stack.Peek().Number;
    }
}