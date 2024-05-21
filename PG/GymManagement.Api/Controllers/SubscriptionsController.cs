using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{ 
    private readonly Mediator _mediator; 
    public SubscriptionsController( Mediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(createSubscriptionRequest request)
    {
        var command = CreateSubscriptionCommand(request.SubscriptionType.ToString() ,
            request.adminId
            );
        var subscriptionId= await _mediator.Send(command);
        var response = new SubscriptionResponse(
            subscriptionId,
            request.SubscriptionType);
        return Ok(response);
    }
}