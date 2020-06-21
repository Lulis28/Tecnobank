using System.ComponentModel.DataAnnotations;

namespace Tecnobank.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Employee()
        {
            Department = new Department();
        }


    }
}