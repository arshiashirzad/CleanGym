using ErrorOr;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{ 
    private readonly ISender _mediator; 
    public SubscriptionsController( ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(createSubscriptionRequest request)
    {
        var command =new CreateSubscriptionCommand(request.SubscriptionType.ToString() ,
            request.adminId
            );
        var createSubscriptionResult= await _mediator.Send(command);
        return createSubscriptionResult.MatchFirst(subscription => Ok(new SubscriptionResponse(subscription.id, request.SubscriptionType)),
            error => Problem());
    }
}