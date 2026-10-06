

namespace Personalregister
{
    // ---------------------------------------------------------
    // This class represents an employee with a name and salary.
    // ---------------------------------------------------------
    class Employee
    {
        public string Name { get; }
        public int Salary { get; set; }

        // Methods
        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    class Program
    {
        static List<Employee> register = new List<Employee>();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("**** Personalregister ****");
                Console.WriteLine("1. Lägg till anställd");
                Console.WriteLine("2. Skriv ut register");
                Console.WriteLine("3. Justera lönen");
                Console.WriteLine("4. Avsluta");
                Console.Write("Välj alternativ: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        PrintRegister();
                        break;
                    case "3":
                        AdjustSalary();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }

            Console.WriteLine("Programmet avslutas.");
        }

        // -----------------------------------------------------------
        // The method AddEmployee adds a new employee to the register.
        // -----------------------------------------------------------
        static void AddEmployee()
        {
            string name;
            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name)) break;
                Console.WriteLine("Namnet får inte vara tomt.");
            }

            int salary;
            while (true)
            {
                Console.Write("Månadslön (kr): ");

                string input = Console.ReadLine().Trim();

                salary = Convert.ToInt32(input);

                if (salary <= 0)
                {
                    Console.WriteLine("Ange ett giltigt belopp > 0");
                }
                else
                {
                    break;
                }
            }

            register.Add(new Employee(name, salary));
            Console.WriteLine($"{name} har lagts till i personalregistret.");
        }

        // ---------------------------------------------------------------------
        // The method PrintRegister prints the contents of the personalregister.
        // ---------------------------------------------------------------------
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

            Console.WriteLine($"{"Name",-25}{"Månadslön",10}");
            Console.WriteLine(new string('-', 40));

            foreach (var i in register)

            {
                Console.WriteLine($"{i.Name,-25}{i.Salary + " kr",15}");
            }
        }

        // -----------------------------------------------------------
        // The method AdjustSalary sets a new salay for given name.
        // -----------------------------------------------------------
        static void AdjustSalary()
        {
            string name;
            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name)) break;
                Console.WriteLine("Namnet får inte vara tomt.");
            }

            // Make sure the name exists in the register (case-insensitive)
            var index = register.IndexOf(
                register.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));

            if (index == -1)
            {
                Console.WriteLine($"Anställd med namnet {name} hittades inte.");
                return;
            }

            int newSalary;
            while (true)
            {
                Console.Write("Ange ny månadslön (kr): ");
                string input = Console.ReadLine().Trim();

                newSalary = Convert.ToInt32(input);
                if (newSalary <= 0)
                {
                    Console.WriteLine("Ange ett giltigt belopp > 0");
                }
                else
                {
                    break;
                }
            }

            register[index].Salary = newSalary;
            Console.WriteLine($"{name} har fått lönen justerad, ny lön: {newSalary} kr.");
        }
    }
}