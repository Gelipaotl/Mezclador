namespace Mezclador
{
    partial class AddEditMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditMaterial));
            tBoxMaterial = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnExaminar = new Button();
            btnSave = new Button();
            lblCodigo = new Label();
            tBoxCodigo = new TextBox();
            checkEscaneable = new CheckBox();
            label3 = new Label();
            tBoxNombre = new TextBox();
            checkSaco = new CheckBox();
            label4 = new Label();
            tBoxSaco = new TextBox();
            label5 = new Label();
            checkAceite = new CheckBox();
            label6 = new Label();
            tBoxFactor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tBoxMaterial
            // 
            tBoxMaterial.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxMaterial.Location = new Point(147, 21);
            tBoxMaterial.Margin = new Padding(4);
            tBoxMaterial.Name = "tBoxMaterial";
            tBoxMaterial.PlaceholderText = "ZZ.00.0000";
            tBoxMaterial.Size = new Size(189, 26);
            tBoxMaterial.TabIndex = 0;
            tBoxMaterial.KeyPress += tBoxMaterial_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 1;
            label1.Text = "Material";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(58, 311);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 21);
            label2.TabIndex = 2;
            label2.Text = "Imagen";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(147, 311);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(259, 189);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnExaminar
            // 
            btnExaminar.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExaminar.Location = new Point(420, 311);
            btnExaminar.Margin = new Padding(4);
            btnExaminar.Name = "btnExaminar";
            btnExaminar.Size = new Size(131, 44);
            btnExaminar.TabIndex = 4;
            btnExaminar.Text = "Examinar";
            btnExaminar.UseVisualStyleBackColor = true;
            btnExaminar.Click += btnExaminar_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(233, 519);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 47);
            btnSave.TabIndex = 5;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCodigo.Location = new Point(64, 173);
            lblCodigo.Margin = new Padding(4, 0, 4, 0);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(56, 21);
            lblCodigo.TabIndex = 9;
            lblCodigo.Text = "Codigo";
            // 
            // tBoxCodigo
            // 
            tBoxCodigo.Enabled = false;
            tBoxCodigo.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxCodigo.Location = new Point(147, 172);
            tBoxCodigo.Margin = new Padding(4);
            tBoxCodigo.Name = "tBoxCodigo";
            tBoxCodigo.PlaceholderText = "Introduce el código";
            tBoxCodigo.Size = new Size(189, 26);
            tBoxCodigo.TabIndex = 8;
            // 
            // checkEscaneable
            // 
            checkEscaneable.AutoSize = true;
            checkEscaneable.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkEscaneable.Location = new Point(53, 122);
            checkEscaneable.Margin = new Padding(4);
            checkEscaneable.Name = "checkEscaneable";
            checkEscaneable.Size = new Size(150, 25);
            checkEscaneable.TabIndex = 10;
            checkEscaneable.Text = "Se debe escanear";
            checkEscaneable.UseVisualStyleBackColor = true;
            checkEscaneable.CheckedChanged += checkEscaneable_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(56, 73);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 21);
            label3.TabIndex = 12;
            label3.Text = "Nombre";
            label3.Click += label3_Click;
            // 
            // tBoxNombre
            // 
            tBoxNombre.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxNombre.Location = new Point(147, 69);
            tBoxNombre.Margin = new Padding(4);
            tBoxNombre.Name = "tBoxNombre";
            tBoxNombre.PlaceholderText = "Introduce el nombre";
            tBoxNombre.Size = new Size(295, 26);
            tBoxNombre.TabIndex = 11;
            // 
            // checkSaco
            // 
            checkSaco.AutoSize = true;
            checkSaco.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkSaco.Location = new Point(222, 122);
            checkSaco.Margin = new Padding(4);
            checkSaco.Name = "checkSaco";
            checkSaco.Size = new Size(159, 25);
            checkSaco.TabIndex = 13;
            checkSaco.Text = "Empacado en saco";
            checkSaco.UseVisualStyleBackColor = true;
            checkSaco.CheckedChanged += checkSaco_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 219);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 15;
            label4.Text = "Peso del saco";
            // 
            // tBoxSaco
            // 
            tBoxSaco.Enabled = false;
            tBoxSaco.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxSaco.Location = new Point(147, 218);
            tBoxSaco.Margin = new Padding(4);
            tBoxSaco.Name = "tBoxSaco";
            tBoxSaco.PlaceholderText = "Introduce el peso";
            tBoxSaco.Size = new Size(148, 26);
            tBoxSaco.TabIndex = 14;
            tBoxSaco.TextChanged += tBoxSaco_TextChanged;
            tBoxSaco.KeyPress += textBoxSaco_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(297, 220);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(28, 21);
            label5.TabIndex = 16;
            label5.Text = "Kg";
            // 
            // checkAceite
            // 
            checkAceite.AutoSize = true;
            checkAceite.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkAceite.Location = new Point(400, 122);
            checkAceite.Margin = new Padding(4);
            checkAceite.Name = "checkAceite";
            checkAceite.Size = new Size(90, 25);
            checkAceite.TabIndex = 17;
            checkAceite.Text = "Es aceite";
            checkAceite.UseVisualStyleBackColor = true;
            checkAceite.CheckedChanged += checkAceite_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(17, 265);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(99, 21);
            label6.TabIndex = 19;
            label6.Text = "Factor L a Kg";
            // 
            // tBoxFactor
            // 
            tBoxFactor.Enabled = false;
            tBoxFactor.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tBoxFactor.Location = new Point(147, 264);
            tBoxFactor.Margin = new Padding(4);
            tBoxFactor.Name = "tBoxFactor";
            tBoxFactor.PlaceholderText = "Ejemplo 0.868";
            tBoxFactor.Size = new Size(148, 26);
            tBoxFactor.TabIndex = 18;
            tBoxFactor.KeyPress += tBoxLaKg_KeyPress;
            // 
            // AddEditMaterial
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 577);
            Controls.Add(label6);
            Controls.Add(tBoxFactor);
            Controls.Add(checkAceite);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tBoxSaco);
            Controls.Add(checkSaco);
            Controls.Add(label3);
            Controls.Add(tBoxNombre);
            Controls.Add(checkEscaneable);
            Controls.Add(lblCodigo);
            Controls.Add(tBoxCodigo);
            Controls.Add(btnSave);
            Controls.Add(btnExaminar);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tBoxMaterial);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditMaterial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Material";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tBoxMaterial;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btnExaminar;
        private Button btnSave;
        private Label lblCodigo;
        private TextBox tBoxCodigo;
        private CheckBox checkEscaneable;
        private Label label3;
        private TextBox tBoxNombre;
        private CheckBox checkSaco;
        private Label label4;
        private TextBox tBoxSaco;
        private Label label5;
        private CheckBox checkAceite;
        private Label label6;
        private TextBox tBoxFactor;
    }
}