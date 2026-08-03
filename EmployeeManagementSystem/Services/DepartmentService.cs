using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService
    {
        public readonly ApplicationDbContext context;
        public DepartmentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await context.Departments
                .AsNoTracking()
                .OrderBy(d=>d.Name)
                .ToListAsync();
        }
    }
}