namespace Mezclador
{
    partial class formPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnSelectProduct = new Button();
            tBoxProducto = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tmrHiPrior = new System.Windows.Forms.Timer(components);
            tCodigoPesado = new TextBox();
            label2 = new Label();
            btnWeightLigeroOK = new Button();
            btnOKCodePesado = new Button();
            label4 = new Label();
            tOrder = new TextBox();
            btnAmount = new Button();
            btnLogin = new Button();
            btnClearOrder = new Button();
            lblCargaCount = new Label();
            btnChangeOrder = new Button();
            btnCheckOrder = new Button();
            panelCodePesado = new Panel();
            btnCloseOrder = new Button();
            BtnCalidad = new Button();
            picLogoBig = new PictureBox();
            tBoxReadPesado = new TextBox();
            minWPesado = new Label();
            maxWPesado = new Label();
            weightList = new DataGridView();
            tmrLowPrior = new System.Windows.Forms.Timer(components);
            label7 = new Label();
            btnCancelOrder = new Button();
            btnEditOrder = new Button();
            maxWLigero = new Label();
            minWLigero = new Label();
            tBoxReadLigero = new TextBox();
            label8 = new Label();
            statusBasculaLigera = new TextBox();
            label9 = new Label();
            statusBasculaPesada = new TextBox();
            panelLigera = new Panel();
            panelPesada = new Panel();
            panelCodeLigero = new Panel();
            btnOkCodeLigero = new Button();
            label5 = new Label();
            tCodigoLigero = new TextBox();
            btnWeightPesadoOK = new Button();
            intructionsLigero = new TextBox();
            instructionsPesado = new TextBox();
            richInstructions = new TextBox();
            lblObjetivo1 = new Label();
            objetivoLigera = new TextBox();
            objetivoPesada = new TextBox();
            lblObjetivo2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelCodePesado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoBig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weightList).BeginInit();
            panelLigera.SuspendLayout();
            panelPesada.SuspendLayout();
            panelCodeLigero.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectProduct
            // 
            btnSelectProduct.Enabled = false;
            btnSelectProduct.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnSelectProduct.Location = new Point(625, 953);
            btnSelectProduct.Margin = new Padding(4);
            btnSelectProduct.Name = "btnSelectProduct";
            btnSelectProduct.Size = new Size(190, 80);
            btnSelectProduct.TabIndex = 12;
            btnSelectProduct.Text = "Seleccionar Producto";
            btnSelectProduct.UseVisualStyleBackColor = true;
            btnSelectProduct.Click += btnSelectRecipe_Click;
            // 
            // tBoxProducto
            // 
            tBoxProducto.Font = new Font("Franklin Gothic Medium", 16F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxProducto.ForeColor = Color.FromArgb(50, 50, 50);
            tBoxProducto.Location = new Point(307, 82);
            tBoxProducto.Margin = new Padding(4);
            tBoxProducto.Name = "tBoxProducto";
            tBoxProducto.ReadOnly = true;
            tBoxProducto.Size = new Size(649, 32);
            tBoxProducto.TabIndex = 13;
            tBoxProducto.TabStop = false;
            tBoxProducto.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cancel_icon;
            pictureBox1.Location = new Point(438, 389);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(386, 379);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(30, 30, 30);
            label1.Location = new Point(578, 41);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 15;
            label1.Text = "Producto";
            // 
            // tmrHiPrior
            // 
            tmrHiPrior.Enabled = true;
            tmrHiPrior.Tick += tmrHiPrior_Tick;
            // 
            // tCodigoPesado
            // 
            tCodigoPesado.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tCodigoPesado.Location = new Point(13, 56);
            tCodigoPesado.Margin = new Padding(4);
            tCodigoPesado.Name = "tCodigoPesado";
            tCodigoPesado.Size = new Size(178, 30);
            tCodigoPesado.TabIndex = 17;
            tCodigoPesado.KeyPress += tCodigoPesado_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(13, 19);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(170, 24);
            label2.TabIndex = 18;
            label2.Text = "Código del material";
            // 
            // btnWeightLigeroOK
            // 
            btnWeightLigeroOK.Location = new Point(254, 681);
            btnWeightLigeroOK.Margin = new Padding(4);
            btnWeightLigeroOK.Name = "btnWeightLigeroOK";
            btnWeightLigeroOK.Size = new Size(129, 63);
            btnWeightLigeroOK.TabIndex = 21;
            btnWeightLigeroOK.Text = "OK";
            btnWeightLigeroOK.UseVisualStyleBackColor = true;
            btnWeightLigeroOK.Click += btnWeightLigeroOK_Click;
            // 
            // btnOKCodePesado
            // 
            btnOKCodePesado.Location = new Point(55, 97);
            btnOKCodePesado.Margin = new Padding(4);
            btnOKCodePesado.Name = "btnOKCodePesado";
            btnOKCodePesado.Size = new Size(96, 33);
            btnOKCodePesado.TabIndex = 22;
            btnOKCodePesado.Text = "OK";
            btnOKCodePesado.UseVisualStyleBackColor = true;
            btnOKCodePesado.Click += btnSendPesadoCode_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Franklin Gothic Medium", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(30, 30, 30);
            label4.Location = new Point(597, 176);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(69, 28);
            label4.TabIndex = 27;
            label4.Text = "Orden";
            // 
            // tOrder
            // 
            tOrder.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tOrder.Location = new Point(542, 206);
            tOrder.Margin = new Padding(4);
            tOrder.MaxLength = 9;
            tOrder.Name = "tOrder";
            tOrder.Size = new Size(178, 30);
            tOrder.TabIndex = 1;
            tOrder.TextAlign = HorizontalAlignment.Center;
            tOrder.ReadOnlyChanged += tOrder_ReadOnlyChanged;
            tOrder.TextChanged += tOrder_TextChanged;
            tOrder.KeyPress += tOrder_KeyPress;
            // 
            // btnAmount
            // 
            btnAmount.Enabled = false;
            btnAmount.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnAmount.Location = new Point(421, 953);
            btnAmount.Margin = new Padding(4);
            btnAmount.Name = "btnAmount";
            btnAmount.Size = new Size(190, 80);
            btnAmount.TabIndex = 28;
            btnAmount.Text = "Cantidad requerida";
            btnAmount.UseVisualStyleBackColor = true;
            btnAmount.Click += btnAmount_Click;
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Franklin Gothic Medium", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(1043, 966);
            btnLogin.Margin = new Padding(5, 4, 5, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(149, 56);
            btnLogin.TabIndex = 34;
            btnLogin.Text = "Excel";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Visible = false;
            btnLogin.Click += btnExcel_Click;
            // 
            // btnClearOrder
            // 
            btnClearOrder.Location = new Point(837, 206);
            btnClearOrder.Margin = new Padding(4);
            btnClearOrder.Name = "btnClearOrder";
            btnClearOrder.Size = new Size(96, 33);
            btnClearOrder.TabIndex = 35;
            btnClearOrder.Text = "Limpiar";
            btnClearOrder.UseVisualStyleBackColor = true;
            btnClearOrder.Click += btnClearOrder_Click;
            // 
            // lblCargaCount
            // 
            lblCargaCount.AutoSize = true;
            lblCargaCount.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblCargaCount.ForeColor = Color.FromArgb(50, 50, 50);
            lblCargaCount.Location = new Point(574, 126);
            lblCargaCount.Margin = new Padding(4, 0, 4, 0);
            lblCargaCount.Name = "lblCargaCount";
            lblCargaCount.Size = new Size(114, 24);
            lblCargaCount.TabIndex = 36;
            lblCargaCount.Text = "Carga 1 de 1";
            lblCargaCount.Click += lblCargaCount_Click;
            // 
            // btnChangeOrder
            // 
            btnChangeOrder.Enabled = false;
            btnChangeOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnChangeOrder.Location = new Point(829, 953);
            btnChangeOrder.Margin = new Padding(4);
            btnChangeOrder.Name = "btnChangeOrder";
            btnChangeOrder.Size = new Size(190, 80);
            btnChangeOrder.TabIndex = 37;
            btnChangeOrder.Text = "Cambiar orden ";
            btnChangeOrder.UseVisualStyleBackColor = true;
            btnChangeOrder.Click += btnChangeOrder_Click;
            // 
            // btnCheckOrder
            // 
            btnCheckOrder.Location = new Point(729, 206);
            btnCheckOrder.Margin = new Padding(4);
            btnCheckOrder.Name = "btnCheckOrder";
            btnCheckOrder.Size = new Size(96, 33);
            btnCheckOrder.TabIndex = 38;
            btnCheckOrder.Text = "OK";
            btnCheckOrder.UseVisualStyleBackColor = true;
            btnCheckOrder.Click += btnCheckOrder_Click;
            // 
            // panelCodePesado
            // 
            panelCodePesado.BorderStyle = BorderStyle.FixedSingle;
            panelCodePesado.Controls.Add(btnOKCodePesado);
            panelCodePesado.Controls.Add(label2);
            panelCodePesado.Controls.Add(tCodigoPesado);
            panelCodePesado.Location = new Point(829, 681);
            panelCodePesado.Margin = new Padding(4);
            panelCodePesado.Name = "panelCodePesado";
            panelCodePesado.Size = new Size(204, 143);
            panelCodePesado.TabIndex = 39;
            panelCodePesado.VisibleChanged += panelMaterialCode_VisibleChanged;
            // 
            // btnCloseOrder
            // 
            btnCloseOrder.BackColor = Color.OrangeRed;
            btnCloseOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloseOrder.ForeColor = Color.White;
            btnCloseOrder.Location = new Point(1261, 832);
            btnCloseOrder.Margin = new Padding(4);
            btnCloseOrder.Name = "btnCloseOrder";
            btnCloseOrder.Size = new Size(233, 80);
            btnCloseOrder.TabIndex = 40;
            btnCloseOrder.Text = "Cerrar orden";
            btnCloseOrder.UseVisualStyleBackColor = false;
            btnCloseOrder.Visible = false;
            btnCloseOrder.Click += btnCloseOrder_Click;
            // 
            // BtnCalidad
            // 
            BtnCalidad.BackColor = Color.FromArgb(240, 180, 100);
            BtnCalidad.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            BtnCalidad.ForeColor = Color.FromArgb(30, 30, 30);
            BtnCalidad.Location = new Point(13, 953);
            BtnCalidad.Margin = new Padding(4);
            BtnCalidad.Name = "BtnCalidad";
            BtnCalidad.Size = new Size(190, 80);
            BtnCalidad.TabIndex = 41;
            BtnCalidad.Text = "Calidad";
            BtnCalidad.UseVisualStyleBackColor = false;
            BtnCalidad.Click += BtnCalidad_Click;
            // 
            // picLogoBig
            // 
            picLogoBig.Image = Properties.Resources.comaflex;
            picLogoBig.Location = new Point(1436, 928);
            picLogoBig.Name = "picLogoBig";
            picLogoBig.Size = new Size(299, 118);
            picLogoBig.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoBig.TabIndex = 42;
            picLogoBig.TabStop = false;
            // 
            // tBoxReadPesado
            // 
            tBoxReadPesado.BackColor = SystemColors.Control;
            tBoxReadPesado.BorderStyle = BorderStyle.FixedSingle;
            tBoxReadPesado.Font = new Font("Franklin Gothic Medium", 30F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxReadPesado.ForeColor = Color.Black;
            tBoxReadPesado.Location = new Point(10, 100);
            tBoxReadPesado.Margin = new Padding(4);
            tBoxReadPesado.Multiline = true;
            tBoxReadPesado.Name = "tBoxReadPesado";
            tBoxReadPesado.ReadOnly = true;
            tBoxReadPesado.Size = new Size(196, 58);
            tBoxReadPesado.TabIndex = 33;
            tBoxReadPesado.Text = "59.23 kg";
            tBoxReadPesado.TextAlign = HorizontalAlignment.Center;
            // 
            // minWPesado
            // 
            minWPesado.AutoSize = true;
            minWPesado.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            minWPesado.Location = new Point(10, 162);
            minWPesado.Margin = new Padding(4, 0, 4, 0);
            minWPesado.Name = "minWPesado";
            minWPesado.Size = new Size(74, 24);
            minWPesado.TabIndex = 44;
            minWPesado.Text = "mínimo";
            // 
            // maxWPesado
            // 
            maxWPesado.AutoSize = true;
            maxWPesado.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            maxWPesado.Location = new Point(10, 74);
            maxWPesado.Margin = new Padding(4, 0, 4, 0);
            maxWPesado.Name = "maxWPesado";
            maxWPesado.Size = new Size(77, 24);
            maxWPesado.TabIndex = 45;
            maxWPesado.Text = "máximo";
            // 
            // weightList
            // 
            weightList.AllowUserToAddRows = false;
            weightList.AllowUserToDeleteRows = false;
            weightList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            weightList.BackgroundColor = SystemColors.Control;
            weightList.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            weightList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            weightList.ColumnHeadersHeight = 10;
            weightList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            weightList.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            weightList.DefaultCellStyle = dataGridViewCellStyle4;
            weightList.Location = new Point(1224, 72);
            weightList.MultiSelect = false;
            weightList.Name = "weightList";
            weightList.ReadOnly = true;
            weightList.RowHeadersVisible = false;
            weightList.RowHeadersWidth = 60;
            weightList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            weightList.RowTemplate.Height = 40;
            weightList.RowTemplate.ReadOnly = true;
            weightList.Size = new Size(511, 715);
            weightList.TabIndex = 46;
            weightList.CellContentClick += weightList_CellContentClick;
            // 
            // tmrLowPrior
            // 
            tmrLowPrior.Enabled = true;
            tmrLowPrior.Interval = 1000;
            tmrLowPrior.Tick += tmrLowPrior_Tick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1224, 39);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(212, 30);
            label7.TabIndex = 23;
            label7.Text = "Lista de materiales";
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.BackColor = Color.Red;
            btnCancelOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelOrder.ForeColor = Color.White;
            btnCancelOrder.Location = new Point(1502, 832);
            btnCancelOrder.Margin = new Padding(4);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(233, 80);
            btnCancelOrder.TabIndex = 47;
            btnCancelOrder.Text = "Cancelar orden";
            btnCancelOrder.UseVisualStyleBackColor = false;
            btnCancelOrder.Visible = false;
            btnCancelOrder.Click += btnCancelOrder_Click;
            // 
            // btnEditOrder
            // 
            btnEditOrder.Enabled = false;
            btnEditOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditOrder.Location = new Point(217, 953);
            btnEditOrder.Margin = new Padding(4);
            btnEditOrder.Name = "btnEditOrder";
            btnEditOrder.Size = new Size(190, 80);
            btnEditOrder.TabIndex = 48;
            btnEditOrder.Text = "Editar orden ";
            btnEditOrder.UseVisualStyleBackColor = true;
            btnEditOrder.Click += btnEditOrder_Click;
            // 
            // maxWLigero
            // 
            maxWLigero.AutoSize = true;
            maxWLigero.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            maxWLigero.Location = new Point(7, 72);
            maxWLigero.Margin = new Padding(4, 0, 4, 0);
            maxWLigero.Name = "maxWLigero";
            maxWLigero.Size = new Size(77, 24);
            maxWLigero.TabIndex = 51;
            maxWLigero.Text = "máximo";
            // 
            // minWLigero
            // 
            minWLigero.AutoSize = true;
            minWLigero.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            minWLigero.Location = new Point(10, 162);
            minWLigero.Margin = new Padding(4, 0, 4, 0);
            minWLigero.Name = "minWLigero";
            minWLigero.Size = new Size(74, 24);
            minWLigero.TabIndex = 50;
            minWLigero.Text = "mínimo";
            // 
            // tBoxReadLigero
            // 
            tBoxReadLigero.BackColor = SystemColors.Control;
            tBoxReadLigero.BorderStyle = BorderStyle.FixedSingle;
            tBoxReadLigero.Font = new Font("Franklin Gothic Medium", 30F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxReadLigero.ForeColor = Color.Black;
            tBoxReadLigero.Location = new Point(10, 100);
            tBoxReadLigero.Margin = new Padding(4);
            tBoxReadLigero.Multiline = true;
            tBoxReadLigero.Name = "tBoxReadLigero";
            tBoxReadLigero.ReadOnly = true;
            tBoxReadLigero.Size = new Size(203, 58);
            tBoxReadLigero.TabIndex = 49;
            tBoxReadLigero.Text = "29.987kg";
            tBoxReadLigero.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(24, 4);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(175, 34);
            label8.TabIndex = 53;
            label8.Text = "Báscula 30kg";
            // 
            // statusBasculaLigera
            // 
            statusBasculaLigera.BackColor = SystemColors.Control;
            statusBasculaLigera.BorderStyle = BorderStyle.None;
            statusBasculaLigera.Font = new Font("Franklin Gothic Medium", 17F, FontStyle.Regular, GraphicsUnit.Point);
            statusBasculaLigera.ForeColor = Color.Red;
            statusBasculaLigera.Location = new Point(20, 39);
            statusBasculaLigera.Margin = new Padding(4);
            statusBasculaLigera.Name = "statusBasculaLigera";
            statusBasculaLigera.ReadOnly = true;
            statusBasculaLigera.Size = new Size(182, 26);
            statusBasculaLigera.TabIndex = 52;
            statusBasculaLigera.TabStop = false;
            statusBasculaLigera.Text = "Desconectado";
            statusBasculaLigera.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(24, 4);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(175, 34);
            label9.TabIndex = 55;
            label9.Text = "Báscula 60kg";
            // 
            // statusBasculaPesada
            // 
            statusBasculaPesada.BackColor = SystemColors.Control;
            statusBasculaPesada.BorderStyle = BorderStyle.None;
            statusBasculaPesada.Font = new Font("Franklin Gothic Medium", 17F, FontStyle.Regular, GraphicsUnit.Point);
            statusBasculaPesada.ForeColor = Color.Red;
            statusBasculaPesada.Location = new Point(20, 39);
            statusBasculaPesada.Margin = new Padding(4);
            statusBasculaPesada.Name = "statusBasculaPesada";
            statusBasculaPesada.ReadOnly = true;
            statusBasculaPesada.Size = new Size(182, 26);
            statusBasculaPesada.TabIndex = 54;
            statusBasculaPesada.TabStop = false;
            statusBasculaPesada.Text = "Desconectado";
            statusBasculaPesada.TextAlign = HorizontalAlignment.Center;
            // 
            // panelLigera
            // 
            panelLigera.BorderStyle = BorderStyle.FixedSingle;
            panelLigera.Controls.Add(label8);
            panelLigera.Controls.Add(statusBasculaLigera);
            panelLigera.Controls.Add(maxWLigero);
            panelLigera.Controls.Add(minWLigero);
            panelLigera.Controls.Add(tBoxReadLigero);
            panelLigera.Location = new Point(206, 478);
            panelLigera.Name = "panelLigera";
            panelLigera.Size = new Size(224, 196);
            panelLigera.TabIndex = 56;
            // 
            // panelPesada
            // 
            panelPesada.BorderStyle = BorderStyle.FixedSingle;
            panelPesada.Controls.Add(label9);
            panelPesada.Controls.Add(statusBasculaPesada);
            panelPesada.Controls.Add(maxWPesado);
            panelPesada.Controls.Add(minWPesado);
            panelPesada.Controls.Add(tBoxReadPesado);
            panelPesada.Location = new Point(830, 478);
            panelPesada.Name = "panelPesada";
            panelPesada.Size = new Size(217, 196);
            panelPesada.TabIndex = 57;
            // 
            // panelCodeLigero
            // 
            panelCodeLigero.BorderStyle = BorderStyle.FixedSingle;
            panelCodeLigero.Controls.Add(btnOkCodeLigero);
            panelCodeLigero.Controls.Add(label5);
            panelCodeLigero.Controls.Add(tCodigoLigero);
            panelCodeLigero.Location = new Point(226, 681);
            panelCodeLigero.Margin = new Padding(4);
            panelCodeLigero.Name = "panelCodeLigero";
            panelCodeLigero.Size = new Size(204, 143);
            panelCodeLigero.TabIndex = 58;
            // 
            // btnOkCodeLigero
            // 
            btnOkCodeLigero.Location = new Point(55, 97);
            btnOkCodeLigero.Margin = new Padding(4);
            btnOkCodeLigero.Name = "btnOkCodeLigero";
            btnOkCodeLigero.Size = new Size(96, 33);
            btnOkCodeLigero.TabIndex = 22;
            btnOkCodeLigero.Text = "OK";
            btnOkCodeLigero.UseVisualStyleBackColor = true;
            btnOkCodeLigero.Click += btnSendLigeroCode_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 14);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(170, 24);
            label5.TabIndex = 18;
            label5.Text = "Código del material";
            // 
            // tCodigoLigero
            // 
            tCodigoLigero.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            tCodigoLigero.Location = new Point(13, 56);
            tCodigoLigero.Margin = new Padding(4);
            tCodigoLigero.Name = "tCodigoLigero";
            tCodigoLigero.Size = new Size(178, 30);
            tCodigoLigero.TabIndex = 17;
            tCodigoLigero.KeyPress += tCodigoLigero_KeyPress;
            // 
            // btnWeightPesadoOK
            // 
            btnWeightPesadoOK.Location = new Point(878, 681);
            btnWeightPesadoOK.Margin = new Padding(4);
            btnWeightPesadoOK.Name = "btnWeightPesadoOK";
            btnWeightPesadoOK.Size = new Size(129, 63);
            btnWeightPesadoOK.TabIndex = 61;
            btnWeightPesadoOK.Text = "OK";
            btnWeightPesadoOK.UseVisualStyleBackColor = true;
            btnWeightPesadoOK.Click += btnWeightPesadoOK_Click;
            // 
            // intructionsLigero
            // 
            intructionsLigero.BackColor = SystemColors.Control;
            intructionsLigero.BorderStyle = BorderStyle.None;
            intructionsLigero.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Regular, GraphicsUnit.Point);
            intructionsLigero.Location = new Point(45, 382);
            intructionsLigero.Multiline = true;
            intructionsLigero.Name = "intructionsLigero";
            intructionsLigero.Size = new Size(385, 90);
            intructionsLigero.TabIndex = 62;
            intructionsLigero.Text = "ZZ.00.000 \r\nSolprene 4301 MX / Globalprene 3501";
            intructionsLigero.TextAlign = HorizontalAlignment.Right;
            // 
            // instructionsPesado
            // 
            instructionsPesado.BackColor = SystemColors.Control;
            instructionsPesado.BorderStyle = BorderStyle.None;
            instructionsPesado.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Regular, GraphicsUnit.Point);
            instructionsPesado.Location = new Point(829, 382);
            instructionsPesado.Multiline = true;
            instructionsPesado.Name = "instructionsPesado";
            instructionsPesado.Size = new Size(385, 90);
            instructionsPesado.TabIndex = 63;
            instructionsPesado.Text = "ZZ.00.000 \r\nSolprene 4301 MX / Globalprene 3501";
            // 
            // richInstructions
            // 
            richInstructions.BackColor = SystemColors.Control;
            richInstructions.BorderStyle = BorderStyle.None;
            richInstructions.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Regular, GraphicsUnit.Point);
            richInstructions.Location = new Point(169, 297);
            richInstructions.Name = "richInstructions";
            richInstructions.Size = new Size(924, 28);
            richInstructions.TabIndex = 64;
            richInstructions.Text = "0.000 kg\r\nZZ.00.000 \r\nSolprene 4301 MX / Globalprene 3501";
            richInstructions.TextAlign = HorizontalAlignment.Center;
            // 
            // lblObjetivo1
            // 
            lblObjetivo1.AutoSize = true;
            lblObjetivo1.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblObjetivo1.Location = new Point(13, 541);
            lblObjetivo1.Margin = new Padding(4, 0, 4, 0);
            lblObjetivo1.Name = "lblObjetivo1";
            lblObjetivo1.Size = new Size(190, 34);
            lblObjetivo1.TabIndex = 54;
            lblObjetivo1.Text = "Peso requerido";
            // 
            // objetivoLigera
            // 
            objetivoLigera.BackColor = SystemColors.Control;
            objetivoLigera.BorderStyle = BorderStyle.None;
            objetivoLigera.Font = new Font("Franklin Gothic Medium", 30F, FontStyle.Regular, GraphicsUnit.Point);
            objetivoLigera.ForeColor = Color.Blue;
            objetivoLigera.Location = new Point(1, 579);
            objetivoLigera.Margin = new Padding(4);
            objetivoLigera.Multiline = true;
            objetivoLigera.Name = "objetivoLigera";
            objetivoLigera.ReadOnly = true;
            objetivoLigera.Size = new Size(203, 58);
            objetivoLigera.TabIndex = 54;
            objetivoLigera.Text = "30.987kg";
            objetivoLigera.TextAlign = HorizontalAlignment.Center;
            // 
            // objetivoPesada
            // 
            objetivoPesada.BackColor = SystemColors.Control;
            objetivoPesada.BorderStyle = BorderStyle.None;
            objetivoPesada.Font = new Font("Franklin Gothic Medium", 30F, FontStyle.Regular, GraphicsUnit.Point);
            objetivoPesada.ForeColor = Color.Blue;
            objetivoPesada.Location = new Point(1045, 579);
            objetivoPesada.Margin = new Padding(4);
            objetivoPesada.Multiline = true;
            objetivoPesada.Name = "objetivoPesada";
            objetivoPesada.ReadOnly = true;
            objetivoPesada.Size = new Size(172, 58);
            objetivoPesada.TabIndex = 65;
            objetivoPesada.Text = "50.97kg";
            objetivoPesada.TextAlign = HorizontalAlignment.Center;
            // 
            // lblObjetivo2
            // 
            lblObjetivo2.AutoSize = true;
            lblObjetivo2.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblObjetivo2.Location = new Point(1041, 543);
            lblObjetivo2.Margin = new Padding(4, 0, 4, 0);
            lblObjetivo2.Name = "lblObjetivo2";
            lblObjetivo2.Size = new Size(190, 34);
            lblObjetivo2.TabIndex = 66;
            lblObjetivo2.Text = "Peso requerido";
            // 
            // formPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1747, 1042);
            Controls.Add(objetivoLigera);
            Controls.Add(lblObjetivo1);
            Controls.Add(richInstructions);
            Controls.Add(instructionsPesado);
            Controls.Add(intructionsLigero);
            Controls.Add(panelCodeLigero);
            Controls.Add(panelPesada);
            Controls.Add(panelLigera);
            Controls.Add(btnEditOrder);
            Controls.Add(label7);
            Controls.Add(weightList);
            Controls.Add(picLogoBig);
            Controls.Add(BtnCalidad);
            Controls.Add(btnCancelOrder);
            Controls.Add(btnCloseOrder);
            Controls.Add(panelCodePesado);
            Controls.Add(btnCheckOrder);
            Controls.Add(btnChangeOrder);
            Controls.Add(lblCargaCount);
            Controls.Add(btnClearOrder);
            Controls.Add(btnLogin);
            Controls.Add(btnAmount);
            Controls.Add(label4);
            Controls.Add(tOrder);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(tBoxProducto);
            Controls.Add(btnSelectProduct);
            Controls.Add(btnWeightPesadoOK);
            Controls.Add(btnWeightLigeroOK);
            Controls.Add(objetivoPesada);
            Controls.Add(lblObjetivo2);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "formPrincipal";
            Text = "formPrincipal";
            Load += formPrincipal_Load;
            VisibleChanged += formPrincipal_VisibleChanged;
            Paint += formPrincipal_Paint;
            Leave += formPrincipal_Leave;
            MouseMove += formPrincipal_MouseMove;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelCodePesado.ResumeLayout(false);
            panelCodePesado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoBig).EndInit();
            ((System.ComponentModel.ISupportInitialize)weightList).EndInit();
            panelLigera.ResumeLayout(false);
            panelLigera.PerformLayout();
            panelPesada.ResumeLayout(false);
            panelPesada.PerformLayout();
            panelCodeLigero.ResumeLayout(false);
            panelCodeLigero.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSelectProduct;
        private TextBox tBoxProducto;
        private PictureBox pictureBox1;
        private Label label1;
        private System.Windows.Forms.Timer tmrHiPrior;
        private TextBox tCodigoPesado;
        private Label label2;
        private Button btnWeightLigeroOK;
        private Button btnOKCodePesado;
        private TextBox lblInstructions;
        private Label label4;
        public TextBox tOrder;
        private Button btnAmount;
		private TextBox tBoxStatusBascula;
        private Button btnLogin;
        private Button btnClearOrder;
		private Label lblCargaCount;
		private Button btnChangeOrder;
		private Button btnCheckOrder;
		private Panel panelCodePesado;
        private Button btnCloseOrder;
		private Button BtnCalidad;
        private PictureBox picLogoBig;
        private TextBox tBoxReadPesado;
		private Label minWPesado;
		private Label maxWPesado;
		private DataGridView weightList;
		private System.Windows.Forms.Timer tmrLowPrior;
		private Label label7;
		private Button btnCancelOrder;
        private Button btnEditOrder;
        private Label maxWLigero;
        private Label minWLigero;
        private TextBox tBoxReadLigero;
        private Label label8;
        private TextBox statusBasculaLigera;
        private Label label9;
        private TextBox statusBasculaPesada;
        private Panel panelLigera;
        private Panel panelPesada;
        private Panel panelCodeLigero;
        private Button btnOkCodeLigero;
        private Label label5;
        private TextBox tCodigoLigero;
        private Button btnWeightPesadoOK;
		private TextBox intructionsLigero;
		private TextBox instructionsPesado;
		private TextBox richInstructions;
        private Label lblObjetivo1;
        private TextBox objetivoLigera;
        private TextBox objetivoPesada;
        private Label lblObjetivo2;
    }
}