using Microsoft.AspNetCore.Mvc;

namespace TestMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
