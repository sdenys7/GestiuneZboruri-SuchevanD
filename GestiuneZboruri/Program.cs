using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelStocareDate;

namespace GestiuneZboruri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdministrareZboruri_Memorie adminZboruri = new AdministrareZboruri_Memorie();
            Zbor zborNou = new Zbor();
            int nrZboruri = 0;
            string optiune;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("C. Citire informatii zbor de la tastatura");
                Console.WriteLine("I. Afisare informatii despre ultimul zbor introdus");
                Console.WriteLine("A. Afisare zboruri din memorie");
                Console.WriteLine("S. Salvare zbor in vectorul de obiecte");
                Console.WriteLine("X. Inchidere program");
                Console.Write("Alegeti o optiune: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        zborNou = CitireZborTastatura();
                        break;
                    case "I":
                        AfisareZbor(zborNou);
                        break;
                    case "A":
                        Zbor[] listaZboruri = adminZboruri.GetZboruri(out nrZboruri);
                        AfisareZboruri(listaZboruri, nrZboruri);
                        break;
                    case "S":
                        int idZbor = nrZboruri + 1;
                        zborNou.IDZbor = idZbor;
                        adminZboruri.AddZbor(zborNou);
                        Console.WriteLine("Zborul a fost salvat in memorie.");
                        break;
                    case "X":
                        Console.WriteLine("Iesire din program...");
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta!");
                        break;
                }
                Console.ReadKey();
            } while (optiune.ToUpper() != "X");
        }


        public static Zbor CitireZborTastatura()
        {
            string format = "dd.MM.yyyy HH:mm";
            CultureInfo provider = CultureInfo.InvariantCulture;
            Console.WriteLine("Introduceti Companie Aeriana");
            string companieAeriana = Console.ReadLine();

            Console.WriteLine("Introduceti Aeroportul Plecare");
            string aeroportPlecare = Console.ReadLine();

            Console.WriteLine("Introduceti Aeroport Sosire");
            string aeroportSosire = Console.ReadLine();

            Console.WriteLine("Introduceti Data Plecare");
            DateTime dataPlecare;
            DateTime.TryParseExact(Console.ReadLine(),format, provider, DateTimeStyles.None, out dataPlecare);

            Console.WriteLine("Introduceti Dara Sosire");
            DateTime dataSosire;
            DateTime.TryParseExact(Console.ReadLine(), format, provider, DateTimeStyles.None, out dataSosire);
            Zbor zbor = new Zbor(0,companieAeriana,aeroportPlecare,aeroportSosire,dataPlecare,dataSosire);
            return zbor;
        }

        public static void AfisareZbor(Zbor zbor)
        {
            if (zbor != null)
            {
                Console.WriteLine("Informatii zbor:");
                Console.WriteLine(zbor.Info());
            }
            else
            {
                Console.WriteLine("Nu exista informatii de afisat.");
            }
        }

        public static void AfisareZboruri(Zbor[] zboruri, int nrZboruri)
        {
            Console.WriteLine("\nLista zborurilor:");
            if (nrZboruri == 0)
            {
                Console.WriteLine("Nu exista zboruri in memorie.");
            }
            else
            {
                for (int i = 0; i < nrZboruri; i++)
                {
                    Console.WriteLine(zboruri[i].Info());
                }
            }
        }

    }
}