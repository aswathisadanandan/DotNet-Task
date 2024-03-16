using EmployeeData.Data;
using EmployeeData.Models;
using EmployeeData.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext dbContex;

        public EmployeesController(ApplicationDbContext dbContex)
        {
            this.dbContex = dbContex;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                Name = viewModel.Name,
                
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Place = viewModel.Place,
                Description = viewModel.Description,
            };
            await dbContex.Employeess.AddAsync(employee);
            await dbContex.SaveChangesAsync();
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employees =  await dbContex.Employeess.ToListAsync();
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContex.Employeess.FindAsync(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContex.Employeess.FindAsync(viewModel.Id);
            if(employee is not null)
            {
                employee.Name= viewModel.Name;
                employee.Email= viewModel.Email;
                employee.Phone= viewModel.Phone;
                employee.Place= viewModel.Place;
                employee.Description= viewModel.Description;
                await dbContex.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel)
        {
            var employee = await dbContex.Employeess.FindAsync(viewModel.Id);
            if(employee is not null)
            {
                dbContex.Employeess.Remove(viewModel);
                await dbContex.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
    }
}
