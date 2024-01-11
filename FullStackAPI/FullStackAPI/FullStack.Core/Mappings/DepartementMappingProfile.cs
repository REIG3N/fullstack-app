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
    public class DepartementMappingProfile : Profile
    {
        public DepartementMappingProfile() 
        {
            CreateMap<Departement, DepartementDto>();

            CreateMap<DepartementCreationDto, Departement>();

            CreateMap<DepartementUpdateDto, Departement>().ReverseMap();
        }

    }
}
