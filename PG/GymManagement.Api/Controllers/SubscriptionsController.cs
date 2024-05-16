using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;
namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{

    private readonly ISubscriptionsWriteService _subscriptionsservice;

    public SubscriptionsController(ISubscriptionsWriteService subscriptionsservice)
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