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

            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.MediumSlateBlue;
            this.Text = "Căutare Zboruri";
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
