using GestiuneZboruri;
using LibrarieZboruri;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelStocareDate;
using LibrarieZboruri;
using System.Configuration;
using System.IO;

namespace GestiuneZborui_UIWindowsForms
{
    public partial class Form2: Form
    {
        private AdministrareZboruri_FisierText gestiuneZboruri;

        private const int NR_MAX_CARACTERE = 50;
        public Form2()
        {
            InitializeComponent();

            cmbTipAvion.Items.AddRange(Enum.GetNames(typeof(TipAvion)));

            string numeFisierZboruri = ConfigurationManager.AppSettings["numeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierZboruri = Path.Combine(locatieFisierSolutie, numeFisierZboruri);

            gestiuneZboruri = new AdministrareZboruri_FisierText(caleCompletaFisierZboruri);

            // Modern Monaco-inspired design
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(26, 27, 46); // Dark navy blue
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(232, 232, 232); // Light gray
            this.Text = "Add New Flight";
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
                else if (control is TextBox || control is ComboBox)
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


        private void buttonSalvare_Click(object sender, EventArgs e)
        {
            eroareIdZbor.Text = "";
            eroareCompanieAeriana.Text = "";
            eroareAeroportPlecare.Text = "";
            eroareAeroportSosire.Text = "";
            eroareDataPlecare.Text = "";
            eroareDataSosire.Text = "";
            eroareTipAvion.Text = "";

            if (gestiuneZboruri == null)
            {
                MessageBox.Show("Eroare: Obiectul gestiuneZboruri nu a fost inițializat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Prevalidare() && !Validare())
            {
                int idZbor = int.Parse(txtIdZbor.Text);
                string companieAeriana = txtCompanieAeriana.Text;
                string aeroportPlecare = txtAeroportPlecare.Text;
                string aeroportSosire = txtAeroportSosire.Text;
                DateTime dataPlecare = DateTime.ParseExact(txtDataPlecare.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                DateTime dataSosire = DateTime.ParseExact(txtDataSosire.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

                if (cmbTipAvion.SelectedItem == null)
                {
                    eroareTipAvion.Text = "Selectați un tip de avion!";
                    return;
                }

                TipAvion tipAvion = (TipAvion)Enum.Parse(typeof(TipAvion), cmbTipAvion.SelectedItem.ToString());

                // Citire RadioButton și CheckBox
                string tipZbor = radioIntern.Checked ? "Intern" : (radioExtern.Checked ? "Extern" : "Nespecificat");
                bool zborDirect = checkBoxZborDirect.Checked;

                Zbor zbor = new Zbor(idZbor, companieAeriana, aeroportPlecare, aeroportSosire, dataPlecare, dataSosire, tipZbor, zborDirect)
                {
                    TipAvion = tipAvion
                };
                gestiuneZboruri.AddZbor(zbor);

                MessageBox.Show($"Zborul a fost adăugat cu succes!\nTip zbor: {tipZbor}\nZbor direct: {(zborDirect ? "Da" : "Nu")}");
            }
        }


        public bool Prevalidare()
        {
            if (string.IsNullOrWhiteSpace(txtIdZbor.Text))
            {
                eroareIdZbor.Text = "Nu poate fi gol!";
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtCompanieAeriana.Text))
            {
                eroareCompanieAeriana.Text = "Nu poate fi gol!";
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtAeroportPlecare.Text))
            {
                eroareAeroportPlecare.Text = "Nu poate fi gol!";
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtAeroportSosire.Text))
            {
                eroareAeroportSosire.Text = "Nu poate fi gol!";
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDataPlecare.Text))
            {
                eroareDataPlecare.Text = "Nu poate fi gol!";
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDataSosire.Text))
            {
                eroareDataSosire.Text = "Nu poate fi gol!";
                return true;
            }

            if (cmbTipAvion.SelectedItem == null)
            {
                eroareTipAvion.Text = "Selectați un tip de avion!";
                return true;
            }

            return false;
        }

        public bool Validare()
        {
            if (!int.TryParse(txtIdZbor.Text, out _))
            {
                eroareIdZbor.Text = "Trebuie să fie un număr întreg!";
                return true;
            }

            if (txtCompanieAeriana.Text.Length > NR_MAX_CARACTERE)
            {
                eroareCompanieAeriana.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                return true;
            }

            if (txtAeroportPlecare.Text.Length > NR_MAX_CARACTERE)
            {
                eroareAeroportPlecare.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                return true;
            }

            if (txtAeroportSosire.Text.Length > NR_MAX_CARACTERE)
            {
                eroareAeroportSosire.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                return true;
            }

            if (!DateTime.TryParseExact(txtDataPlecare.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                eroareDataPlecare.Text = "Format invalid! (dd.MM.yyyy HH:mm)";
                return true;
            }

            if (!DateTime.TryParseExact(txtDataSosire.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                eroareDataSosire.Text = "Format invalid! (dd.MM.yyyy HH:mm)";
                return true;
            }

            return false;
        }

        private void cmbTipAvion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
