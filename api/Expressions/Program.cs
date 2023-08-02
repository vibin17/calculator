// See https://aka.ms/new-console-template for more information
using Expressions.Calculator;
using Expressions.Containers;
using Expressions.Models;
using Expressions.Parser;

var expression = "0,1 + 0,2";
var rpl = new ExpressionParser(new ArithmeticsContainer()).Parse(expression);
var rplCopy = new Stack<RplElement>(rpl.Reverse());

var result = new RplCalculator().Calculate(rplCopy);

return;