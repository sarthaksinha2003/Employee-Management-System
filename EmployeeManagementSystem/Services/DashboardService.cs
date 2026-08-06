using EmployeeManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class DashboardService
    {
        private readonly ApplicationDbContext context;

        public DashboardService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> GetTotalEmployeesAsync()
        {
            return await context.Employees.CountAsync();
        }

        public async Task<int> GetTotalDepartmentsAsync()
        {
            return await context.Departments.CountAsync();
        }

        public async Task<double> GetAverageSalaryAsync()
        {
            if(await context.Employees.CountAsync() == 0)
            {
                return 0;
            }
            return await context.Employees.AverageAsync(e => e.Salary);
        }

        public async Task<double> GetTotalSalaryAsync()
        {
            if(await context.Employees.CountAsync() == 0)
            {
                return 0;
            }
            return await context.Employees.SumAsync(e => e.Salary);
        }

        public async Task<Double> GetHighestSalaryAsync()
        {
            if (await context.Employees.CountAsync() == 0)
            {
                return 0;
            }
            return await context.Employees.MaxAsync(e => e.Salary);
        }
    }
}
