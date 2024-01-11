using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullStack.Core.Models;
using FullStack.Repo.Data;
using FullStack.Service.Interfaces;
using FullStack.Repo.GenericRepository.Interface;

namespace FullStack.Service.Services
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEmployeeForDepartement(int departementId, Employee employee)
        {
            employee.DepartementId = departementId;
            await CreateAsync(employee);
        }

        public async Task DeleteEmployee(Employee employee) => await RemoveAsync(employee);

        public async Task<Employee?> GetEmployee(int departementId, int employeeId, bool trackChanges)
            => await FindByConditionAsync(e => e.DepartementId.Equals(departementId) && e.Id.Equals(employeeId), trackChanges).Result.SingleOrDefaultAsync();


        Task<IEnumerable<object>> IEmployeeRepository.GetEmployeesByDepartment(int departmentId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
