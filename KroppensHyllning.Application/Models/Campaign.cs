namespace KroppensHyllning.Application.Models;

public class Campaign
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }

    public required int StartYear { get; init; }

    public required List<string> Tags { get; init; } = new();
}
