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
    public class DepartementRepository : RepositoryBase<Departement>, IDepartementRepository
    {
        public DepartementRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateDepartement(Departement departement) => await CreateAsync(departement);

        public async Task<IEnumerable<Departement>> GetAllDepartements(bool trackChanges)
            => await FindAllAsync(trackChanges).Result.OrderBy(c => c.Name).ToListAsync();

        public async Task<Departement> GetDepartement(int departementId, bool trackChanges)
            => await FindByConditionAsync(c => c.Id.Equals(departementId), trackChanges).Result.SingleOrDefaultAsync();
    }
}
