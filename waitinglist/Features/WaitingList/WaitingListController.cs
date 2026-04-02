using Microsoft.AspNetCore.Mvc;

namespace waitinglist.Features.WaitingList;

[Route("[controller]/[action]")]
public class WaitingListController : Controller
{
    private readonly WaitingListService _service;

    public WaitingListController(WaitingListService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new WaitingListViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Confirm(WaitingListViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        return View(_service.Register(model));
    }
}

