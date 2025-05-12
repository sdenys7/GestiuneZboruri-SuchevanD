using GestiuneZboruri;
using NivelStocareDate;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
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
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(25, 25, 112); // Dark blue text
            this.Text = "Chernivtsy-Airport - Cauta Zboruri";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Style all controls
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.BackColor = Color.FromArgb(25, 25, 112); // Dark blue
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.FromArgb(220, 20, 60); // Crimson
                    button.FlatAppearance.BorderSize = 1;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    button.Size = new Size(120, 35);
                    button.Cursor = Cursors.Hand;
                }
                else if (control is TextBox)
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.FromArgb(25, 25, 112);
                    control.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
                else if (control is Label)
                {
                    control.ForeColor = Color.FromArgb(25, 25, 112);
                    control.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            }
        }

        private void buttonCauta_Click(object sender, EventArgs e)
        {
            string idZborText = txtIdZbor.Text.Trim();

            if (string.IsNullOrWhiteSpace(idZborText) || !int.TryParse(idZborText, out int idZbor))
            {
                MessageBox.Show("Introduceti un ID valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Zbor zborGasit = gestiuneZboruri.GetZbor(idZbor);

            if (zborGasit != null)
            {
                // Find Form1 instance and highlight the flight
                Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.HighlightFlight(idZbor);
                    mainForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Zborul cu ID-ul specificat nu a fost gasit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
