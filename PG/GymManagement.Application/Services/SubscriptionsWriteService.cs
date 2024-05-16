namespace GymManagement.Application.Services;

public class SubscriptionsWriteService : ISubscriptionsWriteService
{
    public Guid CreateSubscription(string SubscriptionType, Guid adminId)
    {
        return Guid.NewGuid();
    }
}