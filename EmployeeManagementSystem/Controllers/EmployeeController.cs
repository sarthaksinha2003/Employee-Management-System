using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        private readonly DepartmentService departmentService;
        public EmployeeController(EmployeeService employeeService, DepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }   

        public async Task<IActionResult> List()
        {
            List<Employee> employees = await this.employeeService.GetEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            Employee? employee = await employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            EmployeeFormViewModel vm = await BuildEmployeeFormViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeFormViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                vm = await BuildEmployeeFormViewModel(vm.Employee);
                return View(vm);
            }
            await this.employeeService.AddEmployeeAsync(vm.Employee);
            TempData["Success"] = "Employee created successfully!";
            return RedirectToAction(nameof(List));
        }

        private async Task<EmployeeFormViewModel> BuildEmployeeFormViewModel(Employee? employee = null)
        {
            var departments = await departmentService.GetDepartmentsAsync();

            EmployeeFormViewModel vm = new EmployeeFormViewModel();
            vm.Employee = employee ?? new Employee();

            List<SelectListItem> departmentItems = new List<SelectListItem>();

            foreach (Department department in departments)
            {
                SelectListItem item = new SelectListItem();

                item.Value = department.Id.ToString();
                item.Text = department.Name;

                departmentItems.Add(item);
            }

            vm.Departments = departmentItems;

            return vm;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee? currentEmployee = await employeeService.GetEmployeeByIdAsync(id);
            if (currentEmployee == null)
            {
                return View(null);
            }

            EmployeeFormViewModel vm = await BuildEmployeeFormViewModel(currentEmployee);
            return View(vm);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(EmployeeFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm = await BuildEmployeeFormViewModel(vm.Employee);
                return View(vm);
            }

            await employeeService.UpdateEmployeeAsync(vm.Employee);
            TempData["Success"] = "Employee updated successfully.";
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
            TempData["Success"] ="Employee deleted successfully.";
            return RedirectToAction(nameof(List));
        }
    }
}