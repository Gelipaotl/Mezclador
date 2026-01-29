using OfficeOpenXml;
using System.Net.Mail;
using System.Net;
using Mezclador.UserConfig;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Mezclador.Services
{
    public class Email
    {
        private System.Threading.Timer _timer;
        private readonly TimeSpan CheckInterval = TimeSpan.FromMinutes(1);
        private List<string> _emails = new();
        private string appEmail = "comaflex95@gmail.com";//59xelfamoc
        private string appAlias = "Comaflex VC Coatings";
		public Email(int idOrden)
		{
            CreateReport(idOrden);
		}
		public Email()
		{
			// Por si el cliente quiere que sea cada cierto tiempo
			_timer = new System.Threading.Timer(CheckTime, null, TimeSpan.Zero, CheckInterval);
		}
		private async void CheckTime(object state)
        {
            // Obtiene la hora actual
            var now = DateTime.Now;
            var dateStart = DateTime.Now.Date;
            var dateEnd = DateTime.Now.Date;
            var oneDaySinceLastReport = false;

			if ((DateTime.Now - UserSettings.LastReport > TimeSpan.FromHours(24)) && now.Hour > 7)
			    oneDaySinceLastReport = true;
				// Verifica si son las 7:00 horas
			if ((now.Hour == 7 && now.Minute == 0) || oneDaySinceLastReport )
            {
                dateEnd = dateEnd.AddHours(7);
                dateStart = dateEnd;
                dateStart = dateStart.AddHours(-24);
                await CreateReport(dateStart,dateEnd);
            }
        }
        public async Task CreateReport(DateTime dateStart, DateTime dateEnd)
        {
            GetEmails();
            Excel excel = new();
            await excel.Create(dateStart, dateEnd);
            if (excel.excelPackage is not null)
            {
                UserSettings.LastReport = DateTime.Now;
				SettingManagement.SaveUserSettings();

				foreach (var destinatario in _emails)
                {
                    if (string.IsNullOrEmpty(destinatario)
                        || destinatario.Length < 8
                        || !destinatario.Contains('@'))
                        continue;

                    await Enviar(destinatario, excel.excelPackage);
                    await Task.Delay(2_000);
                }
            }
        }
        public async void CreateReport(int idOrden)
        {
            GetEmails();
            Excel excel = new();
            await excel.Create(idOrden);
            if (excel.excelPackage is not null)
            {
                foreach (var destinatario in _emails)
                {
                    if (string.IsNullOrEmpty(destinatario)
                        || destinatario.Length < 8
                        || !destinatario.Contains('@'))
                        continue;

                    await Enviar(destinatario, excel.excelPackage);
                    await Task.Delay(2_000);
                }
            }
        }
        private void GetEmails()
        {
            //test();
            _emails = new() { UserSettings.Correo1,
                UserSettings.Correo2,
                UserSettings.Correo3,
                UserSettings.Correo4,
                UserSettings.Correo5,
                UserSettings.Correo6,
                UserSettings.Correo7,
                UserSettings.Correo8 };
        }

        private async void test()
        {
            //List<string> areasString = new();
            //areasString.AddRange(["Programación", "Diseño Eléctrico", "Ensamble Eléctrico"]);
            //await CreateReport("f.arvizu.a@gmail.com");
        }

        public async Task<bool> Enviar(string destinatario, ExcelPackage excelPackage)
        {
            if (excelPackage is null || excelPackage.Workbook.Worksheets.Count <= 0) return false;
            var fileSinExtension = Path.GetFileNameWithoutExtension(excelPackage.File.FullName);
            string asunto = $"Reporte {fileSinExtension}";
            string Body = "Correo enviado automáticamente, no responder.";

            MailMessage mail = new()
            {
                From = new MailAddress(appEmail, appAlias)
            };
            mail.To.Add(destinatario);

            mail.Subject = asunto;
            mail.Body = Body;

            MemoryStream memoryStream = new();

            excelPackage.SaveAs(memoryStream);
            memoryStream.Position = 0;
            // Adjuntar el MemoryStream al correo electrónico
            //mail.Attachments.Add(new Attachment(memoryStream, $"Registro {DateTime.Now:yyyy-MM-dd HH-mm}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
            mail.Attachments.Add(new Attachment(memoryStream, $"{fileSinExtension}.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

            SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                UseDefaultCredentials = false,

                Port = 587,//26,//465, //587//25
                Credentials = new NetworkCredential(appEmail, "rnok gvka lctq kecw"),
                EnableSsl = true
            };
            //continuamente hay requisitos de seguridad en gmail, cumplirlos e ir a contraseñas de aplicaciones para generar nuevas
            //anterior bxqt cqcs nzic pgjn
            try
            {
                await smtp.SendMailAsync(mail);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
            }
            finally
            {
                mail.Dispose();
            }
        }

        //private async Task SaveRegisterOnDB(int year, int week, string email)
        //{
        //    if (year <= 0 || week <= 0 || string.IsNullOrEmpty(email)) return;

        //    using PendientesatkContext context = new();
        //    context.AutoEmailCtrls.Add(new() { Anio = year, Semana = week, Correo = email });
        //    await context.SaveChangesAsync();
        //}
        //private async Task<bool> CheckEmailSent(int year, int week, string email)
        //{
        //    using PendientesatkContext context = new();
        //    var existingEmail = await context.AutoEmailCtrls
        //        .FirstOrDefaultAsync(c => c.Anio == year && c.Semana == week && c.Correo == email);

        //    return existingEmail != null;
        //}
        //[GeneratedRegex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
        //private Regex MyRegex();
    }
}
