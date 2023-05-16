using EmprestimoLivro.Data;
using Microsoft.AspNetCore.Mvc;
using EmprestimoLivro.Models;

namespace EmprestimoLivro.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _context;

        public EmprestimoController(ApplicationDbContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimoModel> emprestimos = _context.Emprestimos;
            return View(emprestimos);
        }
    }
}
