using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        static List<Employee> employees = new List<Employee>();
        public List<Employee> GetEmployees()
        {
            return employees;
        }
        public Employee? GetEmployeeById(int id)
        {
            //List<Employee> employees = GetEmployees();
            foreach(Employee emp in employees)
            {
                if(emp.Id == id)
                {
                    return emp;
                }
            }
            return null;
        }

        public void AddEmployee(Employee employee)
        {
            int maxId = 0;
            foreach (Employee emp in employees)
            {
                if (emp.Id > maxId)
                {
                    maxId = emp.Id;
                }
            }
            employee.Id = maxId+1;
            employees.Add(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }

            foreach(Employee emp in employees)
            {
                if(employee.Id == emp.Id)
                {
                    emp.Name = employee.Name;
                    emp.Department = employee.Department;
                    emp.Salary = employee.Salary;
                    return true;
                }
            }

            return false;
        }

        public bool DeleteEmployee(int id)
        {
            foreach (Employee emp in employees)
            {
                if (id == emp.Id)
                {
                    employees.Remove(emp);
                    return true;
                }
            }

            return false;
        }
    }
}