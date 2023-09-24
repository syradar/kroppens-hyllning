namespace KroppensHyllning.Contracts.Requests;

public class UpdateCampaignRequest
{
    public required string Name { get; init; }

    public required int StartYear { get; init; }

    public required IEnumerable<string> Tags { get; init; } = Enumerable.Empty<string>();
}
