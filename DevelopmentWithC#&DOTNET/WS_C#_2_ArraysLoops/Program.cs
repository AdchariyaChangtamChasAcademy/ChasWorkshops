internal class Program
{
    static void Main(string[] args)
    {
        //// UPPGIFT 05/09/2025 ////
        /*
        // Läs in namn och åler från användaren.
        // Skriv ut om personen är myndig (18 år eller äldre).
        Console.Write("Skriv in ditt namn: ");
        string name = Console.ReadLine();
        Console.Write("Skriv in din ålder: ");
        string ageString = Console.ReadLine();
        int ageInt = 0;

        Console.WriteLine();
        bool ageIsValid = Int32.TryParse(ageString, out ageInt);
        if (ageIsValid)
        {
            if(ageInt >= 18)
            {
                Console.WriteLine($"Namn:{name} Ålder:{ageInt} Myndig: JA");
            }
            else
            {
                Console.WriteLine($"Namn:{name} Ålder:{ageInt} Myndig: NEJ");
            }
        }
        else
        {
            Console.WriteLine("Nu vart det tokigt, åldern vart ju inte riktigt rätt!");
        }


        // Skriv ut alla tal mellan 1 och 100 som är delbara med 3.
        Console.WriteLine();
        Console.Write("Tryck [Enter] för att skriva ut alla tal mellan 1 och 100 som är delbara med 3...");
        Console.ReadLine();        
        Console.WriteLine();
        Console.Write("Tal: ");

        for (int i = 1; i <= 100; i++)
        {
            if(i % 3==0)
            {
                Console.Write($"{i.ToString()} ");
            }
        }

        Console.Write($"{Environment.NewLine}{Environment.NewLine}[Enter] för att avsluta...");
        */

        //// TEST 08/09/2025 ////
        //int[] numbers = { 5, 12, 7, 3, 9 };

        //int min = numbers[0];
        //int max = numbers[0];
        //int sum = 0;

        //foreach (int number in numbers)
        //{
        //    if (number < min) min = number;
        //    if (number > max) max = number;
        //    sum += number;
        //}
        //Console.WriteLine($"Min: {min}, Max: {max}, Sum: {sum}");

        //double average = (double)sum / numbers.Length;
        //Console.WriteLine($"Average (double): {average}");

        //// UPPGIFT 08/09/2025 ////

        //  **Övning1: Strängarray & teckenräkning * *
        //  Skapa en array med strängar – t.ex. .namn på fem personer.
        //  Skriv ut hur många tecken varje sträng innehållet

        string[] names = { "Alex", "Gustav", "Magnussom", "Nicklas", "Pelle" };

        foreach(string name in names)
        {
            Console.WriteLine($"Namn: {name}, Tecken i namn: {name.Length}");
        }

        //  **Övning2: Medelvärde**
        //  Läs in fem heltal från användaren till en array.
        //  Beräkna medelvärdet.

        int[] userNums = new int[5];
        int userNumsSum = 0;

        for(int i = 0; i < userNums.Length; i++)
        {
            Console.Write($"Mata in tal [{i}]: ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                userNums[i] = result;
            }
            else
            {
                Console.WriteLine("Försök igen med ett heltal!");
                i--;
            }
        }

        foreach(int nums in userNums)
        {
            Console.Write(nums+" ");
            userNumsSum += nums;
        }

        int userNumsAverage = userNumsSum / userNums.Length;
        Console.WriteLine("");
        Console.WriteLine($"Medelvärdet: {userNumsAverage}");


        //  **Övning3: Loopövning for vs while vs foreach**
        //  Skapa en array med fem tal.
        //  Skriv ut alla tal med for, while och foreach.
        //  Jämför skillnaderna.

        int[] loopNumbers = { 1, 2, 3, 4, 5 };

        Console.Write("For: ");
        for (int i = 0; i < loopNumbers.Length; i++)
        {
            Console.Write(loopNumbers[i] + " ");
        }
        Console.WriteLine("");

        Console.Write("While: ");
        int y = 0;
        while(y < loopNumbers.Length)
        {
            Console.Write(loopNumbers[y] + " ");
            y++;
        }
        Console.WriteLine("");

        Console.Write("Foreach: ");
        foreach(int loopNum in loopNumbers)
        {
            Console.Write(loopNum + " ");
        }
        Console.WriteLine("");

        Console.ReadLine();
    }
}