namespace Mezclador
{
    partial class Header
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            panelMenu = new Panel();
            btnLogin = new Button();
            panel1 = new Panel();
            txtPermiso = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblLogout = new Label();
            lblUsuario = new TextBox();
            btnCalidad = new Button();
            btnProduccion = new Button();
            btnUsers = new Button();
            btnPrincipal = new Button();
            btnConfig = new Button();
            btnEditProducts = new Button();
            btnEditRecipes = new Button();
            panelForms = new Panel();
            panelMenuUser = new Panel();
            btnSignin = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panelTitle = new Panel();
            btnMinimize = new Button();
            btnClose = new Button();
            lblVC = new PictureBox();
            pictureBox2 = new PictureBox();
            TmrEmail = new System.Windows.Forms.Timer(components);
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelMenuUser.SuspendLayout();
            panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lblVC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(35, 82, 172);
            panelMenu.Controls.Add(btnLogin);
            panelMenu.Controls.Add(panel1);
            panelMenu.Controls.Add(btnCalidad);
            panelMenu.Controls.Add(btnProduccion);
            panelMenu.Controls.Add(btnUsers);
            panelMenu.Controls.Add(btnPrincipal);
            panelMenu.Controls.Add(btnConfig);
            panelMenu.Controls.Add(btnEditProducts);
            panelMenu.Controls.Add(btnEditRecipes);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Font = new Font("Franklin Gothic Medium", 10F, FontStyle.Regular, GraphicsUnit.Point);
            panelMenu.Location = new Point(0, 38);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(173, 1023);
            panelMenu.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(21, 667);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(131, 59);
            btnLogin.TabIndex = 23;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 82, 172);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(txtPermiso);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblLogout);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 728);
            panel1.Name = "panel1";
            panel1.Size = new Size(174, 295);
            panel1.TabIndex = 28;
            // 
            // txtPermiso
            // 
            txtPermiso.BackColor = Color.FromArgb(35, 82, 172);
            txtPermiso.BorderStyle = BorderStyle.None;
            txtPermiso.Font = new Font("Franklin Gothic Medium", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtPermiso.ForeColor = Color.Yellow;
            txtPermiso.Location = new Point(1, 68);
            txtPermiso.Multiline = true;
            txtPermiso.Name = "txtPermiso";
            txtPermiso.Size = new Size(170, 37);
            txtPermiso.TabIndex = 28;
            txtPermiso.Text = "Administrador";
            txtPermiso.TextAlign = HorizontalAlignment.Center;
            txtPermiso.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BtnConfig;
            pictureBox1.Location = new Point(11, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(45, 28);
            label1.Name = "label1";
            label1.Size = new Size(71, 24);
            label1.TabIndex = 25;
            label1.Text = "Usuario";
            // 
            // lblLogout
            // 
            lblLogout.AccessibleRole = AccessibleRole.None;
            lblLogout.Cursor = Cursors.Hand;
            lblLogout.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Underline, GraphicsUnit.Point);
            lblLogout.ForeColor = Color.Salmon;
            lblLogout.Location = new Point(6, 236);
            lblLogout.Name = "lblLogout";
            lblLogout.Size = new Size(160, 57);
            lblLogout.TabIndex = 23;
            lblLogout.Text = "Cerrar Sesión";
            lblLogout.TextAlign = ContentAlignment.MiddleCenter;
            lblLogout.Click += lblLogout_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.BackColor = Color.FromArgb(35, 82, 172);
            lblUsuario.BorderStyle = BorderStyle.None;
            lblUsuario.Font = new Font("Franklin Gothic Medium", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.ForeColor = Color.Yellow;
            lblUsuario.Location = new Point(3, 105);
            lblUsuario.Multiline = true;
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(166, 135);
            lblUsuario.TabIndex = 27;
            lblUsuario.Text = "Adrian Alberto Olivares Hernandez";
            lblUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCalidad
            // 
            btnCalidad.Cursor = Cursors.Hand;
            btnCalidad.FlatAppearance.BorderSize = 0;
            btnCalidad.FlatStyle = FlatStyle.Flat;
            btnCalidad.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalidad.ForeColor = Color.White;
            btnCalidad.Location = new Point(0, 346);
            btnCalidad.Margin = new Padding(4, 3, 4, 3);
            btnCalidad.Name = "btnCalidad";
            btnCalidad.Size = new Size(173, 59);
            btnCalidad.TabIndex = 27;
            btnCalidad.Text = "Calidad";
            btnCalidad.UseVisualStyleBackColor = true;
            // 
            // btnProduccion
            // 
            btnProduccion.Cursor = Cursors.Hand;
            btnProduccion.FlatAppearance.BorderSize = 0;
            btnProduccion.FlatStyle = FlatStyle.Flat;
            btnProduccion.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnProduccion.ForeColor = Color.White;
            btnProduccion.Location = new Point(0, 281);
            btnProduccion.Margin = new Padding(4, 3, 4, 3);
            btnProduccion.Name = "btnProduccion";
            btnProduccion.Size = new Size(173, 59);
            btnProduccion.TabIndex = 24;
            btnProduccion.Text = "Producción";
            btnProduccion.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsers.ForeColor = Color.White;
            btnUsers.Location = new Point(0, 86);
            btnUsers.Margin = new Padding(4, 3, 4, 3);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(173, 59);
            btnUsers.TabIndex = 8;
            btnUsers.Text = "Usuarios";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnPrincipal
            // 
            btnPrincipal.Cursor = Cursors.Hand;
            btnPrincipal.FlatAppearance.BorderSize = 0;
            btnPrincipal.FlatStyle = FlatStyle.Flat;
            btnPrincipal.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrincipal.ForeColor = Color.White;
            btnPrincipal.Location = new Point(0, 21);
            btnPrincipal.Margin = new Padding(4, 3, 4, 3);
            btnPrincipal.Name = "btnPrincipal";
            btnPrincipal.Size = new Size(173, 59);
            btnPrincipal.TabIndex = 7;
            btnPrincipal.Text = "Principal";
            btnPrincipal.UseVisualStyleBackColor = true;
            // 
            // btnConfig
            // 
            btnConfig.Cursor = Cursors.Hand;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfig.ForeColor = Color.White;
            btnConfig.Location = new Point(0, 411);
            btnConfig.Margin = new Padding(4, 3, 4, 3);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(173, 59);
            btnConfig.TabIndex = 6;
            btnConfig.Text = "Configuración";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnEditProducts
            // 
            btnEditProducts.Cursor = Cursors.Hand;
            btnEditProducts.FlatAppearance.BorderSize = 0;
            btnEditProducts.FlatStyle = FlatStyle.Flat;
            btnEditProducts.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditProducts.ForeColor = Color.White;
            btnEditProducts.Location = new Point(0, 216);
            btnEditProducts.Margin = new Padding(4, 3, 4, 3);
            btnEditProducts.Name = "btnEditProducts";
            btnEditProducts.Size = new Size(173, 59);
            btnEditProducts.TabIndex = 5;
            btnEditProducts.Text = "Materiales";
            btnEditProducts.UseVisualStyleBackColor = true;
            // 
            // btnEditRecipes
            // 
            btnEditRecipes.Cursor = Cursors.Hand;
            btnEditRecipes.FlatAppearance.BorderSize = 0;
            btnEditRecipes.FlatStyle = FlatStyle.Flat;
            btnEditRecipes.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditRecipes.ForeColor = Color.White;
            btnEditRecipes.Location = new Point(0, 151);
            btnEditRecipes.Margin = new Padding(4, 3, 4, 3);
            btnEditRecipes.Name = "btnEditRecipes";
            btnEditRecipes.Size = new Size(173, 59);
            btnEditRecipes.TabIndex = 4;
            btnEditRecipes.Text = "Recetas";
            btnEditRecipes.UseVisualStyleBackColor = true;
            btnEditRecipes.Click += btnEditRecipes_Click;
            // 
            // panelForms
            // 
            panelForms.BackColor = SystemColors.HighlightText;
            panelForms.Dock = DockStyle.Fill;
            panelForms.Font = new Font("Franklin Gothic Medium", 10F, FontStyle.Regular, GraphicsUnit.Point);
            panelForms.Location = new Point(173, 38);
            panelForms.MinimumSize = new Size(1061, 658);
            panelForms.Name = "panelForms";
            panelForms.Size = new Size(1747, 1023);
            panelForms.TabIndex = 1;
            // 
            // panelMenuUser
            // 
            panelMenuUser.BackColor = Color.FromArgb(35, 82, 172);
            panelMenuUser.Controls.Add(btnSignin);
            panelMenuUser.Location = new Point(173, 121);
            panelMenuUser.Name = "panelMenuUser";
            panelMenuUser.Size = new Size(182, 139);
            panelMenuUser.TabIndex = 0;
            panelMenuUser.Visible = false;
            panelMenuUser.VisibleChanged += panlMenuUser_VisibleChanged;
            // 
            // btnSignin
            // 
            btnSignin.Cursor = Cursors.Hand;
            btnSignin.FlatAppearance.BorderSize = 0;
            btnSignin.FlatStyle = FlatStyle.Flat;
            btnSignin.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignin.ForeColor = Color.White;
            btnSignin.Location = new Point(4, 73);
            btnSignin.Margin = new Padding(5);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(173, 59);
            btnSignin.TabIndex = 24;
            btnSignin.Text = "Registrar usuario";
            btnSignin.UseVisualStyleBackColor = true;
            btnSignin.Click += btnSignin_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 300;
            timer1.Tick += timer1_Tick;
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(btnMinimize);
            panelTitle.Controls.Add(btnClose);
            panelTitle.Controls.Add(lblVC);
            panelTitle.Controls.Add(pictureBox2);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1920, 38);
            panelTitle.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnMinimize.Location = new Point(1785, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(59, 38);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "―";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.Location = new Point(1849, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(59, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblVC
            // 
            lblVC.Image = Properties.Resources.VC;
            lblVC.Location = new Point(130, 0);
            lblVC.Name = "lblVC";
            lblVC.Size = new Size(140, 35);
            lblVC.SizeMode = PictureBoxSizeMode.Zoom;
            lblVC.TabIndex = 1;
            lblVC.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.comaflex;
            pictureBox2.Location = new Point(7, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(131, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // TmrEmail
            // 
            TmrEmail.Interval = 1000;
            TmrEmail.Tick += TmrEmail_Tick;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1920, 1061);
            Controls.Add(panelMenuUser);
            Controls.Add(panelForms);
            Controls.Add(panelMenu);
            Controls.Add(panelTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Header";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comaflex - VC Coatings";
            WindowState = FormWindowState.Maximized;
            FormClosing += Header_FormClosing;
            Load += Header_Load;
            Shown += Header_Shown;
            Click += Header_Click;
            MouseClick += Header_MouseClick;
            MouseDown += Header_MouseDown;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelMenuUser.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lblVC).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnConfig;
        private Button btnEditProducts;
        private Button btnEditRecipes;
        private Panel panelForms;
        private Button btnPrincipal;
        private Button btnUsers;
        private Label lblPermisost;
        private System.Windows.Forms.Timer timer1;
        private Button btnLogin;
        private Panel panelMenuUser;
        private Button btnSignin;
        private Label lblLogout;
        private Button btnProduccion;
		private PictureBox pictureBox1;
		private Label label1;
		private Button btnCalidad;
		private Panel panelTitle;
		private PictureBox pictureBox2;
		private PictureBox lblVC;
		private Button btnClose;
		private Button btnMinimize;
		private Panel panel1;
        private System.Windows.Forms.Timer TmrEmail;
        private TextBox lblUsuario;
        private TextBox txtPermiso;
    }
}