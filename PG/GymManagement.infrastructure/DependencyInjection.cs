using GymManagement.Application.Common.Interfaces;
using GymManagement.infrastructure.Subscriptions.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // services.AddMediatR(options =>
        // {
        //     options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
        // });
        services.AddScoped<ISubscriptionsRepository , SubscriptionsRepository>();
        return services;
    }
}