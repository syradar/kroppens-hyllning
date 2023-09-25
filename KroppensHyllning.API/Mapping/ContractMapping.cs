using KroppensHyllning.Application.Models;
using KroppensHyllning.Contracts.Requests;
using KroppensHyllning.Contracts.Responses;

namespace KroppenHyllning.Mapping;

public static class ContractMapping
{
    public static Campaign MapToCampaign(this CreateCampaignRequest request)
    {
        return new Campaign
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            StartYear = request.StartYear,
            Tags = request.Tags.ToList()
        };
    }

    public static Campaign MapToCampaign(this UpdateCampaignRequest request, Guid id)
    {
        return new Campaign
        {
            Id = id,
            Name = request.Name,
            StartYear = request.StartYear,
            Tags = request.Tags.ToList()
        };
    }

    public static CampaignResponse MapToResponse(this Campaign campaign)
    {
        return new CampaignResponse
        {
            Id = campaign.Id,
            Name = campaign.Name,
            StartYear = campaign.StartYear,
            Tags = campaign.Tags
        };
    }

    public static CampaignsResponse MapToResponse(this IEnumerable<Campaign> campaigns)
    {
        return new CampaignsResponse
        {
            Items = campaigns.Select(c => c.MapToResponse())
        };
    }
}
