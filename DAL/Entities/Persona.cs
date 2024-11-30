using System.ComponentModel.DataAnnotations;

namespace CashFlow_API.DAL.Entities
{
    public class Persona : AuditBase
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string  Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellido { get; set; }

        [Display(Name = "Cédula")]
        [Range(1, 9999999999, ErrorMessage = "El campo {0} debe ser un número positivo y válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public long Cedula { get; set; }

        //Relación con la tabla Gasto
        [Display(Name = "Gastos")]
        public ICollection<Gasto>? Gastos { get; set; }

    }
}
