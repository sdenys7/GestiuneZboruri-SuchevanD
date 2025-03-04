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
        public string DataPlecare { get; set; }
        public string DataSosire { get; set; }


        // Constructor fara parametri
        public Zbor()
        {
            IDZbor = 0;
            CompanieAeriana = string.Empty;
            AeroportPlecare = string.Empty;
            AeroportSosire = string.Empty;
            DataPlecare = string.Empty;
            DataSosire = string.Empty;

        }

        // Constructor cu parametri
        public Zbor(int idZbor, string companieAeriana, string aeroportPlecare, string aeroportSosire, string dataPlecare, string dataSosire)
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
            return $"ID Zbor: {IDZbor}, Companie: {CompanieAeriana}, Plecare: {AeroportPlecare}, Sosire: {AeroportSosire}, Data Plecare: {DataPlecare}, Data Sosire: {DataSosire}";
        }
    }
}
