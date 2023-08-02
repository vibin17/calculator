using Expressions.Enums;
using Expressions.Interfaces;
using Expressions.Models;

namespace Expressions.Containers;

public class ArithmeticsContainer : IArithmeticsContainer
{
    private readonly ArithmeticOperation _add = new() 
    { 
        Type = ArithmeticOperationType.Add, 
        Priority = 1, 
        Sign = "+", 
        Function = (a, b) => a + b 
    };

    private readonly ArithmeticOperation _sub = new() 
    {
        Type = ArithmeticOperationType.Subtract,
        Priority = 1, 
        Sign = "-", 
        Function = (a, b) => a - b 
    };

    private readonly ArithmeticOperation _mul = new() 
    { 
        Type = ArithmeticOperationType.Multiply,
        Priority = 2, 
        Sign = "*",
        Function = (a, b) => a * b 
    };

    private readonly ArithmeticOperation _div = new() 
    { 
        Type = ArithmeticOperationType.Divide,
        Priority = 2, 
        Sign = "/", 
        Function = (a, b) => a / b 
    };

    private readonly ArithmeticOperation _pow = new() 
    { 
        Type = ArithmeticOperationType.Power,
        Priority = 3, 
        Sign = "^", 
        Function = (a, b) => Math.Pow(a, b) 
    };

    public ArithmeticOperation GetOperation(string input) =>
        input switch
        {
            "+" => _add,
            "-" => _sub,
            "*" => _mul,
            "/" => _div,
            "^" => _pow,
            _ => throw new ArgumentException("Input string is not a math operation"),
        };
}
