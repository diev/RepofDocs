namespace Rosd.Helpers;

public static class StringExtensions
{
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return string.Concat(input.Select((x, i) =>
            char.IsUpper(x) && i > 0
                ? "_" + x.ToString()
                : x.ToString()))
            .ToLower();
    }
}
