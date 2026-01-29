namespace Mezclador
{
    partial class EditProducto
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
            lblNoRecipes = new Label();
            dgvRecetas = new DataGridView();
            lblInstructions = new Label();
            btnEdit = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRecetas).BeginInit();
            SuspendLayout();
            // 
            // lblNoRecipes
            // 
            lblNoRecipes.AutoSize = true;
            lblNoRecipes.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNoRecipes.Location = new Point(737, 490);
            lblNoRecipes.Margin = new Padding(4, 0, 4, 0);
            lblNoRecipes.Name = "lblNoRecipes";
            lblNoRecipes.Size = new Size(273, 26);
            lblNoRecipes.TabIndex = 11;
            lblNoRecipes.Text = "No hay productos disponibles";
            lblNoRecipes.Visible = false;
            // 
            // dgvRecetas
            // 
            dgvRecetas.AllowUserToAddRows = false;
            dgvRecetas.AllowUserToDeleteRows = false;
            dgvRecetas.AllowUserToOrderColumns = true;
            dgvRecetas.AllowUserToResizeColumns = false;
            dgvRecetas.AllowUserToResizeRows = false;
            dgvRecetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecetas.BackgroundColor = SystemColors.Control;
            dgvRecetas.BorderStyle = BorderStyle.None;
            dgvRecetas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRecetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecetas.ColumnHeadersHeight = 40;
            dgvRecetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Franklin Gothic Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRecetas.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRecetas.GridColor = Color.White;
            dgvRecetas.Location = new Point(15, 94);
            dgvRecetas.Margin = new Padding(4);
            dgvRecetas.MultiSelect = false;
            dgvRecetas.Name = "dgvRecetas";
            dgvRecetas.ReadOnly = true;
            dgvRecetas.RowHeadersVisible = false;
            dgvRecetas.RowHeadersWidth = 80;
            dgvRecetas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Franklin Gothic Medium", 15.25F, FontStyle.Regular, GraphicsUnit.Point);
            dgvRecetas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvRecetas.RowTemplate.Height = 80;
            dgvRecetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecetas.Size = new Size(1681, 818);
            dgvRecetas.TabIndex = 10;
            dgvRecetas.ColumnHeaderMouseClick += dgvRecetas_ColumnHeaderMouseClick;
            dgvRecetas.DoubleClick += dgvRecetas_DoubleClick;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblInstructions.Location = new Point(821, 30);
            lblInstructions.Margin = new Padding(4, 0, 4, 0);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(109, 34);
            lblInstructions.TabIndex = 12;
            lblInstructions.Text = "Recetas";
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.Location = new Point(889, 940);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(154, 48);
            btnEdit.TabIndex = 19;
            btnEdit.Text = "🖋 Editar";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(710, 940);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 48);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "➕ Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1068, 940);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(161, 48);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // EditProducto
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(lblInstructions);
            Controls.Add(lblNoRecipes);
            Controls.Add(dgvRecetas);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "EditProducto";
            Text = "formEditRecipe";
            Load += formEditRecipe_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRecetas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNoRecipes;
        private DataGridView dgvRecetas;
        private Label lblInstructions;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnDelete;
    }
}