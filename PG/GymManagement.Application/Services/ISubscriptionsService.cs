namespace GymManagement.Application.Services;

public interface ISubscriptionsService
{
    Guid CreateSubscription(string Subscriptiontype, Guid adminId);
}