using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Triaje.Models.TriajeGeneral;

namespace Triaje.Models
{
    public class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string MotivoConsulta { get; set; }
        public int IdSignoGeneral { get; set; }
        [Display(Name = "Signo")]
        [ForeignKey("IdSignoGeneral")]
        public Signo Signo { get; set; }
        public string HoraTriaje { get; set; }
        public string IdentidadPaciente { get; set; }
        [Display(Name = "Paciente")]
        [ForeignKey("IdentidadPaciente")]
        public Paciente Paciente { get; set; }
        public string IdentidadPersonal { get; set; }
        [Display(Name = "Empleado")]
        [ForeignKey("IdentidadPersonal")]
        public Personal Personal { get; set; }
    }
}
