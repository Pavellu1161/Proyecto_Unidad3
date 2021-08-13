using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El nombre del rol es requerido.")]
        [Display(Name = "Nombre Rol")]
        [StringLength(30, ErrorMessage = "No debe tener más de 30 caracteres.")]
        [MinLength(5, ErrorMessage = "Debe tener más de 5 caracteres.")]
        public string NombreRol { get; set; }
        public IEnumerable<Personal> Personals { get; set; }
    }
}
