using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Service.Interfaces
{
    public interface IRepositoryManager
    {
        public IDepartementRepository Departement { get; }
        public IEmployeeRepository Employee { get; }
        public Task SaveAsync();
    }
}
