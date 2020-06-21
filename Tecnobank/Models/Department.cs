using System.ComponentModel.DataAnnotations;

namespace Tecnobank.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
    }
}