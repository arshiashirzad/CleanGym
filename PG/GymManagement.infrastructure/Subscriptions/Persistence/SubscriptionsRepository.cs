namespace GymManagement.infrastructure.Subscriptions.Persistence;
using GymManagement.infrastructure.Common.Persistence;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
public class SubscriptionsRepository : ISubscriptionsRepository
{
    private readonly  GymManagementDbContext _dbContext;

    public SubscriptionsRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _dbContext.Subscriptions.AddAsync(subscription);
    }
    public async Task<Subscription?> GetByIdAsync(Guid subscriptionId)
    {
        return await _dbContext.Subscriptions.FindAsync(subscriptionId);
    }
}