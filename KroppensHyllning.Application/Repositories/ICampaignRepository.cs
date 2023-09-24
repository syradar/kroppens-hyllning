using KroppensHyllning.Application.Models;

namespace KroppensHyllning.Application.Repositories;

public interface ICampaignRepository
{
    Task<bool> CreateAsync(Campaign campaign);

    Task<Campaign?> GetByIdAsync(Guid id);

    Task<IEnumerable<Campaign>> GetAllAsync();

    Task<bool> UpdateAsync(Campaign campaign);

    Task<bool> DeleteByIdAsync(Guid id);
}
