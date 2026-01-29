namespace Mezclador
{
    partial class AddEditProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditProducto));
            btnSave = new Button();
            label1 = new Label();
            tBoxName = new TextBox();
            cBoxMateriales = new ComboBox();
            label2 = new Label();
            btnAddProd = new Button();
            panel1 = new Panel();
            btnAllPesada = new Button();
            btnAllLigera = new Button();
            btnBajarPaso = new Button();
            btnSubirPaso = new Button();
            dgvRecetaMateriales = new DataGridView();
            amountDown = new Button();
            amountUp = new Button();
            lblTotalMat = new Label();
            lblErrDuplicate = new Label();
            btnDeleteRow = new Button();
            label4 = new Label();
            label3 = new Label();
            numCantidad = new NumericUpDown();
            label5 = new Label();
            tBoxProducto = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecetaMateriales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(465, 788);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(116, 48);
            btnSave.TabIndex = 7;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(68, 68);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 12;
            label1.Text = "Nombre";
            // 
            // tBoxName
            // 
            tBoxName.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxName.Location = new Point(140, 65);
            tBoxName.Margin = new Padding(4);
            tBoxName.Name = "tBoxName";
            tBoxName.PlaceholderText = "Inserta el nombre";
            tBoxName.Size = new Size(274, 26);
            tBoxName.TabIndex = 2;
            // 
            // cBoxMateriales
            // 
            cBoxMateriales.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cBoxMateriales.FormattingEnabled = true;
            cBoxMateriales.Location = new Point(108, 37);
            cBoxMateriales.Margin = new Padding(4);
            cBoxMateriales.Name = "cBoxMateriales";
            cBoxMateriales.Size = new Size(231, 29);
            cBoxMateriales.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(36, 41);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 18;
            label2.Text = "Material:";
            // 
            // btnAddProd
            // 
            btnAddProd.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProd.Location = new Point(279, 102);
            btnAddProd.Margin = new Padding(4);
            btnAddProd.Name = "btnAddProd";
            btnAddProd.Size = new Size(181, 48);
            btnAddProd.TabIndex = 5;
            btnAddProd.Text = "Agregar material";
            btnAddProd.UseVisualStyleBackColor = true;
            btnAddProd.Click += btnAddProd_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnAllPesada);
            panel1.Controls.Add(btnAllLigera);
            panel1.Controls.Add(btnBajarPaso);
            panel1.Controls.Add(btnSubirPaso);
            panel1.Controls.Add(dgvRecetaMateriales);
            panel1.Controls.Add(amountDown);
            panel1.Controls.Add(amountUp);
            panel1.Controls.Add(lblTotalMat);
            panel1.Controls.Add(lblErrDuplicate);
            panel1.Controls.Add(btnDeleteRow);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(numCantidad);
            panel1.Controls.Add(btnAddProd);
            panel1.Controls.Add(cBoxMateriales);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(13, 117);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 650);
            panel1.TabIndex = 20;
            // 
            // btnAllPesada
            // 
            btnAllPesada.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAllPesada.Location = new Point(716, 89);
            btnAllPesada.Margin = new Padding(4);
            btnAllPesada.Name = "btnAllPesada";
            btnAllPesada.Size = new Size(282, 48);
            btnAllPesada.TabIndex = 31;
            btnAllPesada.Text = "Todos a bascula pesada";
            btnAllPesada.UseVisualStyleBackColor = true;
            btnAllPesada.Click += btnAllPesada_Click;
            // 
            // btnAllLigera
            // 
            btnAllLigera.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAllLigera.Location = new Point(716, 14);
            btnAllLigera.Margin = new Padding(4);
            btnAllLigera.Name = "btnAllLigera";
            btnAllLigera.Size = new Size(282, 48);
            btnAllLigera.TabIndex = 30;
            btnAllLigera.Text = "Todos a bascula ligera";
            btnAllLigera.UseVisualStyleBackColor = true;
            btnAllLigera.Click += btnAllLigera_Click;
            // 
            // btnBajarPaso
            // 
            btnBajarPaso.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnBajarPaso.Location = new Point(950, 236);
            btnBajarPaso.Margin = new Padding(4);
            btnBajarPaso.Name = "btnBajarPaso";
            btnBajarPaso.Size = new Size(48, 35);
            btnBajarPaso.TabIndex = 29;
            btnBajarPaso.Text = "🡇";
            btnBajarPaso.UseVisualStyleBackColor = true;
            btnBajarPaso.Click += btnBajarPaso_Click;
            // 
            // btnSubirPaso
            // 
            btnSubirPaso.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnSubirPaso.Location = new Point(950, 185);
            btnSubirPaso.Margin = new Padding(4);
            btnSubirPaso.Name = "btnSubirPaso";
            btnSubirPaso.Size = new Size(48, 37);
            btnSubirPaso.TabIndex = 28;
            btnSubirPaso.Text = "🡅";
            btnSubirPaso.UseVisualStyleBackColor = true;
            btnSubirPaso.Click += btnSubirPaso_Click;
            // 
            // dgvRecetaMateriales
            // 
            dgvRecetaMateriales.AllowUserToAddRows = false;
            dgvRecetaMateriales.AllowUserToDeleteRows = false;
            dgvRecetaMateriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRecetaMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecetaMateriales.Location = new Point(2, 163);
            dgvRecetaMateriales.Margin = new Padding(4);
            dgvRecetaMateriales.Name = "dgvRecetaMateriales";
            dgvRecetaMateriales.RowHeadersWidth = 62;
            dgvRecetaMateriales.RowTemplate.Height = 40;
            dgvRecetaMateriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecetaMateriales.Size = new Size(940, 405);
            dgvRecetaMateriales.TabIndex = 6;
            dgvRecetaMateriales.CellContentClick += dgvRecetaMateriales_CellContentClick;
            dgvRecetaMateriales.CellValidating += dgvRecetaMateriales_CellValidating;
            // 
            // amountDown
            // 
            amountDown.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            amountDown.Location = new Point(618, 59);
            amountDown.Margin = new Padding(4);
            amountDown.Name = "amountDown";
            amountDown.Size = new Size(48, 35);
            amountDown.TabIndex = 27;
            amountDown.Text = "🡇";
            amountDown.UseVisualStyleBackColor = true;
            amountDown.Click += amountDown_Click;
            // 
            // amountUp
            // 
            amountUp.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            amountUp.Location = new Point(618, 14);
            amountUp.Margin = new Padding(4);
            amountUp.Name = "amountUp";
            amountUp.Size = new Size(48, 37);
            amountUp.TabIndex = 26;
            amountUp.Text = "🡅";
            amountUp.UseVisualStyleBackColor = true;
            amountUp.Click += amountUp_Click;
            // 
            // lblTotalMat
            // 
            lblTotalMat.AutoSize = true;
            lblTotalMat.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalMat.Location = new Point(0, 138);
            lblTotalMat.Margin = new Padding(4, 0, 4, 0);
            lblTotalMat.Name = "lblTotalMat";
            lblTotalMat.Size = new Size(95, 21);
            lblTotalMat.TabIndex = 24;
            lblTotalMat.Text = "0 Materiales";
            // 
            // lblErrDuplicate
            // 
            lblErrDuplicate.AutoSize = true;
            lblErrDuplicate.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrDuplicate.ForeColor = Color.Red;
            lblErrDuplicate.Location = new Point(4, 599);
            lblErrDuplicate.Margin = new Padding(4, 0, 4, 0);
            lblErrDuplicate.Name = "lblErrDuplicate";
            lblErrDuplicate.Size = new Size(279, 21);
            lblErrDuplicate.TabIndex = 25;
            lblErrDuplicate.Text = "No se puede agregar el mismo material";
            lblErrDuplicate.Visible = false;
            // 
            // btnDeleteRow
            // 
            btnDeleteRow.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            btnDeleteRow.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteRow.Location = new Point(745, 586);
            btnDeleteRow.Margin = new Padding(4);
            btnDeleteRow.Name = "btnDeleteRow";
            btnDeleteRow.Size = new Size(197, 43);
            btnDeleteRow.TabIndex = 24;
            btnDeleteRow.Text = "Quitar de la lista";
            btnDeleteRow.UseVisualStyleBackColor = true;
            btnDeleteRow.Click += btnDeleteRow_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(584, 43);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(28, 21);
            label4.TabIndex = 24;
            label4.Text = "Kg";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(435, 43);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 23;
            label3.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.DecimalPlaces = 3;
            numCantidad.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numCantidad.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numCantidad.Location = new Point(515, 41);
            numCantidad.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(68, 26);
            numCantidad.TabIndex = 4;
            numCantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(75, 15);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 23;
            label5.Text = "Receta";
            // 
            // tBoxProducto
            // 
            tBoxProducto.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxProducto.Location = new Point(140, 15);
            tBoxProducto.Margin = new Padding(4);
            tBoxProducto.Name = "tBoxProducto";
            tBoxProducto.PlaceholderText = "ZZ.00.0000";
            tBoxProducto.Size = new Size(189, 26);
            tBoxProducto.TabIndex = 1;
            tBoxProducto.TextChanged += tBoxProducto_TextChanged;
            tBoxProducto.KeyPress += tBoxProducto_KeyPress;
            // 
            // AddEditProducto
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 849);
            Controls.Add(label5);
            Controls.Add(tBoxProducto);
            Controls.Add(panel1);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(tBoxName);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "AddEditProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecetaMateriales).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSave;
        private Label label1;
        private TextBox tBoxName;
        private ComboBox cBoxMateriales;
        private Label label2;
        private Button btnAddProd;
        private Panel panel1;
        private DataGridView dgvRecetaMateriales;
        private Label label3;
        private NumericUpDown numCantidad;
        private Label label4;
        private Label label5;
        private TextBox tBoxProducto;
        private Button btnDeleteRow;
		private Label lblErrDuplicate;
        private Label lblTotalMat;
        private Button amountDown;
        private Button amountUp;
        private Button btnBajarPaso;
        private Button btnSubirPaso;
        private Button btnAllLigera;
        private Button btnAllPesada;
    }
}