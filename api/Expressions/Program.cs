// See https://aka.ms/new-console-template for more information
using Expressions.Calculator;
using Expressions.Containers;
using Expressions.Models;
using Expressions.Parser;
using Expressions.Validators;

var expression = "* 0,1";
var rpl = new ExpressionParser(
    new ArithmeticsContainer(), 
    new ExpressionValidator()
).Parse(expression);

var rplCopy = new Stack<RplElement>(rpl.Reverse());

var result = new RplCalculator().Calculate(rplCopy);

return;