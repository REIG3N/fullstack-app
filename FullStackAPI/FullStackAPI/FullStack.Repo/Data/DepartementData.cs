using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FullStack.Core.Models;


namespace FullStack.Repo.Data
{
    public class DepartementData : IEntityTypeConfiguration<Departement>
    {
        public void Configure(EntityTypeBuilder<Departement> builder)
        {
            builder.HasData(
                new Departement
                {
                    Id = 1,
                    Name = "PO",
                },

                new Departement
                {
                    Id = 2,
                    Name = "IT",
                },

                new Departement
                {
                    Id = 3,
                    Name = "RH",
                });
        }
    }
}
