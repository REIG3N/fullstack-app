using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Core.Models;

namespace FullStack.Service.Interfaces
{
    public interface IDepartementRepository
    {
        Task<IEnumerable<Departement>> GetAllDepartements(bool trackChanges);
        Task<Departement> GetDepartement(int departementId, bool trackChanges);
        Task CreateDepartement(Departement departement);
    }
}
