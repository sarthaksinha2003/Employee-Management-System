using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly DashboardService dashboardService;
        private readonly ILogger<HomeController> logger;
        public HomeController(DashboardService dashboardService, ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel vm = new DashboardViewModel();
            vm.TotalEmployees = await dashboardService.GetTotalEmployeesAsync();
            vm.TotalDepartments = await dashboardService.GetTotalDepartmentsAsync();
            vm.AverageSalary = await dashboardService.GetAverageSalaryAsync();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
