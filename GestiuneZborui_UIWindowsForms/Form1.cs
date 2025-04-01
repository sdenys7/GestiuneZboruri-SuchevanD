using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieZboruri;
using NivelStocareDate;
using GestiuneZboruri;
using System.Configuration;

namespace GestiuneZborui_UIWindowsForms
{
    public partial class Form1: Form
    {
        private Label lblIDZbor;
        private Label lblCompanieAeriana;
        private Label lblAeroportPlecare;
        private Label lblAeroportSosire;
        private Label lblDataPlecare;
        private Label lblDataSosire;
        private Label lblTipAvion;


        private Label[] lblsIDZbor;
        private Label[] lblsCompanieAeriana;
        private Label[] lblsAeroportPlecare;
        private Label[] lblsAeroportSosire;
        private Label[] lblsDataPlecare;
        private Label[] lblsDataSosire;
        private Label[] lblsTipAvion;
        private Label[] lblsNume;
        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        private readonly AdministrareZboruri_FisierText adminZboruri;

        public Form1()
        {
            InitializeComponent();

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            adminZboruri = new
            AdministrareZboruri_FisierText(numeFisier);
            int nrZboruri = 0;
            Zbor[] zboruri = adminZboruri.GetZboruri(out nrZboruri);

            //setare proprietati
            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Informatii Zboruri";

            //adaugare control de tip Label pentru 'IDZbor';
            lblIDZbor = new Label();
            lblIDZbor.Width = LATIME_CONTROL;
            lblIDZbor.Text = "IDZbor";
            lblIDZbor.Left = DIMENSIUNE_PAS_X;
            lblIDZbor.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblIDZbor);

            //adaugare control de tip Label pentru 'CompanieAeriana';
            lblCompanieAeriana = new Label();
            lblCompanieAeriana.Width = LATIME_CONTROL;
            lblCompanieAeriana.Text = "CompanieAeriana";
            lblCompanieAeriana.Left = 2 * DIMENSIUNE_PAS_X;
            lblCompanieAeriana.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCompanieAeriana);

            //adaugare control de tip Label pentru 'AeroportPlecare';
            lblAeroportPlecare = new Label();
            lblAeroportPlecare.Width = LATIME_CONTROL;
            lblAeroportPlecare.Text = "AeroportPlecare";
            lblAeroportPlecare.Left = 3 * DIMENSIUNE_PAS_X;
            lblAeroportPlecare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAeroportPlecare);

            //adaugare control de tip Label pentru 'AeroportSosire';
            lblAeroportSosire = new Label();
            lblAeroportSosire.Width = LATIME_CONTROL;
            lblAeroportSosire.Text = "AeroportSosire";
            lblAeroportSosire.Left = 4 * DIMENSIUNE_PAS_X;
            lblAeroportSosire.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAeroportSosire);

            //adaugare control de tip Label pentru 'DataPlecare';
            lblDataPlecare= new Label();
            lblDataPlecare.Width = LATIME_CONTROL;
            lblDataPlecare.Text = "DataPlecare";
            lblDataPlecare.Left = 5 * DIMENSIUNE_PAS_X;
            lblDataPlecare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblDataPlecare);

            //adaugare control de tip Label pentru 'DataSosire';
            lblDataSosire = new Label();
            lblDataSosire.Width = LATIME_CONTROL;
            lblDataSosire.Text = "DataSosire";
            lblDataSosire.Left = 6 * DIMENSIUNE_PAS_X;
            lblDataSosire.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblDataSosire);

            //adaugare control de tip Label pentru 'TipAvion';
            lblTipAvion = new Label();
            lblTipAvion.Width = LATIME_CONTROL;
            lblTipAvion.Text = "TipAvion";
            lblTipAvion.Left = 7 * DIMENSIUNE_PAS_X;
            lblTipAvion.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblTipAvion);

            Button buton = new Button();
            buton.Text = "Afisare";
            buton.Click += Buton_Click;
            Controls.Add(buton);
        }

        private void Buton_Click(object sender, EventArgs e)
        {
            AfiseazaStudenti();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AfiseazaStudenti();
        }

        private void AfiseazaStudenti()
        {
            // Obtine zborurile si numarul lor
            Zbor[] zboruri = adminZboruri.GetZboruri(out int nrZboruri);

            // Initializeaza array-urile pentru etichete
            lblsIDZbor = new Label[nrZboruri];
            lblsCompanieAeriana = new Label[nrZboruri];
            lblsAeroportPlecare = new Label[nrZboruri];
            lblsAeroportSosire = new Label[nrZboruri];
            lblsDataPlecare = new Label[nrZboruri];
            lblsDataSosire = new Label[nrZboruri];
            lblsTipAvion = new Label[nrZboruri];

            for (int i = 0; i < nrZboruri; i++)
            {
                // IDZbor
                lblsIDZbor[i] = new Label();
                lblsIDZbor[i].Width = LATIME_CONTROL;
                lblsIDZbor[i].Text = zboruri[i].IDZbor.ToString();
                lblsIDZbor[i].Left = DIMENSIUNE_PAS_X;
                lblsIDZbor[i].Top = DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsIDZbor[i]);

                //// CompanieAeriana
                lblsCompanieAeriana[i] = new Label();
                lblsCompanieAeriana[i].Width = LATIME_CONTROL;
                lblsCompanieAeriana[i].Text = zboruri[i].CompanieAeriana;
                lblsCompanieAeriana[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsCompanieAeriana[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsCompanieAeriana[i]);

                // AeroportPlecare
                lblsAeroportPlecare[i] = new Label();
                lblsAeroportPlecare[i].Width = LATIME_CONTROL;
                lblsAeroportPlecare[i].Text = zboruri[i].AeroportPlecare;
                lblsAeroportPlecare[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsAeroportPlecare[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAeroportPlecare[i]);

                // AeroportSosire
                lblsAeroportSosire[i] = new Label();
                lblsAeroportSosire[i].Width = LATIME_CONTROL;
                lblsAeroportSosire[i].Text = zboruri[i].AeroportSosire;
                lblsAeroportSosire[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsAeroportSosire[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsAeroportSosire[i]);

                // DataPlecare
                lblsDataPlecare[i] = new Label();
                lblsDataPlecare[i].Width = LATIME_CONTROL;
                lblsDataPlecare[i].Text = zboruri[i].DataPlecare.ToString();
                lblsDataPlecare[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsDataPlecare[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDataPlecare[i]);

                // DataSosire
                lblsDataSosire[i] = new Label();
                lblsDataSosire[i].Width = LATIME_CONTROL;
                lblsDataSosire[i].Text = zboruri[i].DataSosire.ToString();
                lblsDataSosire[i].Left = 6 * DIMENSIUNE_PAS_X;
                lblsDataSosire[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDataSosire[i]);

                // TipAvion
                lblsTipAvion[i] = new Label();
                lblsTipAvion[i].Width = LATIME_CONTROL;
                lblsTipAvion[i].Text = zboruri[i].TipAvion.ToString();
                lblsTipAvion[i].Left = 7 * DIMENSIUNE_PAS_X;
                lblsTipAvion[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsTipAvion[i]);
            }
        }
    }
}
