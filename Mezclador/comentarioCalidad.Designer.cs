namespace Mezclador
{
    partial class comentarioCalidad
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Franklin Gothic Medium", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(22, 78);
            textBox1.Margin = new Padding(4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(436, 153);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(148, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(185, 21);
            label1.TabIndex = 1;
            label1.Text = "Introduzca un comentario";
            // 
            // button1
            // 
            button1.Location = new Point(183, 255);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(114, 60);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comentarioCalidad
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 333);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "comentarioCalidad";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Comentario Calidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
    }
}