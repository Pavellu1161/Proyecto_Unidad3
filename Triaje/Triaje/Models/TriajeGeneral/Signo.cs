using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models.TriajeGeneral
{
    public class Signo
    {
        [Key]
        public int IdSignoGeneral { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public int IdPrioridadGeneral { get; set; }
        [Display(Name = "Prioridad")]
        [ForeignKey("IdPrioridadGeneral")]
        public TipoPrioridad TipoPrioridades { get; set; }
        public int IdTipoSignoGeneral { get; set; }
        [Display(Name = "TipoSigno")]
        [ForeignKey("IdTipoSignoGeneral")]
        public TipoSigno TipoSignos { get; set; }
    }
}
