using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Enums;
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
        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await context.Departments.AddAsync(department);
            await context.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            Department? existingDepartment = await context.Departments.FindAsync(department.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                await context.SaveChangesAsync();
            }
        }

        public async Task<DeleteDepartmentResult> DeleteDepartmentAsync(int id)
        {
            Department? department = await context.Departments.FindAsync(id);
            if(department == null)
            {
                return DeleteDepartmentResult.NotFound;
            }

            bool hasEmployees = await context.Employees.AnyAsync(e => e.DepartmentId == id);
            if(hasEmployees) 
            {
                return DeleteDepartmentResult.HasEmployees;
            }
            context.Departments.Remove(department);
            await context.SaveChangesAsync();
            return DeleteDepartmentResult.Success;
        }
    }
}