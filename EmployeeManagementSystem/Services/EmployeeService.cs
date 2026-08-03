using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext context;
        public EmployeeService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await this.context.Employees
                .Include(e=>e.Department)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {   
            return await this.context.Employees
                .Include (e=>e.Department)
                .FirstOrDefaultAsync(emp => emp.Id == id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await this.context.Employees.AddAsync(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            // type 1 for updation

            Employee? currentEmployee = await this.context.Employees.FindAsync(employee.Id);
            if(currentEmployee == null)
            {
                return;
            }
            currentEmployee.Name = employee.Name;
            currentEmployee.DepartmentId = employee.DepartmentId;
            currentEmployee.Salary = employee.Salary;

            await context.SaveChangesAsync();

            // type 2 for updation

            //this.context.Employees.Update(employee);
            //this.context.SaveChanges();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            Employee? employee = await this.context.Employees.FindAsync(id);
            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                await this.context.SaveChangesAsync();
            }
        }
    }
}