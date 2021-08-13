using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models.TriajeGeneral
{
    public class TipoSigno
    {
        [Key]
        public int IdTipoSignoGeneral { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public IEnumerable<Signo> Signos { get; set; }
    }
}
