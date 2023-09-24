namespace KroppensHyllning.Contracts.Responses;

public class CampaignResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }

    public required int StartYear { get; init; }

    public required IEnumerable<string> Tags { get; init; } = Enumerable.Empty<string>();
}
