using MediatR;
using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand , ErrorOr<Subscription> >
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionsRepository = subscriptionsRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        //create subscription
        var subscription = new Subscription
        {
            id = Guid.NewGuid(),
            SubscriptionType = request.SubscriptionType
        };
        //add to DB
        await _subscriptionsRepository.AddSubscriptionAsync(subscription);
        await _unitOfWork.CommitChangesAsync();
        return subscription;
    }
}