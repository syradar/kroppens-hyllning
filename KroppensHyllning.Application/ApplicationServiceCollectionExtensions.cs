using KroppensHyllning.Application.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace KroppensHyllning.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ICampaignRepository, CampaignRepository>();
        return services;
    }
}
