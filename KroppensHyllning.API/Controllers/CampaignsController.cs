using KroppenHyllning.Mapping;
using KroppensHyllning.Application.Repositories;
using KroppensHyllning.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace KroppenHyllning.Controllers;

[ApiController]
public class CampaignsController : ControllerBase
{
    private readonly ICampaignRepository _campaignRepository;

    public CampaignsController(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    [HttpPost]
    [Route(ApiEndpoints.Campaigns.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCampaignRequest request)
    {
        var campaign = request.MapToCampaign();
        await _campaignRepository.CreateAsync(campaign);
        return CreatedAtAction(
            nameof(Get),
            new {idOrSlug = campaign.Id},
            campaign.MapToResponse()
        );
    }

    [HttpGet]
    [Route(ApiEndpoints.Campaigns.Get)]
    public async Task<IActionResult> Get([FromRoute] string idOrSlug)
    {
        var campaign = Guid.TryParse(idOrSlug, out var id)
            ? await _campaignRepository.GetByIdAsync(id)
            : await _campaignRepository.GetBySlugAsync(idOrSlug);
        if (campaign is null) return NotFound();
        var response = campaign.MapToResponse();
        return Ok(response);
    }

    [HttpGet]
    [Route(ApiEndpoints.Campaigns.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var campaigns = await _campaignRepository.GetAllAsync();

        var response = campaigns.MapToResponse();

        return Ok(response);
    }

    [HttpPut]
    [Route(ApiEndpoints.Campaigns.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCampaignRequest request)
    {
        var campaign = request.MapToCampaign(id);

        var updated = await _campaignRepository.UpdateAsync(campaign);

        if (!updated) return NotFound();

        var response = campaign.MapToResponse();
        return Ok(response);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Campaigns.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _campaignRepository.DeleteByIdAsync(id);
        if (!deleted) return NotFound();
        return Ok();
    }
}
