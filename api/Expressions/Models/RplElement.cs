﻿namespace Expressions.Models;

public class RplElement
{
    public double Number { get; init; }

    public ArithmeticOperation? Operation { get; init; }

    public override string ToString() =>
        Operation?.ToString() ?? Number.ToString();
}