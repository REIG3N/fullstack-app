using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Core.Models;

namespace FullStack.Service.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int departementId, int employeeId, bool trackChanges);
        Task CreateEmployeeForDepartement(int departementId, Employee employee);
        Task DeleteEmployee(Employee employee);
        Task<IEnumerable<object>> GetEmployeesByDepartment(int departmentId, bool trackChanges);
    }
}
