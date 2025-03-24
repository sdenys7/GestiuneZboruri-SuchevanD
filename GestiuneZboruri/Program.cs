using System;
using System.Globalization;
using NivelStocareDate;

namespace GestiuneZboruri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdministrareZboruri_FisierText adminZboruriFisier = new AdministrareZboruri_FisierText("zboruri.txt");
            Zbor zborNou = new Zbor();
            int nrZboruri = 0;
            string optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("C. Citire informatii zbor de la tastatura");
                Console.WriteLine("I. Afisare informatii despre ultimul zbor introdus");
                Console.WriteLine("A. Afisare zboruri din fisier");
                Console.WriteLine("P. Salvare zbor in fisier");
                Console.WriteLine("M. Modificare zbor din fisier");
                Console.WriteLine("D. Stergere zbor din fisier");
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
                        Zbor[] listaZboruriFisier = adminZboruriFisier.GetZboruri(out nrZboruri);
                        AfisareZboruri(listaZboruriFisier, nrZboruri);
                        break;
                    case "P":
                        zborNou.IDZbor = nrZboruri + 1;
                        adminZboruriFisier.AddZbor(zborNou);
                        Console.WriteLine("Zborul a fost salvat in fisier.");
                        break;
                    case "M":
                        Console.Write("Introduceti ID-ul zborului de modificat: ");
                        int idMod = int.Parse(Console.ReadLine());
                        Console.WriteLine("Introduceti noile date pentru zbor:");
                        Zbor zborModificat = CitireZborTastatura();
                        zborModificat.IDZbor = idMod;
                        adminZboruriFisier.UpdateZbor(idMod, zborModificat);
                        Console.WriteLine("Zborul a fost modificat.");
                        break;
                    case "D":
                        Console.Write("Introduceti ID-ul zborului de sters: ");
                        int idDel = int.Parse(Console.ReadLine());
                        adminZboruriFisier.DeleteZbor(idDel);
                        Console.WriteLine("Zborul a fost sters.");
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

            string tipAvion = Zbor.GetTipAvionForCompany(companieAeriana);

            Console.WriteLine("Introduceti Aeroportul Plecare");
            string aeroportPlecare = Console.ReadLine();

            Console.WriteLine("Introduceti Aeroport Sosire");
            string aeroportSosire = Console.ReadLine();

            Console.WriteLine("Introduceti Data Plecare");
            DateTime dataPlecare;
            DateTime.TryParseExact(Console.ReadLine(), format, provider, System.Globalization.DateTimeStyles.None, out dataPlecare);

            Console.WriteLine("Introduceti Data Sosire");
            DateTime dataSosire;
            DateTime.TryParseExact(Console.ReadLine(), format, provider, System.Globalization.DateTimeStyles.None, out dataSosire);

            Zbor zbor = new Zbor(0, companieAeriana, aeroportPlecare, aeroportSosire, dataPlecare, dataSosire);
            zbor.TipAvion = tipAvion;
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
                Console.WriteLine("Nu exista zboruri in fisier.");
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
