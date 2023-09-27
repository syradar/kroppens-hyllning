namespace KroppensHyllning.Application.Models;

public partial class Campaign
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public string Slug => GenerateSlug();

    public required int StartYear { get; init; }

    public required List<string> Tags { get; init; } = new();

    private string GenerateSlug()
    {
        var replaced = SlugRegex()
            .Replace(Name, "-")
            .ToLowerInvariant();

        return $"{replaced}-{StartYear}";
    }

    [GeneratedRegex("[^a-zA-Z0-9]", RegexOptions.NonBacktracking, 5)]
    private static partial Regex SlugRegex();
}
