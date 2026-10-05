
//using System.Globalization;

namespace Personalregister
{
    // ---------------------------------------------------------
    // This class represents an employee with a name and salary.
    // ---------------------------------------------------------
    class Anställd
    {
        public string Namn { get; }
        public int Lön { get; }

        // Methods
        public Anställd(string namn, int lön)
        {
            Namn = namn;
            Lön = lön;
        }
    }

    class Program
    {
        // Lista med anställda (ingen persistent lagring krävs).
        static readonly List<Anställd> register = new List<Anställd>();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("**** Personalregister ****");
                Console.WriteLine("1. Lägg till anställd");
                Console.WriteLine("2. Skriv ut register");
                Console.WriteLine("3. Avsluta");
                Console.Write("Välj alternativ: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1":
                        AddAnställd();
                        break;
                    case "2":
                        PrintRegister();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

            Console.WriteLine("Programmet avslutas.");
        }

        // -------------------------------------------------
        // This method adds a new employee to the register.
        // -------------------------------------------------
        static void AddAnställd()
        {
            string namn;
            while (true)
            {
                Console.Write("Namn: ");
                namn = Console.ReadLine();
                if (!string.IsNullOrEmpty(namn)) break;
                Console.WriteLine("Namnet får inte vara tomt.");
            }

            int lön;
            while (true)
            {
                Console.Write("Lön (kr): ");

                string input = Console.ReadLine().Trim();

                lön = Convert.ToInt32(input);

                if (lön > 0)
                {
                    break;
                }
                Console.WriteLine("Ange ett giltigt belopp > 0");
            }

            register.Add(new Anställd(namn, lön));
            Console.WriteLine($"{namn} har lagts till i personalregistret.");
        }

        // --------------------------------------------------
        // This method prints the contents of the register.
        // --------------------------------------------------
        static void PrintRegister()
        {
            Console.WriteLine();
            if (register.Count == 0)
            {
                Console.WriteLine("Personalregistret är tomt.");
                return;
            }
            else 
            {
                Console.WriteLine($"Antal anställda: {register.Count}");
            }

            Console.WriteLine($"{"Namn",-25}{"Lön",10}");
            Console.WriteLine(new string('-', 40));

            foreach (var i in register)

            {
                Console.WriteLine($"{ i.Namn,-25}{ i.Lön + " kr", 15}");
            }
        }
    }
}