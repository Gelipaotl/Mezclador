namespace Mezclador.Users
{
    partial class ControlUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlUsers));
            dgvUsers = new DataGridView();
            btnEdit = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 12);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 60;
            dgvUsers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(564, 314);
            dgvUsers.TabIndex = 11;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnEdit.Location = new Point(220, 353);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(149, 48);
            btnEdit.TabIndex = 18;
            btnEdit.Text = "🖋 Editar";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.Location = new Point(12, 353);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(161, 48);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "➕ Añadir";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(415, 353);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(161, 48);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ControlUsers
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 419);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(dgvUsers);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "ControlUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de usuario";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnDelete;
    }
}