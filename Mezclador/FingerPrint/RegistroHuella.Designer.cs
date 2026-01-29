namespace Mezclador
{
    partial class RegistroHuella
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
			SuspendLayout();
			// 
			// lblPassword
			// 
			lblPassword.Location = new Point(28, 410);
			lblPassword.Margin = new Padding(4, 0, 4, 0);
			lblPassword.Size = new Size(134, 21);
			// 
			// tBoxPassword
			// 
			tBoxPassword.Location = new Point(28, 436);
			tBoxPassword.Margin = new Padding(4, 4, 4, 4);
			tBoxPassword.Size = new Size(242, 26);
			// 
			// btnPassword
			// 
			btnPassword.Location = new Point(279, 429);
			btnPassword.Margin = new Padding(4, 4, 4, 4);
			btnPassword.Size = new Size(96, 36);
			// 
			// RegistroHuella
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(406, 410);
			Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Margin = new Padding(4, 4, 4, 4);
			Name = "RegistroHuella";
			Text = "RegistroHuella";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
	}
}