using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.Models
{
    public class MaterialModel
    {
        public string? Material { get; set; }
        public string? Nombre { get; set; }
        public bool Escaneable { get; set; }
        public string? Codigo { get; set; }
        public bool Saco { get; set; }
        public string? PesoSaco { get; set; }
        public bool esAceite { get; set; }
        public double? Factor { get; set; }
        public Image? Imagen { get; set; }
    }
}
