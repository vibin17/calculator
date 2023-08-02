using System.Text.RegularExpressions;

namespace Expressions.Utility;

public static partial class ExpressionTokenizer
{
    [GeneratedRegex(@"\d+[,]\d+|\d+|[-+*\/^\(\)]", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex TokenRegex();

    [GeneratedRegex(@"[^0-9-+*\/^\(\), ]", RegexOptions.Multiline | RegexOptions.Compiled)]
    private static partial Regex ValidateRegex();

    public static MatchCollection ReadTokens(string expression) =>
        TokenRegex().Matches(expression);

    public static bool MatchIllegal(string expression) =>
        ValidateRegex().IsMatch(expression);
}