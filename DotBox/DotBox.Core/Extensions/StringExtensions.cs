namespace DotBox.Core.Extensions;

public static class StringExtensions
{
    public static string FirstLine(this string input)
    {
        if (string.IsNullOrWhiteSpace(input) || input.IndexOfAny(new char[] { '\n' }) == 1)
            return input;

        return input.Substring(0, input.IndexOfAny(new char[] { '\n' })).Replace("\r", string.Empty);
    }
}
