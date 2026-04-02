using Microsoft.AspNetCore.Mvc;

namespace waitinglist.Features.Admin;

[Route("[controller]/[action]")]
public class AdminController : Controller
{
    private readonly AdminService _service;

    public AdminController(AdminService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Dashboard()
    {
        return View(_service.GetDashboard());
    }
}

