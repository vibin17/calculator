using Expressions.Enums;

namespace Expressions.Models;

public class ArithmeticOperation
{
    public required string Sign { get; init; }

    public required int Priority { get; init; }

    public bool MayBeUnary { get; init; }

    public required Func<double, double, double> Function { get; init; }

    public override string ToString() => Sign;
}