using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models
{
    public class Personal
    {
        [Key]
        [Required(ErrorMessage = "La identidad es obligatoria.")]
        [Display(Name = "Identidad")]
        [MinLength(15, ErrorMessage = "La identidad no debe ser mayor a 13 caracteres.")]
        [MaxLength(15, ErrorMessage = "La identidad no debe ser mayor a 13 caracteres.")]
        public string IdentidadPersonal { get; set; }
        [Required(ErrorMessage = "Los nombres son requeridos.")]
        [Display(Name = "Nombres Personal")]
        [StringLength(60, ErrorMessage = "No debe tener más de 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Debe tener más de 5 caracteres.")]
        public string NombresPersonal { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        [Display(Name = "Apellidos Personal")]
        [StringLength(60, ErrorMessage = "No debe tener más de 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Debe tener más de 5 caracteres.")]
        public string ApellidosPersonal { get; set; }
        public int IdRol { get; set; }
        [Display(Name = "Rol")]
        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
        public IEnumerable<Consulta> Consultas { get; set; }

        public IEnumerable<ConsultaPediatria> Pediatrias { get; set; }
    }
}
