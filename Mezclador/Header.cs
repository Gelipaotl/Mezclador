
using Mezclador.Users;

namespace Mezclador
{
    public partial class Header : Form
    {
        readonly List<Button> ListaMenu;
        readonly List<Form> ListaVentanas;
        Color ColorSelectedMenu = Color.FromArgb(96, 142, 254);
        bool MouseOverLogMenu;
        public Header()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Location = workingArea.Location;
            this.Size = workingArea.Size;

            RS232_BasculaLigera.Initialize();
            RS232_BasculaPesada.Initialize();
            ConexionDB.GetAllFingers();

            ListaMenu = new List<Button> {
                btnPrincipal, btnEditRecipes,btnEditProducts,btnProduccion, btnCalidad, btnConfig
            };//,BtnConfig
            ListaVentanas = new List<Form> {
                new formPrincipal(), new EditProducto(), new EditMaterial(), new formOrdenes(), new formCalidad(), new formConfig()
            };

            AbrirFormEnPanel(ListaVentanas[0]);// abrir principal
            btnPrincipal.BackColor = ColorSelectedMenu;

            //crear evento click para cada boton del menu
            for (int i = 0; i < ListaMenu.Count; i++)
            {
                ListaMenu[i].Click += new EventHandler(ClickMenu);
            }
        }

        /// <summary>
        /// Evento cuando se hace clic sobre un elemento del menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickMenu(object sender, EventArgs e)
        {
            //cambiar color del boton seleccionado

            //abrir formulario dentro de header 
            int Btn_index = ListaMenu.IndexOf((Button)sender);
            panelMenuUser.Visible = false;
            if (!AbrirFormEnPanel(ListaVentanas[Btn_index]))
            {
                foreach (var item in ListaMenu)
                {
                    item.BackColor = panelMenu.BackColor;
                }
                ListaMenu[Btn_index].BackColor = ColorSelectedMenu;
            }
        }

        public bool AbrirFormEnPanel(object Formhijo)
        {
            //if is fixed dialog the form will show as dialog and not as son form 
            bool IsFixedDialog = false;
            if (Formhijo != null)
            {
                Form fh = Formhijo as Form;

                if (fh.FormBorderStyle == FormBorderStyle.FixedDialog)
                {

                    fh.ShowDialog();
                    IsFixedDialog = true;
                }
                else
                {
                    if (panelForms.Controls.Count > 0)
                    {
                        panelForms.Controls.RemoveAt(0);
                    }
                    ListaVentanas.ForEach(form => form.Visible = false);
                    fh.TopLevel = false;
                    fh.FormBorderStyle = FormBorderStyle.None;
                    fh.Dock = DockStyle.Fill;

                    panelForms.Controls.Add(fh);
                    panelForms.Tag = fh;

                    fh.Show();
                }
            }
            return IsFixedDialog;
        }

        private void Header_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Usuario.Actions.CanControlApp())
            {
                e.Cancel = true; // Cancelar el cierre del formulario
                MessageBox.Show("No tienes permiso para cerrar esta ventana.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show("Si está corriendo una secuencia, esta se perderá.\nDesea continuar?", "Aviso de cierre", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                RS232_BasculaPesada.Close();
                RS232_BasculaLigera.Close();
            }
            else
                e.Cancel = true; // Cancelar el cierre del formulario
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            const int SC_MINIMIZE = 0xF020;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int WM_NCLBUTTONDBLCLK = 0x00A3;
            const int HTCAPTION = 0x2;

            if (!Usuario.Actions.CanControlApp())
            {
                if (m.Msg == WM_SYSCOMMAND &&
                    (m.WParam.ToInt32() == SC_CLOSE ||
                     m.WParam.ToInt32() == SC_MINIMIZE ||
                     m.WParam.ToInt32() == SC_MAXIMIZE ||
                     m.WParam.ToInt32() == SC_RESTORE))
                {
                    return; // Ignorar el mensaje para evitar el cierre, minimizar, maximizar o restaurar
                }

                if ((m.Msg == WM_NCLBUTTONDOWN || m.Msg == WM_NCLBUTTONDBLCLK) && m.WParam.ToInt32() == HTCAPTION)
                {
                    return; // Ignorar el mensaje para evitar mover o restaurar la ventana con doble clic en la barra de título
                }
            }
            base.WndProc(ref m);
        }

        private void Header_Load(object sender, EventArgs e)
        {
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //panelMenuUser.Visible = !panelMenuUser.Visible;
            //panelMenuUser.Focus();
            ControlUsers controlUsers = new();
            controlUsers.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario.Nombre;
            if (Usuario.Nombre != string.Empty)
            {
                txtPermiso.Text = Usuario.Permiso.ToString();
                //if (Usuario.Permiso == Usuario.Permisos.Administrador)
                lblLogout.Visible = true;
            }
            else
            {
                txtPermiso.Text = "Ninguno";
                lblLogout.Visible = false;
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelMenuUser.Visible = false;
            LeerHuella leerHuella = new();
            leerHuella.Verify(Template);
        }
        private void btnSignin_Click(object sender, EventArgs e)
        {
            panelMenuUser.Visible = false;
            if (!Usuario.Actions.CanModifyUsers())
            {
                MessageBox.Show("Permisos insuficientes");
                return;
            }
            SignIn signIn = new(ConexionDB.CrudType.Create);
            signIn.ShowDialog();
        }
        private void panlMenuUser_MouseLeave(object sender, EventArgs e)
        {
            panelMenuUser.Visible = false;
        }

        private DPFP.Template Template;

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Usuario.Logout();
        }

        int i;
        const int delayDuration = 170;
        private async void panlMenuUser_VisibleChanged(object sender, EventArgs e)
        {
            if (panelMenuUser.Visible)
            {
                await Delay();
                panelMenuUser.Visible = false;
            }
            else
            {
                i = delayDuration;
            }
        }
        private async Task Delay()
        {
            for (i = 0; i < delayDuration; i++)
            {
                await Task.Delay(1);
            }
        }

        private void Header_Shown(object sender, EventArgs e)
        {
            RS232_BasculaLigera.Connect();
            RS232_BasculaPesada.Connect();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (Usuario.Actions.CanControlApp())
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            if (Usuario.Actions.CanControlApp())
            {
                this.Close();
            }
        }

        private void TmrEmail_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Header_Click(object sender, EventArgs e)
        {

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {

        }

        private void btnEditRecipes_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Header_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}