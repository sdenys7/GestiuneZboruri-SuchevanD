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

            // Setare proprietăți formular
            this.Size = new Size(1200, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.FromArgb(0, 112, 116);
            this.Text = "Gestiune Zboruri";
            this.Load += Form1_Load;
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

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
