namespace Mezclador
{
    partial class Fingerprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fingerprint));
            Prompt = new TextBox();
            Picture = new PictureBox();
            Status = new TextBox();
            StatusLine = new Label();
            lblPassword = new Label();
            tBoxPassword = new TextBox();
            btnPassword = new Button();
            ((System.ComponentModel.ISupportInitialize)Picture).BeginInit();
            SuspendLayout();
            // 
            // Prompt
            // 
            Prompt.Location = new Point(31, 32);
            Prompt.Margin = new Padding(4, 5, 4, 5);
            Prompt.Name = "Prompt";
            Prompt.ReadOnly = true;
            Prompt.Size = new Size(378, 29);
            Prompt.TabIndex = 0;
            // 
            // Picture
            // 
            Picture.BorderStyle = BorderStyle.FixedSingle;
            Picture.Location = new Point(97, 79);
            Picture.Margin = new Padding(4, 5, 4, 5);
            Picture.Name = "Picture";
            Picture.Size = new Size(249, 258);
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Picture.TabIndex = 1;
            Picture.TabStop = false;
            // 
            // Status
            // 
            Status.Location = new Point(24, 409);
            Status.Margin = new Padding(4, 5, 4, 5);
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Size = new Size(393, 29);
            Status.TabIndex = 2;
            // 
            // StatusLine
            // 
            StatusLine.AutoSize = true;
            StatusLine.ForeColor = Color.FromArgb(0, 152, 152);
            StatusLine.Location = new Point(33, 362);
            StatusLine.Margin = new Padding(4, 0, 4, 0);
            StatusLine.Name = "StatusLine";
            StatusLine.Size = new Size(160, 24);
            StatusLine.TabIndex = 3;
            StatusLine.Text = "Lecturas restantes";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(31, 469);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(157, 24);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "O usar contraseña";
            // 
            // tBoxPassword
            // 
            tBoxPassword.Location = new Point(31, 498);
            tBoxPassword.Margin = new Padding(4, 5, 4, 5);
            tBoxPassword.Name = "tBoxPassword";
            tBoxPassword.PlaceholderText = "******";
            tBoxPassword.Size = new Size(268, 29);
            tBoxPassword.TabIndex = 5;
            tBoxPassword.UseSystemPasswordChar = true;
            tBoxPassword.KeyPress += tBoxPassword_KeyPress;
            // 
            // btnPassword
            // 
            btnPassword.Location = new Point(310, 490);
            btnPassword.Margin = new Padding(4, 5, 4, 5);
            btnPassword.Name = "btnPassword";
            btnPassword.Size = new Size(107, 41);
            btnPassword.TabIndex = 6;
            btnPassword.Text = "Entrar";
            btnPassword.UseVisualStyleBackColor = true;
            btnPassword.Click += btnPassword_Click;
            // 
            // Fingerprint
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 559);
            Controls.Add(btnPassword);
            Controls.Add(tBoxPassword);
            Controls.Add(lblPassword);
            Controls.Add(StatusLine);
            Controls.Add(Status);
            Controls.Add(Picture);
            Controls.Add(Prompt);
            Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Fingerprint";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fingerprint";
            FormClosed += Fingerprint_FormClosed;
            Load += Fingerprint_Load;
            ((System.ComponentModel.ISupportInitialize)Picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Prompt;
        private PictureBox Picture;
        private TextBox Status;
        private Label StatusLine;
        public Label lblPassword;
        public TextBox tBoxPassword;
        public Button btnPassword;
    }
}