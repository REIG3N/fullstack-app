using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStack.Core.Models
{
    public class Departement
    {
        [Column("DepartementId")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Departement is a required field.")]
        [MaxLength(2, ErrorMessage = "Maximum length for the Departement is 2 characters.")]
        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
