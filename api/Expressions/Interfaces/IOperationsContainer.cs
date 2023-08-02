using Expressions.Models;

namespace Expressions.Interfaces;

public interface IOperationsContainer
{
    public ArithmeticOperation GetOperation(string input);
}
