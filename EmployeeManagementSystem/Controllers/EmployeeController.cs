using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
    }
}