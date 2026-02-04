
internal class Program
{
    static void Main(string[] args)
    {
        //Mini-kalkylator

        string op = "";

        while (true)
        {
            Console.WriteLine("Välj operation: +, -, *, /");
            op = Console.ReadLine();

            if (op == "+" || op == "-" || op == "*" || op == "/")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ogiltigt val av operation");
            }
        }

        Console.WriteLine("Skriv första talet:");
        string input1 = Console.ReadLine();
        Console.WriteLine("Skriv andra talet:");
        string input2 = Console.ReadLine();

        int num1 = int.Parse(input1);
        int num2 = int.Parse(input2);
        int sum = 0;

        switch (op)
        {
            case "+":
                sum = num1 + num2;
                break;

            case "-":
                sum = num1 - num2;
                break;

            case "*":
                sum = num1 * num2;
                break;

            case "/":
                sum = num1 / num2; // Fix divide by zero error
                break;

            default:
                Console.WriteLine("Ogiltigt val av operation");
                break;
        }

        Console.WriteLine($"Summan är: {sum}");

        bool ok1 = int.TryParse(input1, out num1);
        bool ok2 = int.TryParse(input2, out num2);

        if (ok1 && ok2)
        {
            Console.WriteLine($"Summan genom parse är: {sum}");
        }
        else
        {
            Console.WriteLine("Du måste skriva två giltiga heltal.");
        }

        //Multiplikationstabell
        /*
        Console.WriteLine("Vilken tabell vill du skriva ut?");
        int table = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{table} * {i} = {table * i}");
        }
        */

        Console.ReadLine();
    }
}