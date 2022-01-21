using System.Diagnostics.CodeAnalysis;

namespace Rosd.Data.Conventions;

/// <summary>
/// LowerCaseConverter is used in database where table/columns use the "tablename" convention.
/// </summary>
public sealed class LowerCaseConverter : CaseConventionConverter
{
    [return: NotNullIfNotNull("input")]
    protected override string? ConvertName(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return input.ToLowerInvariant();
    }
}
