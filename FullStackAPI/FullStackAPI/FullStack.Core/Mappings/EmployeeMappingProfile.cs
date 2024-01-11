using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FullStack.Core.Dtos;
using FullStack.Core.Models;

namespace FullStack.Core.Mappings
{
    public class EmployeeMappingProfile: Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeCreationDto, Employee>();

            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        }
    }
}
