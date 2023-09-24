namespace KroppensHyllning.Contracts.Responses;

public class CampaignsResponse
{
    public required IEnumerable<CampaignResponse> Items { get; init; } = Enumerable.Empty<CampaignResponse>();
}
