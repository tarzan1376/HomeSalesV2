using System;

class HomeSales
{
    public static void Main(string[] args)
    {
        string[] salespersons = { "Danielle", "Edward", "Francis" };
        char[] initials = { 'D', 'E', 'F' };
        decimal[] totals = new decimal[salespersons.Length];

        while (true)
        {
            Console.WriteLine("Enter the initial of your salesperson (D for Danielle, E for Edward, F for Francis) and type Z when done: ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Z")
            {
                break;
            }

            char initial = char.ToUpper(input[0]);
            int index = Array.IndexOf(initials, initial);

            if (index == -1)
            {
                Console.WriteLine("Error, invalid salesperson selected, please try again.");
                continue;
            }

            Console.Write($"Enter sale amount for {salespersons[index]}: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal saleAmount))
            {
                totals[index] += saleAmount;
            }
            else
            {
                Console.WriteLine("Error, invalid sale amount entered. Please try again.");
            }
        }

        decimal grandTotal = 0m;
        decimal highestTotal = 0m;
        string highestSale = "";

        for (int i = 0; i < totals.Length; i++)
        {
            grandTotal += totals[i];

            if (totals[i] > highestTotal)
            {
                highestTotal = totals[i];
                highestSale = initials[i].ToString();
            }
        }

        Console.WriteLine("\nSales Totals:");
        for (int i = 0; i < salespersons.Length; i++)
        {
            if (totals[i] > 0)
            {
                Console.WriteLine($"{salespersons[i]}'s Total: {totals[i]:C}");
            }
        }

        Console.WriteLine($"Grand Total: {grandTotal:C}");
        Console.WriteLine($"Highest Sale: {highestSale}");
    }
}