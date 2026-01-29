namespace Mezclador
{
    partial class formOrdenes
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
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			lblInstructions = new Label();
			dgvProduccion = new DataGridView();
			label1 = new Label();
			dgvConsumption = new DataGridView();
			((System.ComponentModel.ISupportInitialize)dgvProduccion).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvConsumption).BeginInit();
			SuspendLayout();
			// 
			// lblInstructions
			// 
			lblInstructions.AutoSize = true;
			lblInstructions.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
			lblInstructions.Location = new Point(825, 22);
			lblInstructions.Margin = new Padding(4, 0, 4, 0);
			lblInstructions.Name = "lblInstructions";
			lblInstructions.Size = new Size(96, 34);
			lblInstructions.TabIndex = 15;
			lblInstructions.Text = "Cargas";
			lblInstructions.Click += lblInstructions_Click;
			// 
			// dgvProduccion
			// 
			dgvProduccion.AllowUserToAddRows = false;
			dgvProduccion.AllowUserToDeleteRows = false;
			dgvProduccion.AllowUserToOrderColumns = true;
			dgvProduccion.AllowUserToResizeRows = false;
			dgvProduccion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvProduccion.BackgroundColor = SystemColors.Control;
			dgvProduccion.BorderStyle = BorderStyle.None;
			dgvProduccion.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dgvProduccion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvProduccion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvProduccion.ColumnHeadersHeight = 40;
			dgvProduccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			dgvProduccion.DefaultCellStyle = dataGridViewCellStyle2;
			dgvProduccion.GridColor = Color.White;
			dgvProduccion.Location = new Point(15, 79);
			dgvProduccion.Margin = new Padding(4, 4, 4, 4);
			dgvProduccion.MultiSelect = false;
			dgvProduccion.Name = "dgvProduccion";
			dgvProduccion.ReadOnly = true;
			dgvProduccion.RowHeadersVisible = false;
			dgvProduccion.RowHeadersWidth = 60;
			dgvProduccion.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			dgvProduccion.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgvProduccion.RowTemplate.Height = 80;
			dgvProduccion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvProduccion.Size = new Size(1719, 278);
			dgvProduccion.TabIndex = 13;
			dgvProduccion.ColumnHeaderMouseClick += dgvProduccion_ColumnHeaderMouseClick;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(726, 411);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(294, 34);
			label1.TabIndex = 16;
			label1.Text = "Consumo de materiales";
			// 
			// dgvConsumption
			// 
			dgvConsumption.AllowUserToAddRows = false;
			dgvConsumption.AllowUserToDeleteRows = false;
			dgvConsumption.AllowUserToOrderColumns = true;
			dgvConsumption.AllowUserToResizeRows = false;
			dgvConsumption.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvConsumption.BackgroundColor = SystemColors.Control;
			dgvConsumption.BorderStyle = BorderStyle.None;
			dgvConsumption.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dgvConsumption.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = SystemColors.Control;
			dataGridViewCellStyle4.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgvConsumption.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgvConsumption.ColumnHeadersHeight = 40;
			dgvConsumption.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = SystemColors.Window;
			dataGridViewCellStyle5.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
			dgvConsumption.DefaultCellStyle = dataGridViewCellStyle5;
			dgvConsumption.GridColor = Color.White;
			dgvConsumption.Location = new Point(15, 477);
			dgvConsumption.Margin = new Padding(4, 4, 4, 4);
			dgvConsumption.MultiSelect = false;
			dgvConsumption.Name = "dgvConsumption";
			dgvConsumption.ReadOnly = true;
			dgvConsumption.RowHeadersVisible = false;
			dgvConsumption.RowHeadersWidth = 60;
			dgvConsumption.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			dgvConsumption.RowsDefaultCellStyle = dataGridViewCellStyle6;
			dgvConsumption.RowTemplate.Height = 80;
			dgvConsumption.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvConsumption.Size = new Size(1719, 533);
			dgvConsumption.TabIndex = 17;
			// 
			// formOrdenes
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1747, 1023);
			Controls.Add(dgvConsumption);
			Controls.Add(label1);
			Controls.Add(dgvProduccion);
			Controls.Add(lblInstructions);
			Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(4, 4, 4, 4);
			Name = "formOrdenes";
			Text = "formProduccion";
			VisibleChanged += formProduccion_VisibleChanged;
			((System.ComponentModel.ISupportInitialize)dgvProduccion).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvConsumption).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblInstructions;
        private Label lblNoRecipes;
        private DataGridView dgvProduccion;
		private Label label1;
		private DataGridView dgvConsumption;
	}
}