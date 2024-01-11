using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FullStack.Repo.Data
{
        public class EmployeeData : IEntityTypeConfiguration<Employee> 
        {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                builder.HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Azeez",
                        Email = "Azeez@email.com",
                        Phone = 123456789,
                        Salary = 1111,
                        DepartementId = 1,
                    },

                    new Employee
                    {
                        Id = 2,
                        Name = "Kamal",
                        Email = "Kamal@email.com",
                        Phone = 123456789,
                        Salary = 1111,
                        DepartementId = 2
                    },

                    new Employee
                    {
                        Id = 3,
                        Name = "Benson",
                        Email = "Benson@email.com",
                        Phone = 123456789,
                        Salary = 1111,
                        DepartementId = 3
                    });
            }
        }
    }

