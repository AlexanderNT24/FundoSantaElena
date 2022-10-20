using Microsoft.AspNetCore.Mvc;

namespace FundoSantaElena.Controllers
{
    public class ChatBot : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
