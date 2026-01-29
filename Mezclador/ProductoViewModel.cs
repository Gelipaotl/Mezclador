using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Producto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        //public Image Imagen { get; set; }
    }
}
