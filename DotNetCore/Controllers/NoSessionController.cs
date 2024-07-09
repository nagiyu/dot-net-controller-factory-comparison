using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Controllers
{
    [SessionBehavior(SessionBehavior.Disabled)]
    public class NoSessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
