using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneZboruri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var zbor1 = new Zbor(1023, "AirFrance", "Paris CDG", "Bucharest OTP", "13.03.2025 9:45", "13.03.2025 12:30");
            string s = zbor1.Info();
            Console.WriteLine(s);
            Console.ReadKey();

            // Instantierea unui obiect de gestionare a zborurilor cu capacitatea de 5 zboruri
           
        }
    }
}
