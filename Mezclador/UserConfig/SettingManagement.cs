using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mezclador.UserConfig
{
	public class SettingManagement
	{
		private static readonly string SettingsFilePath = @"C:\Mezclador\settingsUser.json";
		private static readonly string FilePath = @"C:\Mezclador\";

		public static void LoadUserSettings()
		{
			UserSetting userSetting = new();

			if (File.Exists(SettingsFilePath))
			{
				string json = File.ReadAllText(SettingsFilePath);
				JsonConvert.PopulateObject(json, userSetting);
            }
            UserSettings.COM_BasculaLigera = userSetting.COM_BasculaLigera ?? "";
            UserSettings.COM_BasculaPesada = userSetting.COM_BasculaPesada ?? "";
            UserSettings.Correo1 = userSetting.Correo1 ?? "";
			UserSettings.Correo2 = userSetting.Correo2 ?? "";
			UserSettings.Correo3 = userSetting.Correo3 ?? "";
			UserSettings.Correo4 = userSetting.Correo4 ?? "";
			UserSettings.Correo5 = userSetting.Correo5 ?? "";
			UserSettings.Correo6 = userSetting.Correo6 ?? "";
			UserSettings.Correo7 = userSetting.Correo7 ?? "";
			UserSettings.Correo8 = userSetting.Correo8 ?? "";
			UserSettings.Densidad = userSetting.Densidad ?? 0.868;
            UserSettings.ToleranciaInfLigera = userSetting.ToleranciaInfLigera ?? 5;
            UserSettings.ToleranciaSupLigera = userSetting.ToleranciaSupLigera ?? 2;
            UserSettings.ToleranciaInfPesada = userSetting.ToleranciaInfPesada ?? 5;
            UserSettings.ToleranciaSupPesada = userSetting.ToleranciaSupPesada ?? 2;
            UserSettings.LastReport = userSetting.LastReport ?? new DateTime(1,1,1);
		}

		public static void SaveUserSettings()
		{
			UserSetting userSetting = new()
            {
                COM_BasculaLigera = UserSettings.COM_BasculaLigera,
                COM_BasculaPesada = UserSettings.COM_BasculaPesada,
                Correo1 = UserSettings.Correo1,
				Correo2 = UserSettings.Correo2,
				Correo3 = UserSettings.Correo3,
				Correo4 = UserSettings.Correo4,
				Correo5 = UserSettings.Correo5,
				Correo6 = UserSettings.Correo6,
				Correo7 = UserSettings.Correo7,
				Correo8 = UserSettings.Correo8,
				Densidad = UserSettings.Densidad,
                ToleranciaInfLigera = UserSettings.ToleranciaInfLigera,
                ToleranciaSupLigera = UserSettings.ToleranciaSupLigera,
                ToleranciaInfPesada = UserSettings.ToleranciaInfPesada,
                ToleranciaSupPesada = UserSettings.ToleranciaSupPesada,
                LastReport = UserSettings.LastReport,
			};

			string json = JsonConvert.SerializeObject(userSetting);

			EnsureDirectoryExists(FilePath);
			File.WriteAllText(SettingsFilePath, json);
		}
		private static void EnsureDirectoryExists(string directoryPath)
		{
			// Asegurar que la carpeta exista, si no, crearla.
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
		}
	}
}
