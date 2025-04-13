using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
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

        private const int NR_MAX_CARACTERE = 50;

        private Label lblIdZbor, lblCompanieAeriana, lblAeroportPlecare, lblAeroportSosire, lblDataPlecare, lblDataSosire, lblTipAvion;
        private Label eroareIdZbor, eroareCompanieAeriana, eroareAeroportPlecare, eroareAeroportSosire, eroareDataPlecare, eroareDataSosire, eroareTipAvion;
        private TextBox txtIdZbor, txtCompanieAeriana, txtAeroportPlecare, txtAeroportSosire, txtDataPlecare, txtDataSosire;
        private ComboBox cmbTipAvion;
        private Button buttonAdaugaZbor, buttonRefreshZboruri;

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

            // Setare proprietăți formular
            this.Size = new Size(1200, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.FromArgb(0, 112, 116);
            this.Text = "Gestiune Zboruri";

            // Adăugare controale pentru fiecare proprietate
            AdaugaControale();

            // Adăugare butoane
            buttonAdaugaZbor = new Button
            {
                Text = "Adaugă Zbor",
                Width = LATIME_CONTROL,
                Location = new Point(0, DIMENSIUNE_PAS_Y)
            };
            buttonAdaugaZbor.Click += OnButtonAdaugaZborClicked;
            this.Controls.Add(buttonAdaugaZbor);

            buttonRefreshZboruri = new Button
            {
                Text = "Refresh Zboruri",
                Width = LATIME_CONTROL,
                Location = new Point(0, 2 * DIMENSIUNE_PAS_Y)
            };
            buttonRefreshZboruri.Click += OnButtonRefreshZboruriClicked;
            this.Controls.Add(buttonRefreshZboruri);

            this.Load += Form1_Load;
        }

        private void AdaugaControale()
        {
            // ID Zbor
            lblIdZbor = new Label { Text = "ID Zbor", Width = LATIME_CONTROL, Left = DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            txtIdZbor = new TextBox { Width = LATIME_CONTROL, Left = DIMENSIUNE_PAS_X, Top = DIMENSIUNE_PAS_Y };
            eroareIdZbor = new Label { Width = LATIME_CONTROL, Left = DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblIdZbor);
            this.Controls.Add(txtIdZbor);
            this.Controls.Add(eroareIdZbor);

            // Companie Aeriană
            lblCompanieAeriana = new Label { Text = "Companie Aeriană", Width = LATIME_CONTROL, Left = 2 * DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            txtCompanieAeriana = new TextBox { Width = LATIME_CONTROL, Left = 2 * DIMENSIUNE_PAS_X, Top = DIMENSIUNE_PAS_Y };
            eroareCompanieAeriana = new Label { Width = LATIME_CONTROL, Left = 2 * DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblCompanieAeriana);
            this.Controls.Add(txtCompanieAeriana);
            this.Controls.Add(eroareCompanieAeriana);

            // Aeroport Plecare
            lblAeroportPlecare = new Label { Text = "Aeroport Plecare", Width = LATIME_CONTROL, Left = 3 * DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            txtAeroportPlecare = new TextBox { Width = LATIME_CONTROL, Left = 3 * DIMENSIUNE_PAS_X, Top = DIMENSIUNE_PAS_Y };
            eroareAeroportPlecare = new Label { Width = LATIME_CONTROL, Left = 3 * DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblAeroportPlecare);
            this.Controls.Add(txtAeroportPlecare);
            this.Controls.Add(eroareAeroportPlecare);

            // Aeroport Sosire
            lblAeroportSosire = new Label { Text = "Aeroport Sosire", Width = LATIME_CONTROL, Left = 4 * DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            txtAeroportSosire = new TextBox { Width = LATIME_CONTROL, Left = 4 * DIMENSIUNE_PAS_X, Top = DIMENSIUNE_PAS_Y };
            eroareAeroportSosire = new Label { Width = LATIME_CONTROL, Left = 4 * DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblAeroportSosire);
            this.Controls.Add(txtAeroportSosire);
            this.Controls.Add(eroareAeroportSosire);

            // Data Plecare
            lblDataPlecare = new Label { Text = "Data Plecare", Width = LATIME_CONTROL, Left = 5 * DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            txtDataPlecare = new TextBox { Width = LATIME_CONTROL, Left = 5 * DIMENSIUNE_PAS_X, Top = DIMENSIUNE_PAS_Y };
            eroareDataPlecare = new Label { Width = LATIME_CONTROL, Left = 5 * DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblDataPlecare);
            this.Controls.Add(txtDataPlecare);
            this.Controls.Add(eroareDataPlecare);

            // Data Sosire
            lblDataSosire = new Label { Text = "Data Sosire", Width = LATIME_CONTROL, Left = 6 * DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            txtDataSosire = new TextBox { Width = LATIME_CONTROL, Left = 6 * DIMENSIUNE_PAS_X, Top = DIMENSIUNE_PAS_Y };
            eroareDataSosire = new Label { Width = LATIME_CONTROL, Left = 6 * DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblDataSosire);
            this.Controls.Add(txtDataSosire);
            this.Controls.Add(eroareDataSosire);

            // Tip Avion
            lblTipAvion = new Label { Text = "Tip Avion", Width = LATIME_CONTROL, Left = 7 * DIMENSIUNE_PAS_X, ForeColor = Color.FromArgb(3, 76, 83) };
            cmbTipAvion = new ComboBox
            {
                Width = LATIME_CONTROL,
                Left = 7 * DIMENSIUNE_PAS_X,
                Top = DIMENSIUNE_PAS_Y,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipAvion.Items.AddRange(Enum.GetNames(typeof(TipAvion)));
            eroareTipAvion = new Label { Width = LATIME_CONTROL, Left = 7 * DIMENSIUNE_PAS_X, Top = 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.Red };

            this.Controls.Add(lblTipAvion);
            this.Controls.Add(cmbTipAvion);
            this.Controls.Add(eroareTipAvion);
        }

        private void OnButtonAdaugaZborClicked(object sender, EventArgs e)
        {
            eroareIdZbor.Text = "";
            eroareCompanieAeriana.Text = "";
            eroareAeroportPlecare.Text = "";
            eroareAeroportSosire.Text = "";
            eroareDataPlecare.Text = "";
            eroareDataSosire.Text = "";
            eroareTipAvion.Text = "";

            if (!Prevalidare() && !Validare())
            {
                int idZbor = int.Parse(txtIdZbor.Text);
                string companieAeriana = txtCompanieAeriana.Text;
                string aeroportPlecare = txtAeroportPlecare.Text;
                string aeroportSosire = txtAeroportSosire.Text;
                DateTime dataPlecare = DateTime.ParseExact(txtDataPlecare.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                DateTime dataSosire = DateTime.ParseExact(txtDataSosire.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                TipAvion tipAvion = (TipAvion)Enum.Parse(typeof(TipAvion), cmbTipAvion.SelectedItem.ToString());

                Zbor zbor = new Zbor(idZbor, companieAeriana, aeroportPlecare, aeroportSosire, dataPlecare, dataSosire)
                {
                    TipAvion = tipAvion
                };
                gestiuneZboruri.AddZbor(zbor);

                MessageBox.Show("Zborul a fost adăugat cu succes!");
            }
        }

        private void OnButtonRefreshZboruriClicked(object sender, EventArgs e)
        {
            AfiseazaZboruri();
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

        private void AfiseazaZboruri()
        {
            int nrZboruri;
            Zbor[] zboruri = gestiuneZboruri.GetZboruri(out nrZboruri);

            // Verificare dacă vectorul este null sau gol
            if (zboruri == null || nrZboruri == 0)
            {
                MessageBox.Show("Nu există zboruri de afișat.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int i = 0;
            foreach (Zbor zbor in zboruri)
            {
                if (zbor == null) continue; // Sari peste zborurile neinițializate

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
            AfiseazaZboruri();
        }
    }
}
