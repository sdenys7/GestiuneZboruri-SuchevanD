using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestiuneZboruri;
using LibrarieZboruri;
using NivelStocareDate;

namespace GestiuneZborui_UIWindowsForms
{
    public partial class Form1 : Form
    {
        private AdministrareZboruri_FisierText gestiuneZboruri;

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaZboruri();
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 40;
        private const int DIMENSIUNE_PAS_X = 160;

        public Form1()
        {
            InitializeComponent();

            string numeFisierZboruri = ConfigurationManager.AppSettings["numeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierZboruri = Path.Combine(locatieFisierSolutie, numeFisierZboruri);

            gestiuneZboruri = new AdministrareZboruri_FisierText(caleCompletaFisierZboruri);

            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(58, 61, 70);
            this.Text = "Monaco Airport - Flight Management System";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            foreach (Control control in this.Controls)
            {
                if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.GridColor = Color.FromArgb(230, 236, 240);
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.FromArgb(58, 61, 70);
                    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(246, 250, 252);
                    dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(58, 61, 70);
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 250, 252);
                    dgv.RowTemplate.Height = 40;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(58, 61, 70);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToResizeRows = false;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.MultiSelect = false;
                    dgv.ReadOnly = true;
                }
                else if (control is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(33, 150, 243);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    btn.Size = new Size(120, 36);
                    btn.Cursor = Cursors.Hand;
                    btn.Region = System.Drawing.Region.FromHrgn(
                        NativeMethods.CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 16, 16));
                }
            }

            this.Load += Form1_Load;

            // Populez ComboBox cu companii distincte
            PopuleazaComboBoxCompanie();
            comboBoxCompanie.SelectedIndexChanged += ComboBoxCompanie_SelectedIndexChanged;
        }

        private void PopuleazaComboBoxCompanie()
        {
            var zboruri = gestiuneZboruri.GetZboruri();
            var companii = zboruri.Select(z => z.CompanieAeriana).Distinct().OrderBy(c => c).ToList();
            companii.Insert(0, "Toate");
            comboBoxCompanie.DataSource = companii;
        }

        private void ComboBoxCompanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var zboruri = gestiuneZboruri.GetZboruri();
            string companieSelectata = comboBoxCompanie.SelectedItem.ToString();
            if (companieSelectata != "Toate")
            {
                zboruri = zboruri.Where(z => z.CompanieAeriana == companieSelectata).ToList();
            }
            AfiseazaDataGrid(zboruri);
        }

        private void AfiseazaZboruri()
        {
            List<Zbor> zboruri = gestiuneZboruri.GetZboruri();
            int nrZboruri = zboruri.Count;
            if (zboruri == null || nrZboruri == 0)
            {
                MessageBox.Show("Nu există zboruri de afișat.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int i = 0;
            foreach (Zbor zbor in zboruri)
            {
                if (zbor == null) continue;

                Label lblId = new Label { Text = zbor.IDZbor.ToString(), Width = LATIME_CONTROL, Left = DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };
                Label lblCompanie = new Label { Text = zbor.CompanieAeriana, Width = LATIME_CONTROL, Left = 2 * DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };
                Label lblPlecare = new Label { Text = zbor.AeroportPlecare, Width = LATIME_CONTROL, Left = 3 * DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };
                Label lblSosire = new Label { Text = zbor.AeroportSosire, Width = LATIME_CONTROL, Left = 4 * DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };
                Label lblDataPlecare = new Label { Text = zbor.DataPlecare.ToString("dd.MM.yyyy HH:mm"), Width = LATIME_CONTROL, Left = 5 * DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };
                Label lblDataSosire = new Label { Text = zbor.DataSosire.ToString("dd.MM.yyyy HH:mm"), Width = LATIME_CONTROL, Left = 6 * DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };
                Label lblTipAvion = new Label { Text = zbor.TipAvion.ToString(), Width = LATIME_CONTROL, Left = 7 * DIMENSIUNE_PAS_X, Top = (i + 3) * DIMENSIUNE_PAS_Y };

                this.Controls.Add(lblId);
                this.Controls.Add(lblCompanie);
                this.Controls.Add(lblPlecare);
                this.Controls.Add(lblSosire);
                this.Controls.Add(lblDataPlecare);
                this.Controls.Add(lblDataSosire);
                this.Controls.Add(lblTipAvion);

                i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Zbor> zboruri = gestiuneZboruri.GetZboruri();
            AfiseazaDataGrid(zboruri);
        }

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        public void AfiseazaDataGrid(List<Zbor> zboruri)
        {
            dataGridAfisare.DataSource = null;
            dataGridAfisare.DataSource = zboruri.Select(s => new {
                s.IDZbor,
                s.CompanieAeriana,
                s.AeroportPlecare,
                s.AeroportSosire,
                s.DataPlecare,
                s.DataSosire,
                s.TipAvion,
                s.TipZbor,
                ZborDirect = s.ZborDirect ? "Da" : "Nu"
            }).ToList();
            dataGridAfisare.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }

    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
