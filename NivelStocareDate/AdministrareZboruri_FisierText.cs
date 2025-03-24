using System;
using System.Collections.Generic;
using System.IO;
using GestiuneZboruri;

namespace NivelStocareDate
{
    public class AdministrareZboruri_FisierText
    {
        private const int NR_MAX_ZBORURI = 50;
        private string numeFisier;

        public AdministrareZboruri_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddZbor(Zbor zbor)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(zbor.ConversieLaSirPentruFisier());
            }
        }

        public Zbor[] GetZboruri(out int nrZboruri)
        {
            Zbor[] zboruri = new Zbor[NR_MAX_ZBORURI];
            nrZboruri = 0;

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    zboruri[nrZboruri++] = new Zbor(linieFisier);
                }
            }

            return zboruri;
        }

        public void UpdateZbor(int id, Zbor zborNou)
        {
            List<string> linii = new List<string>(File.ReadAllLines(numeFisier));
            for (int i = 0; i < linii.Count; i++)
            {
                string[] tokens = linii[i].Split(';');
                if (tokens.Length >= 1 && int.Parse(tokens[0]) == id)
                {
                    linii[i] = zborNou.ConversieLaSirPentruFisier();
                    break;
                }
            }
            File.WriteAllLines(numeFisier, linii);
        }

        public void DeleteZbor(int id)
        {
            List<string> linii = new List<string>(File.ReadAllLines(numeFisier));
            linii.RemoveAll(linie =>
            {
                string[] tokens = linie.Split(';');
                return tokens.Length >= 1 && int.Parse(tokens[0]) == id;
            });
            File.WriteAllLines(numeFisier, linii);
        }
    }
}
