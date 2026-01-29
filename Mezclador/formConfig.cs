using Mezclador.Services;
using Mezclador.UserConfig;
using Mezclador.Users;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Mezclador
{
    public partial class formConfig : Form
    {
        public formConfig()
        {
            InitializeComponent();
            cBoxPorts1.DataSource = RS232_BasculaLigera.GetComPorts();
            cBoxPorts2.DataSource = RS232_BasculaLigera.GetComPorts();

            fechaInicio.Value = DateTime.Now.AddDays(-1); 
            fechaFin.Value = DateTime.Now;
            horaInicio.SelectedIndex = 0;
            horaFin.SelectedIndex = horaFin.Items.Count - 1;
            Reload();
        }
        void Reload()
        {
            cBoxPorts1.Text = UserSettings.COM_BasculaLigera;
            cBoxPorts2.Text = UserSettings.COM_BasculaPesada;
            correo1.Text = UserSettings.Correo1;
            correo2.Text = UserSettings.Correo2;
            correo3.Text = UserSettings.Correo3;
            correo4.Text = UserSettings.Correo4;
            correo5.Text = UserSettings.Correo5;
            correo6.Text = UserSettings.Correo6;
            correo7.Text = UserSettings.Correo7;
            correo8.Text = UserSettings.Correo8;
            tboxAceiteConv.Text = UserSettings.Densidad.ToString();
            toleraInfLigera.Value = UserSettings.ToleranciaInfLigera;
            toleraSupLigera.Value = UserSettings.ToleranciaSupLigera;
            toleraInfPesada.Value = UserSettings.ToleranciaInfPesada;
            toleraSupPesada.Value = UserSettings.ToleranciaSupPesada;
            lastReport.Text = $"Último reporte generado: {UserSettings.LastReport}";
        }
        private void BtnConectar_Click(object sender, EventArgs e)
        {

            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            if (cBoxPorts1.SelectedIndex >= 0)
            {
                BtnConectar1.Enabled = false;
                //Properties.Settings.Default.PuertoCOM = cBoxPorts.SelectedItem.ToString();
                //Properties.Settings.Default.Save();
                UserSettings.COM_BasculaLigera = cBoxPorts1.SelectedItem.ToString();
                SettingManagement.SaveUserSettings();
                RS232_BasculaLigera.Connect();
                BtnConectar1.Enabled = true;
            }
;
        }
        private void BtnConectar2_Click(object sender, EventArgs e)
        {

            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            if (cBoxPorts2.SelectedIndex >= 0)
            {
                BtnConectar2.Enabled = false;
                UserSettings.COM_BasculaPesada = cBoxPorts2.SelectedItem.ToString();
                SettingManagement.SaveUserSettings();
                RS232_BasculaPesada.Connect();
                BtnConectar2.Enabled = true;
            }
        }

        private void BtnDesconectar_Click(object sender, EventArgs e)
        {

            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            BtnDesconectar1.Enabled = false;
            RS232_BasculaLigera.Close();
            BtnDesconectar1.Enabled = true;
        }

        private void BtnDesconectar2_Click(object sender, EventArgs e)
        {

            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            BtnDesconectar2.Enabled = false;
            RS232_BasculaPesada.Close();
            BtnDesconectar2.Enabled = true;
        }

        private void BtnUpdatePorts_Click(object sender, EventArgs e)
        {
            var old = cBoxPorts1.SelectedIndex;
            cBoxPorts1.DataSource = RS232_BasculaLigera.GetComPorts();
            if (old < cBoxPorts1.Items.Count)
                cBoxPorts1.SelectedIndex = old;

            old = cBoxPorts2.SelectedIndex;
            cBoxPorts2.DataSource = RS232_BasculaLigera.GetComPorts();
            if (old < cBoxPorts2.Items.Count)
                cBoxPorts2.SelectedIndex = old;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tBoxStatusBascula1.Text = RS232_BasculaLigera.serialPort?.IsOpen == true ? "Conectado" : "Desconectado";
            tBoxStatusBascula1.ForeColor = RS232_BasculaLigera.serialPort?.IsOpen == true ? Color.ForestGreen : Color.Red;
            tBoxRead1.Text = RS232_BasculaLigera.receivedData;

            tBoxStatusBascula2.Text = RS232_BasculaPesada.serialPort?.IsOpen == true ? "Conectado" : "Desconectado";
            tBoxStatusBascula2.ForeColor = RS232_BasculaPesada.serialPort?.IsOpen == true ? Color.ForestGreen : Color.Red;
            tBoxRead2.Text = RS232_BasculaPesada.receivedData;
        }

        private void formConfig_VisibleChanged(object sender, EventArgs e)
        {
            timer1.Enabled = Visible;
            if (Visible)
            {
                Reload();
            }
        }

        private void btnEmailSave_Click(object sender, EventArgs e)
        {

            if (!Usuario.Actions.CanControlApp())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            UserSettings.Correo1 = correo1.Text;
            UserSettings.Correo2 = correo2.Text;
            UserSettings.Correo3 = correo3.Text;
            UserSettings.Correo4 = correo4.Text;
            UserSettings.Correo5 = correo5.Text;
            UserSettings.Correo6 = correo6.Text;
            UserSettings.Correo7 = correo7.Text;
            UserSettings.Correo8 = correo8.Text;
            SettingManagement.SaveUserSettings();
            MessageBox.Show("Datos guardados");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tboxAceiteConv_TextChanged(object sender, EventArgs e)
        {

        }

        private void tboxAceiteConv_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Permitir el uso de la tecla de retroceso
            if (ch == 8) // 8 es el código ASCII para Backspace
            {
                return;
            }

            // Permitir solo números y un punto decimal
            if (!Char.IsDigit(ch) && ch != 46) // 46 es el código ASCII para el punto decimal
            {
                e.Handled = true;
            }
            else
            {
                // Solo permitir un punto decimal
                if (ch == 46 && (sender as TextBox).Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnSaveDensidad_Click(object sender, EventArgs e)
        {

            if (!Usuario.Actions.CanModifyRecipes())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            UserSettings.Densidad = Convert.ToDouble(tboxAceiteConv.Text);
            SettingManagement.SaveUserSettings();
            MessageBox.Show("Datos guardados");
        }

        private void btnSaveTolerance_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanControlApp())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            UserSettings.ToleranciaInfLigera = (int)toleraInfLigera.Value;
            UserSettings.ToleranciaSupLigera = (int)toleraSupLigera.Value;
            UserSettings.ToleranciaInfPesada = (int)toleraInfPesada.Value;
            UserSettings.ToleranciaSupPesada = (int)toleraSupPesada.Value;
            SettingManagement.SaveUserSettings();
            MessageBox.Show("Datos guardados");
        }

        private async void BtnGenerateExcel_Click(object sender, EventArgs e)
        {
            if (!Usuario.Actions.CanControlApp() && !Usuario.Actions.CanModifyRecipes())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            try
            {
                lblErrorDates.Visible = false;
                if (fechaInicio.Value > fechaFin.Value)
                {
                    lblErrorDates.Visible = true;
                    return;
                }
                fechaInicio.Value = new(fechaInicio.Value.Year, fechaInicio.Value.Month, fechaInicio.Value.Day, horaInicio.SelectedIndex, 0, 0);
                fechaFin.Value = new(fechaFin.Value.Year, fechaFin.Value.Month, fechaFin.Value.Day, horaFin.SelectedIndex, 0, 0);
                Excel excel = new();
                await excel.Create(fechaInicio.Value, fechaFin.Value);

                if (MessageBox.Show($"Archivo guardado correctamente en \n{excel.filePath}\nAbrir archivo?", "Archivo guardado",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(excel.filePath) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte {ex.Message}");
            }
        }
    }
}
