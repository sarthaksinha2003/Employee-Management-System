using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new();
            Employee ep1 = new();
            ep1.Id = 1;
            ep1.Name = "Sarthak";
            ep1.Department = "IT";
            ep1.Salary = 50000;
            employees.Add(ep1);

            Employee ep2 = new();
            ep2.Id = 2;
            ep2.Name = "Rahul";
            ep2.Department = "IT";
            ep2.Salary = 45000;
            employees.Add(ep2);

            Employee ep3 = new();
            ep3.Id = 3;
            ep3.Name = "PinkMan";
            ep3.Department = "Sales";
            ep3.Salary = 30000;
            employees.Add(ep3);

            return employees;
        }
        public Employee? GetEmployeeById(int id)
        {
            List<Employee> employees = GetEmployees();
            foreach(Employee emp in employees)
            {
                if(emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }
    }
}