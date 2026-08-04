using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<IActionResult> List()
        {
            List<Department> departments = await departmentService.GetDepartmentsAsync();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            await departmentService.AddDepartmentAsync(department);
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Details(int id)
        {
            Department? department = await departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Department? department = await departmentService.GetDepartmentByIdAsync(id);
            if(department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Department department)
        {
            if(!ModelState.IsValid)
            {
                return View(department);
            }
            await departmentService.UpdateDepartmentAsync(department);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            Department? department = await departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Department department)
        {
            await departmentService.DeleteDepartmentAsync(department.Id);
            return RedirectToAction(nameof(List));
        }
    }
}