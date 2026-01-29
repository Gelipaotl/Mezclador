namespace Mezclador
{
    partial class formSelectProducto
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSelectProducto));
            lblInstructions = new Label();
            dataGridView1 = new DataGridView();
            btnAceptar = new Button();
            lblNoRecipes = new Label();
            btnRegresar = new Button();
            tBoxOrder = new TextBox();
            lblOrder = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblInstructions.Location = new Point(368, 44);
            lblInstructions.Margin = new Padding(4, 0, 4, 0);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(262, 34);
            lblInstructions.TabIndex = 6;
            lblInstructions.Text = "Seleccionar producto";
            lblInstructions.Click += lblInstructions_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(15, 90);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 80;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Franklin Gothic Medium", 15.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(967, 443);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting_1;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.Location = new Point(441, 553);
            btnAceptar.Margin = new Padding(4);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(116, 57);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblNoRecipes
            // 
            lblNoRecipes.AutoSize = true;
            lblNoRecipes.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNoRecipes.Location = new Point(363, 295);
            lblNoRecipes.Margin = new Padding(4, 0, 4, 0);
            lblNoRecipes.Name = "lblNoRecipes";
            lblNoRecipes.Size = new Size(273, 26);
            lblNoRecipes.TabIndex = 9;
            lblNoRecipes.Text = "No hay productos disponibles";
            lblNoRecipes.Visible = false;
            // 
            // btnRegresar
            // 
            btnRegresar.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegresar.Location = new Point(15, 560);
            btnRegresar.Margin = new Padding(4);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(112, 47);
            btnRegresar.TabIndex = 23;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // tBoxOrder
            // 
            tBoxOrder.BorderStyle = BorderStyle.None;
            tBoxOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxOrder.Location = new Point(85, 11);
            tBoxOrder.Margin = new Padding(4);
            tBoxOrder.Name = "tBoxOrder";
            tBoxOrder.ReadOnly = true;
            tBoxOrder.Size = new Size(541, 22);
            tBoxOrder.TabIndex = 25;
            // 
            // lblOrder
            // 
            lblOrder.AutoSize = true;
            lblOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrder.Location = new Point(15, 11);
            lblOrder.Margin = new Padding(4, 0, 4, 0);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(63, 24);
            lblOrder.TabIndex = 24;
            lblOrder.Text = "Orden:";
            // 
            // formSelectProducto
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 630);
            Controls.Add(tBoxOrder);
            Controls.Add(lblOrder);
            Controls.Add(btnRegresar);
            Controls.Add(lblNoRecipes);
            Controls.Add(btnAceptar);
            Controls.Add(dataGridView1);
            Controls.Add(lblInstructions);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "formSelectProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccionar Producto";
            Load += formSelectRecipe_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInstructions;
        private DataGridView dataGridView1;
        private Button btnAceptar;
        private Label lblNoRecipes;
        private Button btnRegresar;
		private TextBox tBoxOrder;
		private Label lblOrder;
	}
}