using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> List()
        {
            List<Employee> employees = await this.employeeService.GetEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            Employee? employee = await employeeService.GetEmployeeByIdAsync(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return View(employee);
            }
            await this.employeeService.AddEmployeeAsync(employee);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Employee? currentEmployee = await employeeService.GetEmployeeByIdAsync(id);
            if (currentEmployee == null)
            {
                return View(null);
            }

            return View(currentEmployee);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            await employeeService.UpdateEmployeeAsync(employee);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee? employee = await employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            await this.employeeService.DeleteEmployeeAsync(employee.Id);

            return RedirectToAction(nameof(List));
        }
    }
}