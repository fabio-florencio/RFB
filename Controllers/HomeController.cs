using Microsoft.AspNetCore.Mvc;
using RFB.Models;
using System.Diagnostics;
using Vereyon.Web;

namespace RFB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlashMessage _flashmessage;

        public HomeController(ILogger<HomeController> logger, IFlashMessage flashMessage)
        {
            _logger = logger;
            _flashmessage = flashMessage;
        }

        public IActionResult Index()
        {
            _flashmessage.Warning("Teste de mensagem");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aula()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
