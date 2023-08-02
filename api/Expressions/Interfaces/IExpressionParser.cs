using Expressions.Models;

namespace Expressions.Interfaces;

public interface IExpressionParser
{
    public IReadOnlyCollection<RplElement> Parse(string expression);
}