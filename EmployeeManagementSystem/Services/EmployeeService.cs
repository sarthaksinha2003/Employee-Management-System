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
        public List<Employee> GetEmployees()
        {
            return this.context.Employees.ToList();
        }
        public Employee? GetEmployeeById(int id)
        {   
            return this.context.Employees.FirstOrDefault(emp => emp.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee? currentEmployee = this.context.Employees.Find(employee.Id);
            if(currentEmployee == null)
            {
                return;
            }
            currentEmployee.Name = employee.Name;
            currentEmployee.Department = employee.Department;
            currentEmployee.Salary = employee.Salary;

            context.SaveChanges();

            //this.context.Employees.Update(employee);
            //this.context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee? employee = this.context.Employees.Find(id);
            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                this.context.SaveChanges();
            }
        }
    }
}