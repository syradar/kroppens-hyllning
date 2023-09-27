using KroppensHyllning.Application.Models;

namespace KroppensHyllning.Application.Repositories;

public class CampaignRepository : ICampaignRepository
{
    private readonly List<Campaign> _campaigns = new();


    public Task<bool> CreateAsync(Campaign campaign)
    {
        _campaigns.Add(campaign);
        return Task.FromResult(true);
    }

    public Task<Campaign?> GetByIdAsync(Guid id)
    {
        var campaign = _campaigns.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(campaign);
    }

    public Task<Campaign?> GetBySlugAsync(string slug)
    {
        var campaign = _campaigns.FirstOrDefault(c => c.Slug == slug);
        return Task.FromResult(campaign);
    }

    public Task<IEnumerable<Campaign>> GetAllAsync()
    {
        return Task.FromResult(_campaigns.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Campaign campaign)
    {
        var index = _campaigns.FindIndex(c => c.Id == campaign.Id);
        if (index == -1) return Task.FromResult(false);

        _campaigns[index] = campaign;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _campaigns.RemoveAll(c => c.Id == id);
        var removedAtLeastOne = removedCount > 0;
        return Task.FromResult(removedAtLeastOne);
    }
}
