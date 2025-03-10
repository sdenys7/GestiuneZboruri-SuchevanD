using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Zbor() { }

        public Zbor(int idZbor, string companieAeriana, string aeroportPlecare, string aeroportSosire, DateTime dataPlecare, DateTime dataSosire)
        {
            IDZbor = idZbor;
            CompanieAeriana = companieAeriana;
            AeroportPlecare = aeroportPlecare;
            AeroportSosire = aeroportSosire;
            DataPlecare = dataPlecare;
            DataSosire = dataSosire;
        }

        public string Info()
        {
            return $"ID Zbor: {IDZbor}, Companie: {CompanieAeriana}, Plecare: {AeroportPlecare}, " +
                   $"Sosire: {AeroportSosire}, Data Plecare: {DataPlecare.ToString("dd.MM.yyyy HH:mm")}, " +
                   $"Data Sosire: {DataSosire.ToString("dd.MM.yyyy HH:mm")}";
        }
    }
}
