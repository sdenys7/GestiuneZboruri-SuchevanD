namespace GestiuneZborui_UIWindowsForms
{
    partial class Form3
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
            this.lblIdZbor = new System.Windows.Forms.Label();
            this.txtIdZbor = new System.Windows.Forms.TextBox();
            this.buttonCauta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIdZbor
            // 
            this.lblIdZbor.AutoSize = true;
            this.lblIdZbor.Location = new System.Drawing.Point(137, 150);
            this.lblIdZbor.Name = "lblIdZbor";
            this.lblIdZbor.Size = new System.Drawing.Size(46, 16);
            this.lblIdZbor.TabIndex = 0;
            this.lblIdZbor.Text = "IdZbor";
            // 
            // txtIdZbor
            // 
            this.txtIdZbor.Location = new System.Drawing.Point(217, 144);
            this.txtIdZbor.Name = "txtIdZbor";
            this.txtIdZbor.Size = new System.Drawing.Size(100, 22);
            this.txtIdZbor.TabIndex = 1;
            // 
            // buttonCauta
            // 
            this.buttonCauta.Location = new System.Drawing.Point(178, 188);
            this.buttonCauta.Name = "buttonCauta";
            this.buttonCauta.Size = new System.Drawing.Size(75, 23);
            this.buttonCauta.TabIndex = 2;
            this.buttonCauta.Text = "Cauta";
            this.buttonCauta.UseVisualStyleBackColor = true;
            this.buttonCauta.Click += new System.EventHandler(this.buttonCauta_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCauta);
            this.Controls.Add(this.txtIdZbor);
            this.Controls.Add(this.lblIdZbor);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdZbor;
        private System.Windows.Forms.TextBox txtIdZbor;
        private System.Windows.Forms.Button buttonCauta;
    }
}