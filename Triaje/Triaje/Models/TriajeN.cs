using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Triaje.Models
{
    public class TriajeN
    {
        [Key]
        public int IdConsultaN { get; set; }
        public bool Tuberculosis { get; set; }
        public bool Gripe { get; set; }
    }
}
