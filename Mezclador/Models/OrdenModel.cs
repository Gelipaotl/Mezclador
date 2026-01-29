using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.Models
{
	public class OrdenModel
	{
		public int Id { get; set; }
		public string? Orden { get; set; }
		public int IdProducto { get; set; }
		public float CantidadRequerida { get; set; }
		public int ProductosRequeridos { get; set; }
		public string? Status { get; set; }

		public ProductoModel? ProductoNavigation { get; set; }
	}
}
