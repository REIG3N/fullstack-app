using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Repo.Data;
using FullStack.Service.Interfaces;

namespace FullStack.Service.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        public RepositoryContext _repositoryContext;

        public IDepartementRepository _departementRepository;
        public IEmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IDepartementRepository Departement
        {
            get
            {
                if (_departementRepository is null)
                    _departementRepository = new DepartementRepository(_repositoryContext);
                return _departementRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository is null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
