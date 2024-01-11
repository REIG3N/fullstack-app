using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStack.Core.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Departement { get; set; }

    }
    public class EmployeeCreationDto : EmployeeAddUpdateDto
    {

    }

    public class EmployeeUpdateDto : EmployeeAddUpdateDto
    {

    }

    public abstract class EmployeeAddUpdateDto
    {
        [Column("EmployeeId")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is a required field.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Email is not in correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is a required field.")]
        [Range(100000000, 999999999, ErrorMessage = "Phone must be a 9-digit number.")]
        public long Phone { get; set; }


        [Required(ErrorMessage = "Salary is a required field.")]
        [Range(4000, long.MaxValue, ErrorMessage = "Salary must be at least 4000.")]
        public long Salary { get; set; }

    }
}
