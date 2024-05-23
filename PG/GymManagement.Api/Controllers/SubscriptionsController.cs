using ErrorOr;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
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
        return createSubscriptionResult.MatchFirst(guid => Ok(new SubscriptionResponse(guid, request.SubscriptionType)),
            error => Problem());
        // if (createSubscriptionId.IsError)
        // {
        //     return Problem();
        // }
        // var response = new SubscriptionResponse(
        //     createSubscriptionId.Value,
        //     request.SubscriptionType);
        // return Ok(response);
    }
}