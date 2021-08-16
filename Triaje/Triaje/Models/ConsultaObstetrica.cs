using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models
{
    public class ConsultaObstetrica
    {
        [Key]
        public int IdConsulta { get; set; }
        [Display(Name = "Paro Cardiorespiratorio")]
        public bool Paro_Cardiorespiratorio { get; set; }
        [Display(Name = "Crisis Convulsiva")]
        public bool Crisis_Convulsiva { get; set; }
        [Display(Name = "Dolor en CSD o epigastrio")]
        public bool Dolor_CSD { get; set; }
        [Display(Name = "Movimientos Fetales")]
        public bool Movimientos_Fetales { get; set; }



        [Display(Name = "Presion arterial sistolica")]
        public string sistolica { get; set; }

        [Display(Name = "Presion arterial diastolica")]
        public string diastolica { get; set; }


        [Display(Name = "Saturacion de Oxigeno")]
        public string saturacion { get; set; }
        [Display(Name = "Frecuencia Cardiaca Materna")]
        public string Frecuencia_Cardiaca { get; set; }
        [Display(Name = "Temperatura Axilar")]
        public string Temperatura_Axilar { get; set; }
        [Display(Name = "Frecuencia Respiratoria")]
        public string Frecuencia_Respiratoria { get; set; }



       

        public string IdentidadPaciente { get; set; }
        [Display(Name = "Paciente")]
        [ForeignKey("IdentidadPaciente")]
        public Paciente Paciente { get; set; }

        public string IdentidadPersonal { get; set; }
        [Display(Name = "Empleado")]
        [ForeignKey("IdentidadPersonal")]
        public Personal Personal { get; set; }

        [Display(Name = "Comentario")]
        public string Comentario { get; set; }
    }
}
