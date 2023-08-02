using Expressions.Models;

namespace Expressions.Interfaces;

public interface IExpressionParser
{
    public Stack<RplElement> Parse(string expression);
}