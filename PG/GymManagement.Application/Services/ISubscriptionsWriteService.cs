namespace GymManagement.Application.Services;

public interface ISubscriptionsWriteService
{
    Guid CreateSubscription(string Subscriptiontype, Guid adminId);
}