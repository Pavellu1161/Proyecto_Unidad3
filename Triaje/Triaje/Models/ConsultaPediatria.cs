using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models
{
    public class ConsultaPediatria
    {
        [Key]
        public int IdConsulta { get; set; }
        [Display(Name = "Hemorragia Incontrolable")]
        public bool Hemorragia_Incontrolable { get; set; }
        [Display(Name = "Herida de Arma")]
        public bool Herida_Arma { get; set; }
        [Display(Name = "Gran Quemado")]
        public bool Gran_Quemado { get; set; }
        [Display(Name = "Dengue Grave")]
        public bool Dengue_Grave { get; set; }
        [Display(Name = "Mordeduras Graves")]
        public bool Mordeduras_Graves { get; set; }

        [Display(Name = "Paciente Oncológico")]
        public bool Paciente_Oncologico { get; set; }
        [Display(Name = "Estridor Laringeo")]
        public bool Estridor_Laringeo { get; set; }
        [Display(Name = "Trauma Ocular")]
        public bool Trauma_Ocular { get; set; }
        [Display(Name = "Varicela Sobreinfectada")]
        public bool Varicela_Sobreinfectada { get; set; }
        [Display(Name = "Ingesta Cuerpos Extraños")]
        public bool Ingesta_Cuerpos_Extraños { get; set; }

        [Display(Name = "Cafalea Aguda")]
        public bool Cafalea_Aguda { get; set; }
        [Display(Name = "Urticaria")]
        public bool Urticaria { get; set; }
        [Display(Name = "Otalgia")]
        public bool Otalgia { get; set; }
        [Display(Name = "Dolor Torácico")]
        public bool Dolor_Toracico { get; set; }
        [Display(Name = "Contusiones Menores")]
        public bool Contusiones_Menores { get; set; }

        [Display(Name = "Patología Respiratoria")]
        public bool Patologia_Respiratoria { get; set; }
        [Display(Name = "Dolor de Garganta")]
        public bool Dolor_Garganta { get; set; }
        [Display(Name = "Estreñimiento Cronico")]
        public bool Estrenimiento_Cronico { get; set; }
        [Display(Name = "Dolor Abdominal")]
        public bool Dolor_Abdominal { get; set; }
        [Display(Name = "Curaciones")]
        public bool Curaciones { get; set; }

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
