using Mezclador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.ViewModels
{
	public class CalidadViewModel
	{
		public string? Id { get; set; }
		public string? Usuario { get; set; }
        public string? Fecha { get; set; }
        public string? Comentario { get; set; }

        //public UsuarioModel? UsuarioNavigation { get; set; }
    }
}
