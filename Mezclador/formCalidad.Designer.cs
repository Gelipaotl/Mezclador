namespace Mezclador
{
	partial class formCalidad
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
			dgvCalidad = new DataGridView();
			lblInstructions = new Label();
			((System.ComponentModel.ISupportInitialize)dgvCalidad).BeginInit();
			SuspendLayout();
			// 
			// dgvCalidad
			// 
			dgvCalidad.AllowUserToAddRows = false;
			dgvCalidad.AllowUserToDeleteRows = false;
			dgvCalidad.AllowUserToOrderColumns = true;
			dgvCalidad.AllowUserToResizeRows = false;
			dgvCalidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvCalidad.BackgroundColor = SystemColors.Control;
			dgvCalidad.BorderStyle = BorderStyle.None;
			dgvCalidad.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dgvCalidad.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvCalidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvCalidad.ColumnHeadersHeight = 40;
			dgvCalidad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			dgvCalidad.DefaultCellStyle = dataGridViewCellStyle2;
			dgvCalidad.GridColor = Color.White;
			dgvCalidad.Location = new Point(15, 88);
			dgvCalidad.Margin = new Padding(4);
			dgvCalidad.MultiSelect = false;
			dgvCalidad.Name = "dgvCalidad";
			dgvCalidad.ReadOnly = true;
			dgvCalidad.RowHeadersVisible = false;
			dgvCalidad.RowHeadersWidth = 60;
			dgvCalidad.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			dgvCalidad.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgvCalidad.RowTemplate.Height = 80;
			dgvCalidad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvCalidad.Size = new Size(1719, 922);
			dgvCalidad.TabIndex = 14;
			// 
			// lblInstructions
			// 
			lblInstructions.AutoSize = true;
			lblInstructions.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
			lblInstructions.Location = new Point(747, 33);
			lblInstructions.Margin = new Padding(4, 0, 4, 0);
			lblInstructions.Name = "lblInstructions";
			lblInstructions.Size = new Size(253, 34);
			lblInstructions.TabIndex = 16;
			lblInstructions.Text = "Registros de calidad";
			// 
			// formCalidad
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1747, 1023);
			Controls.Add(dgvCalidad);
			Controls.Add(lblInstructions);
			Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(4);
			Name = "formCalidad";
			Text = "formCalidad";
			VisibleChanged += formCalidad_VisibleChanged;
			((System.ComponentModel.ISupportInitialize)dgvCalidad).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dgvCalidad;
		private Label lblInstructions;
	}
}