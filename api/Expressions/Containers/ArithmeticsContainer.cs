using Expressions.Interfaces;
using Expressions.Models;

namespace Expressions.Containers;

public class ArithmeticsContainer : IArithmeticsContainer
{
    private readonly ArithmeticOperation _add = new() 
    {  
        Priority = 1, 
        Sign = "+", 
        MayBeUnary = true,
        Function = (a, b) => a + b 
    };

    private readonly ArithmeticOperation _sub = new() 
    {
        Priority = 1, 
        Sign = "-",
        MayBeUnary = true,
        Function = (a, b) => a - b 
    };

    private readonly ArithmeticOperation _mul = new() 
    { 
        Priority = 2, 
        Sign = "*",
        Function = (a, b) => a * b 
    };

    private readonly ArithmeticOperation _div = new() 
    { 
        Priority = 2, 
        Sign = "/", 
        Function = (a, b) => a / b 
    };

    private readonly ArithmeticOperation _pow = new() 
    { 
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
