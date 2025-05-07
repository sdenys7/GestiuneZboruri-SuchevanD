using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using GestiuneZboruri;

namespace NivelStocareDate
{
    public class AdministrareZboruri_FisierText
    {
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

        public List<Zbor> GetZboruri()
        {
            List<Zbor> zboruri = new List<Zbor>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    zboruri.Add(new Zbor(linieFisier));
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

        public Zbor GetZbor(int idZbor)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Zbor zbor = new Zbor(linieFisier);
                    if (zbor.IDZbor == idZbor)
                        return zbor;
                }
            }
            return null;
        }
    }
}
