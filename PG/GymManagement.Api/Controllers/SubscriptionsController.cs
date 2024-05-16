using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;
namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{

    private readonly ISubscriptionsService _subscriptionsservice;

    public SubscriptionsController(ISubscriptionsService subscriptionsservice)
    {
        _subscriptionsservice = subscriptionsservice;
    }

    [HttpPost]
    public IActionResult CreateSubscription(createSubscriptionRequest request)
    {
        var subscriptionId=  _subscriptionsservice.CreateSubscription(request.SubscriptionType.ToString(), request.adminId);
        var response = new SubscriptionResponse(subscriptionId, request.SubscriptionType);

        return Ok(response);
    }
}