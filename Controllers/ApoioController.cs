using Microsoft.AspNetCore.Mvc;

namespace RFB.Controllers
{
    public class ApoioController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Novas linguagens de programação";
            return View();
        }
    }
}
