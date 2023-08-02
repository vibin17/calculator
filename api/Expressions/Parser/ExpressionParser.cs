using Expressions.Enums;
using Expressions.Interfaces;
using Expressions.Models;
using Expressions.Utility;

namespace Expressions.Parser;

public class ExpressionParser : IExpressionParser
{
    private readonly IArithmeticsContainer _operationsContainer;

    public ExpressionParser(IArithmeticsContainer operationsContainer)
    {
        _operationsContainer = operationsContainer;
    }

    // Преобразование в обратную польскую запись с помощью алгоритма Shunting Yard
    public Stack<RplElement> Parse(string expression)
    {
        var (operators, rplOutput) = (new Stack<ExpressionOperator>(), new Stack<RplElement>());
        var tokens = ExpressionTokenizer.ReadTokens(expression).Select(m => m.Value);

        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var number))
            {
                rplOutput.Push(new() { Number = number });

                continue;
            }

            var currentOperator = CreateOperator(token);

            if (currentOperator.IsArithmeticOperation)
            {
                while (
                    operators.Count > 0 &&
                    operators.Peek() is var topOperator &&
                    topOperator.IsArithmeticOperation &&
                    topOperator.Operation.Priority >= currentOperator.Operation.Priority
                )
                    AddFromOperatorsToOutput();

                operators.Push(currentOperator);

                continue;
            }

            if (currentOperator.Type is OperatorType.LeftParenthesis)
            {
                operators.Push(currentOperator);

                continue;
            }

            if (currentOperator.Type is OperatorType.RightParenthesis)
            {
                while (
                    operators.Count > 0 &&
                    operators.Peek().Type is not OperatorType.LeftParenthesis
                )
                    AddFromOperatorsToOutput();

                operators.Pop();

                continue;
            }
        }

        while (operators.Count > 0)
            AddFromOperatorsToOutput();

        return rplOutput;

        void AddFromOperatorsToOutput()
        {
            var topOperator = operators.Pop();
            var operation = _operationsContainer.GetOperation(topOperator.Sign);

            rplOutput.Push(new()
            {
                Operation = operation
            });
        }
    }

    private ExpressionOperator CreateOperator(string input)
    {
        if (IsArithmeticOperator(input))
            return new()
            {
                Type = OperatorType.Arithmetic,
                Sign = input,
                Operation = _operationsContainer.GetOperation(input)
            };

        if (IsLeftParenthesis(input))
            return new()
            {
                Type = OperatorType.LeftParenthesis,
                Sign = input
            };

        if (IsRightParenthesis(input))
            return new()
            {
                Type = OperatorType.RightParenthesis,
                Sign = input
            };

        throw new ArgumentException("Unknown input type");
    }

    private static bool IsLeftParenthesis(string input) =>
        input is "(";

    private static bool IsRightParenthesis(string input) =>
        input is ")";

    private static bool IsArithmeticOperator(string input) =>
        input is "+" or "-" or "*" or "/" or "^";
}