using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador
{
    public class OrdenViewModel
    {
        public int Id {get; set; }
        public string? Orden { get; set; }
        public string? Producto { get; set; }
        public string? Usuario { get; set; }
        public string? Inicio { get; set; }
        public string? Fin { get; set; }
    }
}
