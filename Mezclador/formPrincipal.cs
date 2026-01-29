
using Mezclador.Models;
using Mezclador.Users;
using static Mezclador.ConexionDB;

namespace Mezclador
{
    public partial class formPrincipal : Form
    {
        formSelectProducto? formSelectProduct;
        bool firstTime = true;
        bool mouseOverForm = true;
        //double minTolerance = 0.0;
        //double maxTolerance = 0.0;
        double minToleranceLigera = 0.0;
        double maxToleranceLigera = 0.0;
        double minTolerancePesada = 0.0;
        double maxTolerancePesada = 0.0;
        public formPrincipal()
        {
            InitializeComponent();
            ControlOrdenes.Start();

            weightList.Columns.Add(new DataGridViewImageColumn { Name = "Passed", HeaderText = "Passed", Width = 30 });
            weightList.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Descripción" });
        }

        private void formPrincipal_VisibleChanged(object sender, EventArgs e)
        {
            if (!tOrder.ReadOnly)
            {
                tOrder.Focus();
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            tOrder.Text = string.Empty;
            tOrder.Focus();
        }
        private void tmrHiPrior_Tick(object sender, EventArgs e)
        {
            //statusBasculaLigera.Text = ConexionRS232.StatusConexion == true ? "Conectada" : "Desconectada";
            panelPesada.Enabled = !string.IsNullOrEmpty(objetivoPesada.Text) && !objetivoPesada.Text.Contains('L') && !objetivoPesada.Text.Contains("aco");
            panelLigera.Enabled = !string.IsNullOrEmpty(objetivoLigera.Text) &&!objetivoLigera.Text.Contains('L') && !objetivoLigera.Text.Contains("aco");

            statusBasculaLigera.Text = RS232_BasculaLigera.serialPort?.IsOpen == true ? "Conectada" : "Desconectada";
            statusBasculaPesada.Text = RS232_BasculaPesada.serialPort?.IsOpen == true ? "Conectada" : "Desconectada";

            statusBasculaLigera.ForeColor = RS232_BasculaLigera.serialPort?.IsOpen == true ? Color.ForestGreen : Color.Red;
            statusBasculaPesada.ForeColor = RS232_BasculaPesada.serialPort?.IsOpen == true ? Color.ForestGreen : Color.Red;
            //tBoxRead.Text = ConexionRS232.receivedData;
            tBoxReadLigero.Text = RS232_BasculaLigera.weight + " kg";
            tBoxReadPesado.Text = RS232_BasculaPesada.weight + " kg";

            //lblInstructions.Text = ControlOrdenes.InstructionText;
            if (richInstructions.Text != ControlOrdenes.InstructionText)
            {
                richInstructions.Text = ControlOrdenes.InstructionText;
            }
            if (intructionsLigero.Text != ControlOrdenes.InstructionLigeros)
            {
                intructionsLigero.Text = ControlOrdenes.InstructionLigeros;
            }
            if (instructionsPesado.Text != ControlOrdenes.InstructionPesados)
            {
                instructionsPesado.Text = ControlOrdenes.InstructionPesados;
            }
            objetivoLigera.Text = ControlOrdenes.InstObjetivoLigero;
            objetivoPesada.Text = ControlOrdenes.InstObjetivoPesado;
            lblObjetivo1.Visible = string.IsNullOrEmpty(ControlOrdenes.InstObjetivoLigero) ? false : true;
            lblObjetivo2.Visible = string.IsNullOrEmpty(ControlOrdenes.InstObjetivoPesado) ? false : true;

            pictureBox1.Image = ControlOrdenes.ActualImagen;
            tBoxProducto.Text = $"{ControlOrdenes.SelectedProducto.Producto} {ControlOrdenes.SelectedProducto.Nombre}";

            tOrder.ReadOnly = Usuario.Nombre == string.Empty || ControlOrdenes.Order != string.Empty;
            //if (!tOrder.ReadOnly && !tOrder.Focused && mouseOverForm)
            //	tOrder.Focus();

            btnAmount.Enabled = ControlOrdenes.SelectedProducto.Producto != string.Empty && ControlOrdenes.RequiredAmount == string.Empty;

            btnClearOrder.Visible = btnCheckOrder.Visible = !tOrder.ReadOnly;

            if (ControlOrdenes.ActualCarga >= 0 && ControlOrdenes.RequiredProducts > 0)
                lblCargaCount.Text = $"Carga {ControlOrdenes.ActualCarga} de {ControlOrdenes.RequiredProducts}";
            else
                lblCargaCount.Text = "";

            if (!firstTime)
                ShowLogin();

            btnChangeOrder.Enabled = ControlOrdenes.Status == OrderStatus.Completed || ControlOrdenes.Status == OrderStatus.Canceled || (Usuario.Nombre.Length == 0 && ControlOrdenes.Order.Length > 0);
            if (ControlOrdenes.Order == "clear")
            {
                tOrder.Text = string.Empty;
                ControlOrdenes.SetOrder(string.Empty);
            }
            btnWeightLigeroOK.Visible = ControlOrdenes.CodigoLigeroOk;
            btnWeightPesadoOK.Visible = ControlOrdenes.CodigoPesadoOk;
            //btnWeightOK.Visible = (ControlOrdenes.CodigoOk && !ControlOrdenes.SacoReady) || (ControlOrdenes.CodigoOk && ControlOrdenes.SacoReady && ControlOrdenes.SacosCargados >= ControlOrdenes.SacosNecesarios && !string.IsNullOrEmpty(ControlOrdenes.SacoFraccion));

            btnSelectProduct.Enabled = !string.IsNullOrEmpty(ControlOrdenes.Order) && ControlOrdenes.SelectedProducto.Producto == string.Empty && (ControlOrdenes.Status != OrderStatus.Completed && ControlOrdenes.Status != OrderStatus.Canceled);

            panelCodeLigero.Visible = ControlOrdenes.CantidadLigeraAPesar != string.Empty && !ControlOrdenes.CodigoLigeroOk && !string.IsNullOrEmpty(Usuario.Nombre);
            panelCodePesado.Visible = ControlOrdenes.CantidadPesadaAPesar != string.Empty && !ControlOrdenes.CodigoPesadoOk && !string.IsNullOrEmpty(Usuario.Nombre);

            if (ControlOrdenes.Materials is not null && ControlOrdenes.Materials.Count > 0)
            {
                bool canCancelOrder = Usuario.Actions.CanCancelOrder();
                bool hasRequiredAmount = !string.IsNullOrEmpty(ControlOrdenes.RequiredAmount);

                bool noMaterialsPassed = ControlOrdenes.Materials.Any(product => !product.Passed);

                btnCloseOrder.Visible = btnCancelOrder.Visible = canCancelOrder && hasRequiredAmount && noMaterialsPassed;
            }
            else
                btnCloseOrder.Visible = btnCancelOrder.Visible = false;

            btnEditOrder.Enabled = Usuario.Actions.CanControlApp() && !string.IsNullOrEmpty(ControlOrdenes.Order);
            double cantidadLigera;
            double cantidadPesada;
            double.TryParse(RS232_BasculaLigera.weight, out double pesoLigero);
            double.TryParse(RS232_BasculaPesada.weight, out double pesoPesado);

            double.TryParse(ControlOrdenes.CantidadLigeraAPesar, out cantidadLigera);
            double.TryParse(ControlOrdenes.CantidadPesadaAPesar, out cantidadPesada);
            if (cantidadLigera > 0)
            {
                if (ControlOrdenes.SacoLigeroReady && ControlOrdenes.SacosLigerosCargados >= ControlOrdenes.SacosLigerosNecesarios && ControlOrdenes.SacoLigeroFraccion > 0)
                {
                    cantidadLigera = ControlOrdenes.SacoLigeroFraccion;
                }
                double scaleInf = (double)(cantidadLigera * (UserConfig.UserSettings.ToleranciaInfLigera / 100.0));
                double scaleSup = (double)(cantidadLigera * (UserConfig.UserSettings.ToleranciaSupLigera / 100.0));
                minToleranceLigera = Math.Round(cantidadLigera - scaleInf, 3);
                maxToleranceLigera = Math.Round(cantidadLigera + scaleSup, 3);
                minWLigero.Text = $"mínimo {minToleranceLigera} kg";
                maxWLigero.Text = $"máximo {maxToleranceLigera} kg";
                if (pesoLigero >= minToleranceLigera && pesoLigero <= maxToleranceLigera)
                    tBoxReadLigero.ForeColor = Color.Green;
                else
                    tBoxReadLigero.ForeColor = Color.Red;
            }
            else
            {
                tBoxReadLigero.ForeColor = Color.Black;
                minWLigero.Text = "";
                maxWLigero.Text = "";
            }

            if (cantidadPesada > 0)
            {
                if (ControlOrdenes.SacoPesadoReady && ControlOrdenes.SacosPesadosCargados >= ControlOrdenes.SacosPesadosNecesarios && ControlOrdenes.SacoPesadoFraccion > 0)
                {
                    cantidadPesada = ControlOrdenes.SacoPesadoFraccion;
                }
                //double scale = (double)(cantidadPesada * (UserConfig.UserSettings.Tolerancia / 100.0));
                double scaleInf = (double)(cantidadPesada * (UserConfig.UserSettings.ToleranciaInfPesada / 100.0));
                double scaleSup = (double)(cantidadPesada * (UserConfig.UserSettings.ToleranciaSupPesada / 100.0));
                minTolerancePesada = Math.Round(cantidadPesada - scaleInf, 3);
                maxTolerancePesada = Math.Round(cantidadPesada + scaleSup, 3);
                minWPesado.Text = $"mínimo {minTolerancePesada} kg";
                maxWPesado.Text = $"máximo {maxTolerancePesada} kg";
                if (pesoPesado >= minTolerancePesada && pesoPesado <= maxTolerancePesada)
                    tBoxReadPesado.ForeColor = Color.Green;
                else
                    tBoxReadPesado.ForeColor = Color.Red;
            }
            else
            {
                tBoxReadPesado.ForeColor = Color.Black;
                minWPesado.Text = "";
                maxWPesado.Text = "";
            }
        }

        private void tmrLowPrior_Tick(object sender, EventArgs e)
        {
            if (weightList.Rows.Count > 0)
                weightList.Rows.Clear();
            if (ControlOrdenes.Materials is not null && ControlOrdenes.Materials.Count > 0)
            {
                //weightList.DataSource = ControlOrdenes.Materials?.Select(c => new { c.Nombre, c.Passed }).ToList();
                foreach (var material in ControlOrdenes.Materials)
                {
                    // Agregar filas al DataGridView
                    var index = weightList.Rows.Add();
                    weightList.Rows[index].Cells["Nombre"].Value = material.Nombre;
                    if (material.Passed)
                        weightList.Rows[index].Cells["Passed"].Value = Properties.Resources.ok_little;
                    else
                        weightList.Rows[index].Cells["Passed"].Value = Properties.Resources.okWoColor;
                }

                weightList.ClearSelection();
            }
        }

        private void btnSelectRecipe_Click(object sender, EventArgs e)
        {
            OpenProductSelect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroHuella Enroller = new();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                //Template != null para saber si hay un template
                //VerifyButton.Enabled = SaveButton.Enabled = (Template != null);
                if (Template != null)
                    MessageBox.Show("El registro de la huella se ha completado.", "Registro de huella");
                else
                    MessageBox.Show("El registro de la huella no fue valido, vuelva a intentarlo.", "Registro de huella");
            }));
        }

        private DPFP.Template Template;

        private void button2_Click_1(object sender, EventArgs e)
        {
            LeerHuella leerHuella = new();
            leerHuella.Verify(Template);
        }

        private void btnWeightLigeroOK_Click(object sender, EventArgs e)
        {
            double.TryParse(RS232_BasculaLigera.weight, out double pesoLigero);
            //double.TryParse(RS232_BasculaPesada.weight, out double pesoPesado);

            if (ControlOrdenes.SacoLigeroReady && ControlOrdenes.SacosLigerosCargados < ControlOrdenes.SacosLigerosNecesarios)
            {
                ControlOrdenes.SumarLigeroSaco();
                return;
            }
            if (ControlOrdenes.SacoLigeroReady && ControlOrdenes.SacosLigerosCargados >= ControlOrdenes.SacosLigerosNecesarios && ControlOrdenes.SacoLigeroFraccion > 0)
            {
                if (pesoLigero >= minToleranceLigera &&
                pesoLigero <= maxToleranceLigera)
                    ControlOrdenes.PesoLigeroOK();
            }
            if (!ControlOrdenes.SacoLigeroReady)
            {
                if (pesoLigero >= minToleranceLigera &&
                    pesoLigero <= maxToleranceLigera)
                    ControlOrdenes.PesoLigeroOK();
            }
            //if (ControlOrdenes.MaterialLigeroAPesar.Nombre.Contains("Chevron") || ControlOrdenes.MaterialLigeroAPesar.Nombre.Contains("chevron"))
            if (ControlOrdenes.MaterialLigeroAPesar.esAceite)
                ControlOrdenes.PesoLigeroOK();
        }
        private void btnWeightPesadoOK_Click(object sender, EventArgs e)
        {
            //double.TryParse(RS232_BasculaLigera.weight, out double pesoLigero);
            double.TryParse(RS232_BasculaPesada.weight, out double pesoPesado);

            if (ControlOrdenes.SacoPesadoReady && ControlOrdenes.SacosPesadosCargados < ControlOrdenes.SacosPesadosNecesarios)
            {
                ControlOrdenes.SumarPesadoSaco();
                return;
            }
            if (ControlOrdenes.SacoPesadoReady && ControlOrdenes.SacosPesadosCargados >= ControlOrdenes.SacosPesadosNecesarios && ControlOrdenes.SacoPesadoFraccion > 0)
            {
                if (pesoPesado >= minTolerancePesada &&
                pesoPesado <= maxTolerancePesada)
                    ControlOrdenes.PesoPesadoOK();
            }
            if (!ControlOrdenes.SacoPesadoReady)
            {
                if (pesoPesado >= minTolerancePesada &&
                    pesoPesado <= maxTolerancePesada)
                    ControlOrdenes.PesoPesadoOK();
            }
            //if (ControlOrdenes.MaterialPesadoAPesar.Nombre.Contains("Chevron") || ControlOrdenes.MaterialPesadoAPesar.Nombre.Contains("chevron"))
            if (ControlOrdenes.MaterialPesadoAPesar.esAceite )
                ControlOrdenes.PesoPesadoOK();
        }

        private void btnSendLigeroCode_Click(object sender, EventArgs e)
        {
            ValidateMaterialLigeroCode();

        }
        private void btnSendPesadoCode_Click(object sender, EventArgs e)
        {
            ValidateMaterialPesadoCode();

        }
        private void ValidateMaterialLigeroCode()
        {
            if (ControlOrdenes.MaterialLigeroAPesar?.Codigo == tCodigoLigero.Text)
            {
                ControlOrdenes.CodigoLigeroOK();
                tCodigoLigero.Text = string.Empty;
            }
        }
        private void ValidateMaterialPesadoCode()
        {
            if (ControlOrdenes.MaterialPesadoAPesar?.Codigo == tCodigoPesado.Text)
            {
                ControlOrdenes.CodigoPesadoOK();
                tCodigoPesado.Text = string.Empty;
            }
        }

        private void tOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número ni la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni la tecla de retroceso, marcar el evento como manejado
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidarOrden();
            }
        }

        private void OpenProductSelect()
        {
            formSelectProduct = new();
            formSelectProduct.ShowDialog();
        }


        private void btnCheckOrder_Click(object sender, EventArgs e)
        {
            ValidarOrden();
        }
        private void ValidarOrden()
        {
            string orden = tOrder.Text;
            bool isNumber = int.TryParse(orden, out _);
            if (orden.Length == 9 && isNumber)
            {
                ControlOrdenes.SetOrder(orden);
                OrdenModel? existentOrder = ConexionDB.CheckOrderExist(orden);
                if (existentOrder is not null)
                    ControlOrdenes.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), existentOrder.Status);

                if (existentOrder is null) // no hay orden existente
                    OpenProductSelect();
                else
                {
                    ControlOrdenes.idOrden = existentOrder.Id;
                    ControlOrdenes.SetReqProducts(existentOrder.ProductosRequeridos);
                    ControlOrdenes.GetActualCarga(ControlOrdenes.idOrden);
                    if (ControlOrdenes.Status == OrderStatus.InProcess)
                    {
                        var materialsProduct = ConexionDB.GetInstructionsList(existentOrder.ProductoNavigation.Producto);
                        ControlOrdenes.SetAmount(existentOrder.CantidadRequerida.ToString());
                        ControlOrdenes.LoadRecipe(existentOrder.ProductoNavigation, materialsProduct);
                        ControlOrdenes.CreateCarga();
                    }
                    if (ControlOrdenes.Status == OrderStatus.Completed || ControlOrdenes.Status == OrderStatus.Canceled)
                    {
                        var materialsProduct = ConexionDB.GetInstructionsList(existentOrder.ProductoNavigation.Producto);
                        ControlOrdenes.SetAmount(existentOrder.CantidadRequerida.ToString());
                        ControlOrdenes.LoadRecipe(existentOrder.ProductoNavigation, materialsProduct);
                    }
                    //MessageBox.Show($"No se pudo crear la carga, error en archivo: {this.Name}");
                }
            }
            else
            {
                MessageBox.Show("La orden debe tener 9 números");
                tOrder.Focus();
                return;
            }
        }


        private void btnAmount_Click(object sender, EventArgs e)
        {
            formSetAmount formSetAmount = new(ControlOrdenes.SelectedProducto, CrudType.Create);
            formSetAmount.Show();
        }
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            formSetAmount formSetAmount = new(ControlOrdenes.SelectedProducto, CrudType.Update);
            formSetAmount.Show();
        }

        private void formPrincipal_Paint(object sender, PaintEventArgs e)
        {
            if (firstTime)
            {
                firstTime = false;
                ControlOrdenes.ShowLogin = true;
            }
        }

        private async void ShowLogin()
        {
            if (ControlOrdenes.ShowLogin)
            {
                ControlOrdenes.ShowLogin = false;
                await Task.Delay(100);
                LeerHuella leerHuella = new();
                leerHuella.Verify(Template);
            }
        }

        private void btnChangeOrder_Click(object sender, EventArgs e)
        {
            ControlOrdenes.ClearData();
            tOrder.Text = string.Empty;
        }

        private void formPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            mouseOverForm = true;
        }

        private void formPrincipal_Leave(object sender, EventArgs e)
        {

            mouseOverForm = false;
        }

        private void tOrder_ReadOnlyChanged(object sender, EventArgs e)
        {
            if (!tOrder.ReadOnly)
            {
                tOrder.Focus();
            }

        }

        private void panelMaterialCode_VisibleChanged(object sender, EventArgs e)
        {
            if (panelCodePesado.Visible)
            {
                tCodigoPesado.Focus();
            }
        }

        private void tCodigoPesado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateMaterialPesadoCode();
            }
        }
        private void tCodigoLigero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateMaterialLigeroCode();
            }
        }

        private void btnCloseOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Seguro que quieres cerrar la orden?", "Cerrar orden", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ControlOrdenes.CloseOrder();
            }
            //ControlOrdenes.cancelOrder = true;
        }
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Seguro que quieres cancelar la orden y empezar todo de nuevo?", "Cancelación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ControlOrdenes.CancelOrder();
            }
        }

        private void BtnCalidad_Click(object sender, EventArgs e)
        {
            LeerHuella leerHuella = new(OnlyQuality: true);
            leerHuella.Verify(Template);
        }

        private void lblCargaCount_Click(object sender, EventArgs e)
        {

        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
        }

        private void tOrder_TextChanged(object sender, EventArgs e)
        {

        }

        private void weightList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
