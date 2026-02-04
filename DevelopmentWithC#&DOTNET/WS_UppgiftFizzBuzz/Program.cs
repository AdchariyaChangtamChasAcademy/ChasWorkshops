namespace UppgiftFizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skriv ett program som skriver ut alla siffror från * *1 till 100 * *.

            //Programmet ska följa dessa regler:

            //  Om talet är delbart med * *3 * *skriv ut `"Fizz"`
            //  Om talet är delbart med * *5 * *skriv ut `"Buzz"`
            //  Om talet är delbart med** både 3 och 5 * *skriv ut `"FizzBuzz"`
            //  Annars skriv ut själva talet

            // En for loop för att skriva ut 1 till 100

            // Inom loopen
            // Kolla med modulus 3 och 5 om talet är delbart med 3 och skriv ut "FizzBuzz"
            // Annars kolla med modulus 3 för om talet är delbart med 3 och skriv ut "Fizz"
            // Annars kolla med modulus 5 för om talet är delbart med 5 och skriv ut "Buzz"
            // Om inget ovan gäller skriv ut talet

            for (int i = 1; i <= 100; i++)
            {
                if(i%3==0 && i%5==0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            Console.ReadLine();
        }
    }
}
