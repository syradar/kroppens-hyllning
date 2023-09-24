using KroppensHyllning.Application.Models;
using KroppensHyllning.Application.Repositories;
using KroppensHyllning.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KroppenHyllning.Controllers;

[ApiController]
[Route("api/v1/")]
public class CampaignsController : ControllerBase
{
    private readonly ICampaignRepository _campaignRepository;

    public CampaignsController(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    [HttpPost]
    [Route("campaigns")]
    public async Task<IActionResult> Create([FromBody] CreateCampaignRequest request)
    {
        var campaign = new Campaign
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            StartYear = request.StartYear,
            Tags = request.Tags.ToList()
        };

        await _campaignRepository.CreateAsync(campaign);

        return Created(
            $"/api/campaigns/{campaign.Id}",
            campaign
        );
    }
}
