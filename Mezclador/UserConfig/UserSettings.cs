namespace Mezclador.UserConfig
{
    public static class UserSettings
    {
        public static string? COM_BasculaLigera { get; set; }
        public static string? COM_BasculaPesada { get; set; }
        public static string? Correo1 { get; set; }
        public static string? Correo2 { get; set; }
        public static string? Correo3 { get; set; }
        public static string? Correo4 { get; set; }
        public static string? Correo5 { get; set; }
        public static string? Correo6 { get; set; }
        public static string? Correo7 { get; set; }
        public static string? Correo8 { get; set; }
		public static double Densidad { get; set; }
        public static int ToleranciaInfLigera { get; set; }
        public static int ToleranciaSupLigera { get; set; }
        public static int ToleranciaInfPesada { get; set; }
        public static int ToleranciaSupPesada { get; set; }
        public static DateTime LastReport { get; set; }
	}
    public class UserSetting
    {
        public string? COM_BasculaLigera { get; set; }
        public string? COM_BasculaPesada { get; set; }
        public string? Correo1 { get; set; }
        public string? Correo2 { get; set; }
        public string? Correo3 { get; set; }
        public string? Correo4 { get; set; }
        public string? Correo5 { get; set; }
        public string? Correo6 { get; set; }
        public string? Correo7 { get; set; }
        public string? Correo8 { get; set; }
		public double? Densidad { get; set; }
        public int? ToleranciaInfLigera { get; set; }
        public int? ToleranciaSupLigera { get; set; }
        public int? ToleranciaInfPesada { get; set; }
        public int? ToleranciaSupPesada { get; set; }
        public DateTime? LastReport { get; set; }
	}
}
