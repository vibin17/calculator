// See https://aka.ms/new-console-template for more information
using Expressions.Calculator;
using Expressions.Containers;
using Expressions.Models;
using Expressions.Parser;

var expression = "3 * (1 + 2 ^ 2) - 1";
var rpl = new ExpressionParser(new OperationsContainer()).Parse(expression);
var rplCopy = new Stack<RplElement>(rpl.Reverse());

var result = new RplCalculator().Calculate(rplCopy);

return;