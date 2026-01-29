using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador
{
    public class UserDB {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Permisos { get; set; }
        public byte[] Huella { get; set; }
        public string HuellaStr { get; set; }
    }
    public static class Huellas
    {
        public static List<UserDB> ListHuellas = new();
    }
}
