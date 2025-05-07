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
            this.buttonCautare = new System.Windows.Forms.Button();
            this.dataGridAfisare = new System.Windows.Forms.DataGridView();
            this.comboBoxCompanie = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAfisare)).BeginInit();
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
            // dataGridAfisare
            // 
            this.dataGridAfisare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAfisare.Location = new System.Drawing.Point(168, 12);
            this.dataGridAfisare.Name = "dataGridAfisare";
            this.dataGridAfisare.RowHeadersWidth = 80;
            this.dataGridAfisare.RowTemplate.Height = 40;
            this.dataGridAfisare.Size = new System.Drawing.Size(1634, 571);
            this.dataGridAfisare.TabIndex = 10;
            // 
            // comboBoxCompanie
            // 
            this.comboBoxCompanie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompanie.FormattingEnabled = true;
            this.comboBoxCompanie.Location = new System.Drawing.Point(12, 300);
            this.comboBoxCompanie.Name = "comboBoxCompanie";
            this.comboBoxCompanie.Size = new System.Drawing.Size(140, 24);
            this.comboBoxCompanie.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 595);
            this.Controls.Add(this.comboBoxCompanie);
            this.Controls.Add(this.dataGridAfisare);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAdauga);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAfisare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonCautare;
        private System.Windows.Forms.DataGridView dataGridAfisare;
        private System.Windows.Forms.ComboBox comboBoxCompanie;
    }
}

