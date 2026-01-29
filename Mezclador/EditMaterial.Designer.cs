namespace Mezclador
{
    partial class EditMaterial
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
			lblInstructions = new Label();
			lblNoRecipes = new Label();
			dgvMateriales = new DataGridView();
			btnAdd = new Button();
			btnEdit = new Button();
			((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
			SuspendLayout();
			// 
			// lblInstructions
			// 
			lblInstructions.AutoSize = true;
			lblInstructions.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
			lblInstructions.Location = new Point(804, 37);
			lblInstructions.Margin = new Padding(4, 0, 4, 0);
			lblInstructions.Name = "lblInstructions";
			lblInstructions.Size = new Size(139, 34);
			lblInstructions.TabIndex = 15;
			lblInstructions.Text = "Materiales";
			// 
			// lblNoRecipes
			// 
			lblNoRecipes.AutoSize = true;
			lblNoRecipes.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
			lblNoRecipes.Location = new Point(733, 483);
			lblNoRecipes.Margin = new Padding(4, 0, 4, 0);
			lblNoRecipes.Name = "lblNoRecipes";
			lblNoRecipes.Size = new Size(280, 26);
			lblNoRecipes.TabIndex = 14;
			lblNoRecipes.Text = "No hay materiales disponibles";
			lblNoRecipes.Visible = false;
			// 
			// dgvMateriales
			// 
			dgvMateriales.AllowUserToAddRows = false;
			dgvMateriales.AllowUserToDeleteRows = false;
			dgvMateriales.AllowUserToOrderColumns = true;
			dgvMateriales.AllowUserToResizeRows = false;
			dgvMateriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvMateriales.BackgroundColor = SystemColors.Control;
			dgvMateriales.BorderStyle = BorderStyle.None;
			dgvMateriales.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvMateriales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvMateriales.ColumnHeadersHeight = 40;
			dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			dgvMateriales.DefaultCellStyle = dataGridViewCellStyle2;
			dgvMateriales.GridColor = Color.White;
			dgvMateriales.Location = new Point(48, 93);
			dgvMateriales.Margin = new Padding(4);
			dgvMateriales.MultiSelect = false;
			dgvMateriales.Name = "dgvMateriales";
			dgvMateriales.ReadOnly = true;
			dgvMateriales.RowHeadersVisible = false;
			dgvMateriales.RowHeadersWidth = 80;
			dgvMateriales.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Font = new Font("Franklin Gothic Medium", 15.25F, FontStyle.Regular, GraphicsUnit.Point);
			dgvMateriales.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgvMateriales.RowTemplate.Height = 80;
			dgvMateriales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMateriales.Size = new Size(1665, 806);
			dgvMateriales.TabIndex = 13;
			dgvMateriales.VirtualMode = true;
			dgvMateriales.ColumnHeaderMouseClick += dgvProductos_ColumnHeaderMouseClick;
			// 
			// btnAdd
			// 
			btnAdd.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			btnAdd.Location = new Point(710, 940);
			btnAdd.Margin = new Padding(4);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(161, 48);
			btnAdd.TabIndex = 16;
			btnAdd.Text = "➕ Añadir";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnEdit
			// 
			btnEdit.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			btnEdit.Location = new Point(902, 940);
			btnEdit.Margin = new Padding(4);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(149, 48);
			btnEdit.TabIndex = 17;
			btnEdit.Text = "🖋 Editar";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// EditMaterial
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1747, 1023);
			Controls.Add(btnEdit);
			Controls.Add(btnAdd);
			Controls.Add(lblInstructions);
			Controls.Add(lblNoRecipes);
			Controls.Add(dgvMateriales);
			Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(4);
			Name = "EditMaterial";
			Text = "formEditProduct";
			Load += formEditProduct_Load;
			((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblInstructions;
        private Label lblNoRecipes;
        private DataGridView dgvMateriales;
        private Button btnAdd;
        private Button btnEdit;
	}
}