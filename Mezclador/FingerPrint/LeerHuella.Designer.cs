namespace Mezclador
{
    partial class LeerHuella
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeerHuella));
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(28, 464);
            lblPassword.Size = new Size(134, 21);
            // 
            // tBoxPassword
            // 
            tBoxPassword.Location = new Point(28, 494);
            tBoxPassword.Margin = new Padding(4);
            tBoxPassword.Size = new Size(242, 26);
            // 
            // btnPassword
            // 
            btnPassword.Location = new Point(239, 485);
            btnPassword.Margin = new Padding(4);
            btnPassword.Size = new Size(96, 41);
            btnPassword.Click += btnPassword_Click;
            // 
            // LeerHuella
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 544);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "LeerHuella";
            ShowIcon = true;
            Text = "LeerHuella";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}