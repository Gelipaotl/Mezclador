namespace Mezclador
{
    partial class formSetAmount
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSetAmount));
			numDesiredAmount = new NumericUpDown();
			label1 = new Label();
			tBoxProduct = new TextBox();
			label2 = new Label();
			dgvMateriales = new DataGridView();
			btnAccept = new Button();
			label3 = new Label();
			tBoxTotalProducts = new TextBox();
			label4 = new Label();
			btnUp = new Button();
			btnDown = new Button();
			btnRegresar = new Button();
			amountDown = new Button();
			amountUp = new Button();
			tBoxTotalProduct = new Label();
			tBoxOrder = new TextBox();
			lblOrder = new Label();
			((System.ComponentModel.ISupportInitialize)numDesiredAmount).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvMateriales).BeginInit();
			SuspendLayout();
			// 
			// numDesiredAmount
			// 
			numDesiredAmount.DecimalPlaces = 3;
			numDesiredAmount.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			numDesiredAmount.Location = new Point(640, 114);
			numDesiredAmount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
			numDesiredAmount.Name = "numDesiredAmount";
			numDesiredAmount.Size = new Size(120, 29);
			numDesiredAmount.TabIndex = 0;
			numDesiredAmount.ValueChanged += numDesiredAmount_ValueChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(46, 57);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(87, 24);
			label1.TabIndex = 1;
			label1.Text = "Producto:";
			// 
			// tBoxProduct
			// 
			tBoxProduct.BorderStyle = BorderStyle.None;
			tBoxProduct.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			tBoxProduct.Location = new Point(141, 59);
			tBoxProduct.Margin = new Padding(4);
			tBoxProduct.Name = "tBoxProduct";
			tBoxProduct.ReadOnly = true;
			tBoxProduct.Size = new Size(541, 22);
			tBoxProduct.TabIndex = 2;
			tBoxProduct.TextChanged += tBoxProduct_TextChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(390, 659);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(157, 20);
			label2.TabIndex = 3;
			label2.Text = "Cantidad por producto:";
			// 
			// dgvMateriales
			// 
			dgvMateriales.AllowUserToAddRows = false;
			dgvMateriales.AllowUserToDeleteRows = false;
			dgvMateriales.AllowUserToOrderColumns = true;
			dgvMateriales.AllowUserToResizeColumns = false;
			dgvMateriales.AllowUserToResizeRows = false;
			dgvMateriales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvMateriales.BackgroundColor = SystemColors.Control;
			dgvMateriales.BorderStyle = BorderStyle.None;
			dgvMateriales.CellBorderStyle = DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			dgvMateriales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			dgvMateriales.ColumnHeadersHeight = 40;
			dgvMateriales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			dgvMateriales.DefaultCellStyle = dataGridViewCellStyle2;
			dgvMateriales.GridColor = Color.White;
			dgvMateriales.Location = new Point(15, 180);
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
			dgvMateriales.Size = new Size(1119, 446);
			dgvMateriales.TabIndex = 14;
			// 
			// btnAccept
			// 
			btnAccept.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnAccept.Location = new Point(519, 719);
			btnAccept.Margin = new Padding(4);
			btnAccept.Name = "btnAccept";
			btnAccept.Size = new Size(112, 47);
			btnAccept.TabIndex = 15;
			btnAccept.Text = "Aceptar";
			btnAccept.UseVisualStyleBackColor = true;
			btnAccept.Click += btnAccept_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label3.Location = new Point(469, 116);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(164, 24);
			label3.TabIndex = 16;
			label3.Text = "Cantidad requerida";
			// 
			// tBoxTotalProducts
			// 
			tBoxTotalProducts.BackColor = SystemColors.Control;
			tBoxTotalProducts.BorderStyle = BorderStyle.None;
			tBoxTotalProducts.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Regular, GraphicsUnit.Point);
			tBoxTotalProducts.ForeColor = Color.Red;
			tBoxTotalProducts.Location = new Point(955, 659);
			tBoxTotalProducts.Margin = new Padding(4);
			tBoxTotalProducts.Name = "tBoxTotalProducts";
			tBoxTotalProducts.ReadOnly = true;
			tBoxTotalProducts.Size = new Size(64, 17);
			tBoxTotalProducts.TabIndex = 18;
			tBoxTotalProducts.Text = "1";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Regular, GraphicsUnit.Point);
			label4.Location = new Point(759, 659);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(155, 20);
			label4.TabIndex = 17;
			label4.Text = "Productos resultantes:";
			// 
			// btnUp
			// 
			btnUp.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			btnUp.Location = new Point(1027, 633);
			btnUp.Margin = new Padding(4);
			btnUp.Name = "btnUp";
			btnUp.Size = new Size(48, 37);
			btnUp.TabIndex = 19;
			btnUp.Text = "🡅";
			btnUp.UseVisualStyleBackColor = true;
			btnUp.Click += btnUp_Click;
			// 
			// btnDown
			// 
			btnDown.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			btnDown.Location = new Point(1027, 677);
			btnDown.Margin = new Padding(4);
			btnDown.Name = "btnDown";
			btnDown.Size = new Size(48, 35);
			btnDown.TabIndex = 21;
			btnDown.Text = "🡇";
			btnDown.UseVisualStyleBackColor = true;
			btnDown.Click += btnDown_Click;
			// 
			// btnRegresar
			// 
			btnRegresar.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnRegresar.Location = new Point(15, 719);
			btnRegresar.Margin = new Padding(4);
			btnRegresar.Name = "btnRegresar";
			btnRegresar.Size = new Size(112, 47);
			btnRegresar.TabIndex = 22;
			btnRegresar.Text = "Regresar";
			btnRegresar.UseVisualStyleBackColor = true;
			btnRegresar.Click += btnRegresar_Click;
			// 
			// amountDown
			// 
			amountDown.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			amountDown.Location = new Point(767, 130);
			amountDown.Margin = new Padding(4);
			amountDown.Name = "amountDown";
			amountDown.Size = new Size(48, 35);
			amountDown.TabIndex = 24;
			amountDown.Text = "🡇";
			amountDown.UseVisualStyleBackColor = true;
			amountDown.Click += amountDown_Click;
			// 
			// amountUp
			// 
			amountUp.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
			amountUp.Location = new Point(767, 86);
			amountUp.Margin = new Padding(4);
			amountUp.Name = "amountUp";
			amountUp.Size = new Size(48, 37);
			amountUp.TabIndex = 23;
			amountUp.Text = "🡅";
			amountUp.UseVisualStyleBackColor = true;
			amountUp.Click += amountUp_Click;
			// 
			// tBoxTotalProduct
			// 
			tBoxTotalProduct.AutoSize = true;
			tBoxTotalProduct.Location = new Point(554, 659);
			tBoxTotalProduct.Name = "tBoxTotalProduct";
			tBoxTotalProduct.Size = new Size(36, 21);
			tBoxTotalProduct.TabIndex = 25;
			tBoxTotalProduct.Text = "0kg";
			// 
			// tBoxOrder
			// 
			tBoxOrder.BorderStyle = BorderStyle.None;
			tBoxOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			tBoxOrder.Location = new Point(116, 25);
			tBoxOrder.Margin = new Padding(4);
			tBoxOrder.Name = "tBoxOrder";
			tBoxOrder.ReadOnly = true;
			tBoxOrder.Size = new Size(541, 22);
			tBoxOrder.TabIndex = 27;
			// 
			// lblOrder
			// 
			lblOrder.AutoSize = true;
			lblOrder.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lblOrder.Location = new Point(46, 25);
			lblOrder.Margin = new Padding(4, 0, 4, 0);
			lblOrder.Name = "lblOrder";
			lblOrder.Size = new Size(63, 24);
			lblOrder.TabIndex = 26;
			lblOrder.Text = "Orden:";
			// 
			// formSetAmount
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1149, 784);
			Controls.Add(tBoxOrder);
			Controls.Add(lblOrder);
			Controls.Add(tBoxTotalProduct);
			Controls.Add(amountDown);
			Controls.Add(amountUp);
			Controls.Add(btnRegresar);
			Controls.Add(btnDown);
			Controls.Add(btnUp);
			Controls.Add(tBoxTotalProducts);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(btnAccept);
			Controls.Add(dgvMateriales);
			Controls.Add(label2);
			Controls.Add(tBoxProduct);
			Controls.Add(label1);
			Controls.Add(numDesiredAmount);
			Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "formSetAmount";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Cantidad de producto requerida";
			FormClosed += formSetAmount_FormClosed;
			Load += formSetAmount_Load;
			((System.ComponentModel.ISupportInitialize)numDesiredAmount).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvMateriales).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private NumericUpDown numDesiredAmount;
        private Label label1;
        private TextBox tBoxProduct;
        private Label label2;
        private DataGridView dgvMateriales;
        private Button btnAccept;
        private Label label3;
        private TextBox tBoxTotalProducts;
        private Label label4;
		private Button btnUp;
		private Button btnDown;
        private Button btnRegresar;
        private Button amountDown;
        private Button amountUp;
        private Label tBoxTotalProduct;
        private TextBox tBoxOrder;
        private Label lblOrder;
    }
}