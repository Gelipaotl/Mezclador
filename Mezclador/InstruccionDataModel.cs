using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador
{
    public class InstruccionDataModel
	{
		public int IdInstruccion { get; set; }
		public int IdMaterial { get; set; }
		public string? Material { get; set; }
        public string? Nombre { get; set; }
        public Image? Imagen { get; set; }
        public double Cantidad { get; set; }
        public bool Escaneable { get; set; }
        public string? Codigo { get; set; }
        public bool Saco { get; set; }
        public double PesoSaco { get; set; }
        public bool esAceite { get; set; }
        public double Factor { get; set; }
        public bool Passed { get; set; } = false;
		public bool Habilitado { get; set; }
        public int Paso { get; set; }
        public bool Ligera { get; set; }
        public bool Pesada { get; set; }

    }
}
