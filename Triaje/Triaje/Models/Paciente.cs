using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models
{
    public class Paciente
    {
        [Key]
        [Required(ErrorMessage = "La identidad es obligatoria.")]
        [Display(Name = "Identidad")]
        [MinLength(13, ErrorMessage = "La identidad no debe ser mayor a 15 caracteres.")]
        [MaxLength(13, ErrorMessage = "La identidad no debe ser mayor a 15 caracteres.")]
        public string IdentidadPaciente { get; set; }
        [Required(ErrorMessage = "Los nombres son requeridos.")]
        [Display(Name = "Nombres Paciente")]
        [StringLength(60, ErrorMessage = "No debe tener más de 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Debe tener más de 5 caracteres.")]
        public string NombresPaciente { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        [Display(Name = "Apellidos Paciente")]
        [StringLength(60, ErrorMessage = "No debe tener más de 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Debe tener más de 5 caracteres.")]
        public string ApellidosPaciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contacto { get; set; }
        public int NumeroContacto { get; set; }
        public IEnumerable<Consulta> Consultas { get; set; }
        public IEnumerable<ConsultaPediatria> Pediatrias { get; set; }
    }
}
