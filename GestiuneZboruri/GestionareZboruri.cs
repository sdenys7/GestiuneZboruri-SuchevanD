using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneZboruri
{
    class GestionareZboruri
    {
        public Zbor[] Zboruri;

        // Constructor fara parametri
        public GestionareZboruri(int capacitate)
        {
            Zboruri = new Zbor[capacitate];
        }

        // Constructor cu parametri
        public GestionareZboruri(Zbor[] zboruri)
        {
            Zboruri = zboruri;
        }
    }
}
