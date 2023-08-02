using Expressions.Calculator;
using Expressions.Containers;
using Expressions.Parser;
using Expressions.Validators;

var expression = "2 ^ (3 - 1) * (12 + 24)";
var rpl = new ExpressionParser(
    new ArithmeticsContainer(), 
    new ExpressionValidator()
).Parse(expression);

var result = new RplCalculator().Calculate(rpl);

return;