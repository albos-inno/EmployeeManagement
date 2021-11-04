using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Albos1", Departament = Dept.HR, Email = "albos1@innosolutions.io"},
                new Employee() { Id = 2, Name = "Albos2", Departament = Dept.IT, Email = "albos2@innosolutions.io"},
                new Employee() { Id = 3, Name = "Albos3", Departament = Dept.Payroll, Email = "albos3@innosolutions.io"}
            };
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.Find(e => e.Id == Id);
        }


        public List<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;

            _employeeList.Add(employee);
            return employee;
        }
    }
}
