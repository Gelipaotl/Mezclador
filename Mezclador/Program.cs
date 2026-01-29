using Mezclador.Services;
using Mezclador.UserConfig;

namespace Mezclador
{
    delegate void Function();
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
			ConexionDB.CancelCargas();
            ConexionDB.CreateColumn();

			SettingManagement.LoadUserSettings();
			Email email = new();
            Application.Run(new Header());
        }
    }
}