using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy ="EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "RequireManager")]
        public IActionResult Manager() 
        {
            return Manager();
        }

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Admin() 
        {
            return Admin();
        }

    }
}
