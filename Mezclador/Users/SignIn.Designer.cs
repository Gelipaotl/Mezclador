namespace Mezclador.Users
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            label1 = new Label();
            tboxName = new TextBox();
            btnRegister = new Button();
            btnRegFinger1 = new Button();
            btnRegFinger2 = new Button();
            label2 = new Label();
            cboxPermisos = new ComboBox();
            tboxPass = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(5, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // tboxName
            // 
            tboxName.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tboxName.Location = new Point(105, 9);
            tboxName.Margin = new Padding(4);
            tboxName.Name = "tboxName";
            tboxName.Size = new Size(230, 26);
            tboxName.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(149, 264);
            btnRegister.Margin = new Padding(4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(96, 37);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Finalizar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnRegFinger1
            // 
            btnRegFinger1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegFinger1.Location = new Point(86, 144);
            btnRegFinger1.Margin = new Padding(4);
            btnRegFinger1.Name = "btnRegFinger1";
            btnRegFinger1.Size = new Size(215, 45);
            btnRegFinger1.TabIndex = 3;
            btnRegFinger1.Text = "Registrar primer huella";
            btnRegFinger1.UseVisualStyleBackColor = true;
            btnRegFinger1.Click += btnRegFinger1_Click;
            // 
            // btnRegFinger2
            // 
            btnRegFinger2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegFinger2.Location = new Point(86, 200);
            btnRegFinger2.Margin = new Padding(4);
            btnRegFinger2.Name = "btnRegFinger2";
            btnRegFinger2.Size = new Size(215, 45);
            btnRegFinger2.TabIndex = 4;
            btnRegFinger2.Text = "Registrar segunda huella";
            btnRegFinger2.UseVisualStyleBackColor = true;
            btnRegFinger2.Click += btnRegFinger2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(5, 93);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 5;
            label2.Text = "Permisos:";
            // 
            // cboxPermisos
            // 
            cboxPermisos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxPermisos.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboxPermisos.FormattingEnabled = true;
            cboxPermisos.Location = new Point(105, 90);
            cboxPermisos.Margin = new Padding(4);
            cboxPermisos.Name = "cboxPermisos";
            cboxPermisos.Size = new Size(154, 29);
            cboxPermisos.TabIndex = 6;
            cboxPermisos.SelectedIndexChanged += cboxPermisos_SelectedIndexChanged;
            // 
            // tboxPass
            // 
            tboxPass.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tboxPass.Location = new Point(105, 48);
            tboxPass.Margin = new Padding(4);
            tboxPass.Name = "tboxPass";
            tboxPass.Size = new Size(230, 26);
            tboxPass.TabIndex = 8;
            tboxPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(5, 48);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(92, 21);
            label3.TabIndex = 7;
            label3.Text = "Contraseña:";
            // 
            // panel1
            // 
            panel1.Controls.Add(tboxPass);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cboxPermisos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnRegFinger2);
            panel1.Controls.Add(btnRegFinger1);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(tboxName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(7, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(376, 314);
            panel1.TabIndex = 9;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 332);
            Controls.Add(panel1);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar usuario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox tboxName;
        private Button btnRegister;
        private Button btnRegFinger1;
        private Button btnRegFinger2;
        private Label label2;
        private ComboBox cboxPermisos;
        private TextBox tboxPass;
        private Label label3;
        private Panel panel1;
    }
}