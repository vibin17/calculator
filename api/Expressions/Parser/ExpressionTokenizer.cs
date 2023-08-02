using System.Text.RegularExpressions;

namespace Expressions.Utility;

public static partial class ExpressionTokenizer
{
    [GeneratedRegex(@"\d+[,]\d+|\d+|[-+*\/^\(\)]", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    public static MatchCollection ReadTokens(string expression) =>
        TokenRegex().Matches(expression);
}