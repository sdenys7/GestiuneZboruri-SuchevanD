using System;
using System.Globalization;

namespace GestiuneZboruri
{
    public class Zbor
    {
        public int IDZbor { get; set; }
        public string CompanieAeriana { get; set; }
        public string AeroportPlecare { get; set; }
        public string AeroportSosire { get; set; }
        public DateTime DataPlecare { get; set; }
        public DateTime DataSosire { get; set; }
        public string TipAvion { get; set; } 

        public Zbor() { }
        
        public Zbor(int idZbor, string companieAeriana, string aeroportPlecare, string aeroportSosire, DateTime dataPlecare, DateTime dataSosire)
        {
            IDZbor = idZbor;
            CompanieAeriana = companieAeriana;
            AeroportPlecare = aeroportPlecare;
            AeroportSosire = aeroportSosire;
            DataPlecare = dataPlecare;
            DataSosire = dataSosire;
            TipAvion = GetTipAvionForCompany(companieAeriana);
        }

        public Zbor(string linie)
        {
            string[] tokens = linie.Split(';');
            if (tokens.Length == 7)
            {
                IDZbor = int.Parse(tokens[0]);
                CompanieAeriana = tokens[1];
                AeroportPlecare = tokens[2];
                AeroportSosire = tokens[3];
                DataPlecare = DateTime.ParseExact(tokens[4], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                DataSosire = DateTime.ParseExact(tokens[5], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                TipAvion = tokens[6];
            }
            else
            {
                throw new Exception("Linia din fișier nu are formatul corect!");
            }
        }

        public static string GetTipAvionForCompany(string companie)
        {
            if (companie.Equals("wizzair", StringComparison.OrdinalIgnoreCase))
                return "boeing 747-8i";
            if (companie.Equals("ryanair", StringComparison.OrdinalIgnoreCase))
                return "boing 737";
            if (companie.Equals("airfrance", StringComparison.OrdinalIgnoreCase))
                return "airbus a350";
            return "necunoscut";
        }

        public string ConversieLaSirPentruFisier()
        {
            return $"{IDZbor};{CompanieAeriana};{AeroportPlecare};{AeroportSosire};" +
                   $"{DataPlecare.ToString("dd.MM.yyyy HH:mm")};{DataSosire.ToString("dd.MM.yyyy HH:mm")};{TipAvion}";
        }

        public string Info()
        {
            return $"ID Zbor: {IDZbor}, Companie: {CompanieAeriana}, Plecare: {AeroportPlecare}, " +
                   $"Sosire: {AeroportSosire}, Data Plecare: {DataPlecare.ToString("dd.MM.yyyy HH:mm")}, " +
                   $"Data Sosire: {DataSosire.ToString("dd.MM.yyyy HH:mm")}, Tip Avion: {TipAvion}";
        }
    }
}
