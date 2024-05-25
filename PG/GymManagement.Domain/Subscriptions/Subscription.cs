namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    public Guid id { get; set; }
    public string SubscriptionType{ get; set; } = null!;
}