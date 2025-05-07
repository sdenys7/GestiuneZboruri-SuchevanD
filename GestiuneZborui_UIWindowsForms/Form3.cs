using GestiuneZboruri;
using NivelStocareDate;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GestiuneZborui_UIWindowsForms
{
    public partial class Form3 : Form
    {
        private AdministrareZboruri_FisierText gestiuneZboruri;

        public Form3()
        {
            InitializeComponent();
            string numeFisierZboruri = ConfigurationManager.AppSettings["numeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierZboruri = Path.Combine(locatieFisierSolutie, numeFisierZboruri);

            gestiuneZboruri = new AdministrareZboruri_FisierText(caleCompletaFisierZboruri);

            // Modern Monaco-inspired design
            this.Size = new Size(800, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(26, 27, 46); // Dark navy blue
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(232, 232, 232); // Light gray
            this.Text = "Search Flights";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Style all controls
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = Color.FromArgb(0, 180, 216); // Teal
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    button.Size = new Size(120, 35);
                    button.Cursor = Cursors.Hand;
                }
                else if (control is TextBox)
                {
                    control.BackColor = Color.FromArgb(45, 45, 65);
                    control.ForeColor = Color.FromArgb(232, 232, 232);
                    control.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
                else if (control is Label)
                {
                    control.ForeColor = Color.FromArgb(232, 232, 232);
                    control.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            }
        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            string idZborText = txtIdZbor.Text.Trim();

            if (string.IsNullOrWhiteSpace(idZborText) || !int.TryParse(idZborText, out int idZbor))
            {
                MessageBox.Show("Introduceți un ID valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Zbor zborGasit = gestiuneZboruri.GetZbor(idZbor);

            if (zborGasit != null)
            {
                MessageBox.Show($"Zbor găsit:\n\n" +
                                $"ID Zbor: {zborGasit.IDZbor}\n" +
                                $"Companie Aeriană: {zborGasit.CompanieAeriana}\n" +
                                $"Aeroport Plecare: {zborGasit.AeroportPlecare}\n" +
                                $"Aeroport Sosire: {zborGasit.AeroportSosire}\n" +
                                $"Data Plecare: {zborGasit.DataPlecare:dd.MM.yyyy HH:mm}\n" +
                                $"Data Sosire: {zborGasit.DataSosire:dd.MM.yyyy HH:mm}\n" +
                                $"Tip Avion: {zborGasit.TipAvion}",
                                "Zbor găsit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Zborul cu ID-ul specificat nu a fost găsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
