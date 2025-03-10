using GestiuneZboruri;
using System;
namespace NivelStocareDate
{

    public class AdministrareZboruri_Memorie
    {
        private Zbor[] zboruri;
        private int count;

        public AdministrareZboruri_Memorie(int capacity = 100)
        {
            zboruri = new Zbor[capacity];
            count = 0;
        }

        public void AddZbor(Zbor zbor)
        {
            if (count < zboruri.Length)
            {
                zboruri[count++] = zbor;
            }
            else
            {
                Console.WriteLine("Capacitate maximă atinsă!");
            }
        }

        public Zbor[] GetZboruri(out int nrZboruri)
        {
            nrZboruri = count;
            return zboruri;
        }
    }
}