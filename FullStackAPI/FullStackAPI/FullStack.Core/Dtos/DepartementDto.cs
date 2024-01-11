using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStack.Core.Dtos;

namespace FullStack.Core.Dtos
{
    public class DepartementDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

public class DepartementCreationDto : DepartementAddAndUpdateDto
{
}

public class DepartementUpdateDto : DepartementAddAndUpdateDto
{
}

public abstract class DepartementAddAndUpdateDto
{
    [Required(ErrorMessage = "Departement name is a required field.")]
    [MaxLength(2, ErrorMessage = "Maximum length for the Name is 2 characters.")]
    public string? Name { get; set; }

    public IEnumerable<EmployeeCreationDto>? Employees { get; set; }
}