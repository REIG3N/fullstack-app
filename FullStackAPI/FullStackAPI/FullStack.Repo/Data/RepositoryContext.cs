using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using FullStack.Core.Models;
using FullStack.Core.Dtos;

namespace FullStack.Repo.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartementData());
            modelBuilder.ApplyConfiguration(new EmployeeData());
        }
     

        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
