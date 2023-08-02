using Expressions.Interfaces;
using Expressions.Utility;

namespace Expressions.Validators;

public class ExpressionValidator : IExpressionValidator
{
    public bool ContainsIllegalCharacters(string expression) =>
        ExpressionTokenizer.MatchIllegal(expression);
}