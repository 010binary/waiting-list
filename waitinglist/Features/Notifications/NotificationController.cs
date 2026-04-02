using Microsoft.AspNetCore.Mvc;

namespace waitinglist.Features.Notifications;

[Route("[controller]/[action]")]
public class NotificationController : Controller
{
    private readonly NotificationService _service;

    public NotificationController(NotificationService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(_service.GetNotifications());
    }
}

