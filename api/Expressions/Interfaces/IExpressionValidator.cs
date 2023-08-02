namespace Expressions.Interfaces;

public interface IExpressionValidator
{
    public bool ContainsIllegalCharacters(string expression);
}
