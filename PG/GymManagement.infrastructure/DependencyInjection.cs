using GymManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISubscriptionsWriteService, SubscriptionsWriteService>();
        return services;
    }
}