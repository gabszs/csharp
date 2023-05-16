using ASPNETMVCCRUD.data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext _dbContext;

        public EmployeesController(MVCDemoDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _dbContext.employess.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            try
            {
                var employee = await _dbContext.employess.FirstOrDefaultAsync(x => x.Id == Id);
                if (employee != null)
                {
                    var viewModel = new UpdateEmployeeViewModel()
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Salary = employee.Salary,
                        Department = employee.Department,
                        DateOfBirth = employee.DateOfBirth
                    };
                    return await Task.Run(() => View("View", viewModel));

                }
                else { TempData["MensagemNull"] = "O site nao conseguiu encontrar o funcionario, Id Nulo"; }

                return RedirectToAction("Index");
            }

            catch (Exception error)
            {
                TempData["MessagemErro"] = $"Houve um erro ({error.Message}) no cadastro do contato";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await _dbContext.employess.FindAsync(model.Id);
            try
            {
                if (employee != null)
                {
                    employee.Name = model.Name;
                    employee.Email = model.Email;
                    employee.Salary = model.Salary;
                    employee.Department = model.Department;
                    employee.DateOfBirth = model.DateOfBirth;

                    await _dbContext.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Funcionario editado com sucesso";
                    return RedirectToAction("Index");
                }
                else { TempData["MensagemNull"] = "O site nao conseguiu encontrar o funcionario, Id Nulo"; }

                return RedirectToAction("Index");

            }
            catch (Exception error)
            {
                TempData["MessagemErro"] = $"Houve um erro ({error.Message}) na edicao do empregado";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await _dbContext.employess.FindAsync(model.Id);

            if (employee != null)
            {
                _dbContext.employess.Remove(employee);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmloyeeViewModel addEmployeeRequest)
        {
            try
            {
                Employee employee = new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = addEmployeeRequest.Name,
                    Email = addEmployeeRequest.Email,
                    Department = addEmployeeRequest.Department,
                    Salary = addEmployeeRequest.Salary,
                    DateOfBirth = addEmployeeRequest.DateOfBirth,
                };

                await _dbContext.employess.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                TempData["MensagemSucesso"] = "Funcionario cadastrado com sucesso";
                return RedirectToAction("Add");
            }
            catch (Exception error)
            {
                TempData["MessagemErro"] = $"Houve um erro ({error.Message}) na cadastro do empregado";
                return RedirectToAction("Add");
            }
        }
    }
}
