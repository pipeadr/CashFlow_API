using System.ComponentModel.DataAnnotations;

namespace CashFlow_API.DAL.Entities
{
    public class Gasto : AuditBase
    {
        [Display(Name = "Referencia")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Referencia { get; set; }

        [Display(Name = "ValorGasto")]
        [Range(0, 9999999999.9, ErrorMessage = "El campo {0} debe ser un número positivo y válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public float VlrGasto { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Descripcion { get; set; }
    }
}
