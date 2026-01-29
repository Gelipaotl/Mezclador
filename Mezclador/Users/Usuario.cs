using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Mezclador.Users
{
    public static class Usuario
    {
        public enum Permisos { Administrador = 1, Calidad = 2, Mantenimiento = 3, Materiales = 4, Operador = 5, Supervisor = 6, Total=7 }
        public static int Id { get; set; }
        public static string Nombre { get; set; } = string.Empty;
        public static Permisos Permiso { get; set; }

        public static void Logout()
        {
            Id = 0;
            Nombre = string.Empty;
            Permiso = 0;
        }

        public static class Actions
        {
            public static bool CanControlApp()
            {
                return Permiso == Permisos.Administrador
						|| Permiso == Permisos.Supervisor
						|| Permiso == Permisos.Total;
            }
            public static bool CanOperate()
            {
                return Permiso == Permisos.Administrador
                        || Permiso == Permisos.Supervisor
                        || Permiso == Permisos.Mantenimiento
                        || Permiso == Permisos.Operador
						|| Permiso == Permisos.Total;
            }
            public static bool CanCancelOrder()
            {
                return Permiso == Permisos.Administrador
                        || Permiso == Permisos.Supervisor
                        || Permiso == Permisos.Mantenimiento
                        || Permiso == Permisos.Calidad
						|| Permiso == Permisos.Total;
            }
            public static bool CanChangeProduct()
            {
                return Permiso == Permisos.Administrador
                        || Permiso == Permisos.Supervisor
                        || Permiso == Permisos.Mantenimiento
                        || Permiso == Permisos.Calidad
						|| Permiso == Permisos.Total;
            }
            public static bool CanModifyRecipes()
            {
                return Permiso == Permisos.Materiales
					|| Permiso == Permisos.Total;
            }
            public static bool CanQualityCheck() {
                return Permiso == Permisos.Calidad || Permiso == Permisos.Total;
            }
            public static bool CanModifyUsers()
            {
                return Permiso == Permisos.Administrador || Permiso == Permisos.Total;
            }
            public static bool CanModifyTotalUsers()
            {
                return Permiso == Permisos.Total;
            }
        }
    }
}
