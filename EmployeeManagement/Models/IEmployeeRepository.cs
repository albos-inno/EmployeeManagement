using System.Collections.Generic;

namespace EmployeeManagement.Models
{
     public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        List<Employee> GetAllEmployees();

        
        Employee Add(Employee employee);


    }
}
