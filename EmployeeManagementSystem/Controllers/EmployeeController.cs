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

        public IActionResult List()
        {
            List<Employee> employees = this.employeeService.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            Employee? employee = employeeService.GetEmployeeById(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return View(employee);
            }
            this.employeeService.AddEmployee(employee);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            Employee? currentEmployee = employeeService.GetEmployeeById(id);
            if (currentEmployee == null)
            {
                return View(null);
            }

            return View(currentEmployee);
        }

        [HttpPost]

        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            employeeService.UpdateEmployee(employee);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee? employee = employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            this.employeeService.DeleteEmployee(employee.Id);

            return RedirectToAction(nameof(List));
        }
    }
}