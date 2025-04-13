namespace GestiuneZborui_UIWindowsForms
{
    partial class Form1
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
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.lblIdZbor = new System.Windows.Forms.Label();
            this.lblCompanieAeriana = new System.Windows.Forms.Label();
            this.lblAeroportPlecare = new System.Windows.Forms.Label();
            this.buttonCautare = new System.Windows.Forms.Button();
            this.lblAeroportSosire = new System.Windows.Forms.Label();
            this.lblDataPlecare = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.Location = new System.Drawing.Point(12, 117);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(75, 23);
            this.buttonAdauga.TabIndex = 0;
            this.buttonAdauga.Text = "Adauga";
            this.buttonAdauga.UseVisualStyleBackColor = true;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(12, 177);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // lblIdZbor
            // 
            this.lblIdZbor.AutoSize = true;
            this.lblIdZbor.Location = new System.Drawing.Point(158, 76);
            this.lblIdZbor.Name = "lblIdZbor";
            this.lblIdZbor.Size = new System.Drawing.Size(46, 16);
            this.lblIdZbor.TabIndex = 2;
            this.lblIdZbor.Text = "IdZbor";
            // 
            // lblCompanieAeriana
            // 
            this.lblCompanieAeriana.AutoSize = true;
            this.lblCompanieAeriana.Location = new System.Drawing.Point(338, 76);
            this.lblCompanieAeriana.Name = "lblCompanieAeriana";
            this.lblCompanieAeriana.Size = new System.Drawing.Size(119, 16);
            this.lblCompanieAeriana.TabIndex = 3;
            this.lblCompanieAeriana.Text = "Companie Aeriana";
            // 
            // lblAeroportPlecare
            // 
            this.lblAeroportPlecare.AutoSize = true;
            this.lblAeroportPlecare.Location = new System.Drawing.Point(535, 76);
            this.lblAeroportPlecare.Name = "lblAeroportPlecare";
            this.lblAeroportPlecare.Size = new System.Drawing.Size(109, 16);
            this.lblAeroportPlecare.TabIndex = 4;
            this.lblAeroportPlecare.Text = "Aeroport Plecare";
            // 
            // buttonCautare
            // 
            this.buttonCautare.Location = new System.Drawing.Point(12, 232);
            this.buttonCautare.Name = "buttonCautare";
            this.buttonCautare.Size = new System.Drawing.Size(75, 23);
            this.buttonCautare.TabIndex = 5;
            this.buttonCautare.Text = "Cautare";
            this.buttonCautare.UseVisualStyleBackColor = true;
            this.buttonCautare.Click += new System.EventHandler(this.buttonCautare_Click);
            // 
            // lblAeroportSosire
            // 
            this.lblAeroportSosire.AutoSize = true;
            this.lblAeroportSosire.Location = new System.Drawing.Point(676, 76);
            this.lblAeroportSosire.Name = "lblAeroportSosire";
            this.lblAeroportSosire.Size = new System.Drawing.Size(101, 16);
            this.lblAeroportSosire.TabIndex = 6;
            this.lblAeroportSosire.Text = "Aeroport Sosire";
            // 
            // lblDataPlecare
            // 
            this.lblDataPlecare.AutoSize = true;
            this.lblDataPlecare.Location = new System.Drawing.Point(835, 76);
            this.lblDataPlecare.Name = "lblDataPlecare";
            this.lblDataPlecare.Size = new System.Drawing.Size(86, 16);
            this.lblDataPlecare.TabIndex = 7;
            this.lblDataPlecare.Text = "Data Plecare";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1085, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data Sosire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1230, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID Zbor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 595);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDataPlecare);
            this.Controls.Add(this.lblAeroportSosire);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.lblAeroportPlecare);
            this.Controls.Add(this.lblCompanieAeriana);
            this.Controls.Add(this.lblIdZbor);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAdauga);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label lblIdZbor;
        private System.Windows.Forms.Label lblCompanieAeriana;
        private System.Windows.Forms.Label lblAeroportPlecare;
        private System.Windows.Forms.Button buttonCautare;
        private System.Windows.Forms.Label lblAeroportSosire;
        private System.Windows.Forms.Label lblDataPlecare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

