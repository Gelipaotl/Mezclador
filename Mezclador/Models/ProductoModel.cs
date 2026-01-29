using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.Models
{
    public class ProductoModel
	{
		public int Id { get; set; }
		public string Producto { get; set; } = string.Empty;
		public string Nombre { get; set; } = string.Empty;
	}
}
