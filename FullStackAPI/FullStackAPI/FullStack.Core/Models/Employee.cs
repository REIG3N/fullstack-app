using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStack.Core.Models
{
    public class Employee
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


        [ForeignKey(nameof(Departement))]
        public int DepartementId { get; set; }


        public Departement? Departement { get; set; }



    }
}
