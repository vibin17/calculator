using Expressions.Enums;

using System.Diagnostics.CodeAnalysis;

namespace Expressions.Models;

public class ExpressionOperator
{
    public required OperatorType Type { get; init; }

    public required string Sign { get; init; }

    [MemberNotNullWhen(true, nameof(Operation))]
    public bool IsArithmeticOperation =>
        Type is OperatorType.Operation;

    public ArithmeticOperation? Operation { get; init; }

    public override string ToString() =>
        Sign;
}
