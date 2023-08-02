using Expressions.Models;

namespace Expressions.Interfaces;

public interface IArithmeticsContainer
{
    public ArithmeticOperation GetOperation(string input);
}