using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; } = new Employee();
        public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
    }
}