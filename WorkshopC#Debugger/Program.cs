namespace WorkshopC_Debugger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Genomgångar */
            /*
            //string[] names = { "Alice", "Bob", "Charlie" };

            //for(int i = 0; i < names.Length; i++ )
            //{
            //    Console.WriteLine(names[i]);
            //}

            //string input = "abc";
            //int number;

            //if(int.TryParse(input, out number))
            //{
            //    Console.WriteLine("Talet är: "+number);
            //}
            //else
            //{
            //    Console.WriteLine("Fel! Ogiltigt heltal!");
            //}

            //string message = null;

            //if(!string.IsNullOrEmpty(message))
            //{
            //    Console.WriteLine(message.ToUpper());
            //}
            //else
            //{
            //    Console.WriteLine("Fel! Meddelandet är tomt eller null");
            //}
            */

            /* Parövning bugg fixar */
            /*
            // BUGG 1
            
            //string[] animals = { "Cat", "Dog", "Rabbit" };

            ////for (int i = 0; i <= animals.Length; i++)
            ////{
            ////    Console.WriteLine("Animal: " + animals[i]);
            ////}
            //// Out of index bounds error.

            //for (int i = 0; i < animals.Length; i++)
            //{
            //    Console.WriteLine("Animal: " + animals[i]);
            //}
            // Fix: changed <= to <
            

            // BUGG 2
            
            //string favoriteColor = null;
            //Console.WriteLine("Your favorite color in uppercase: " + favoriteColor.ToUpper());
            // Null error.

            //string favoriteColor = null;

            //if (!string.IsNullOrEmpty(favoriteColor))
            //{
            //    Console.WriteLine("Your favorite color in uppercase: " + favoriteColor.ToUpper());
            //}
            //else
            //{
            //    Console.WriteLine("Fel! Meddelandet är tomt eller null");
            //}

            // Fix: Check for favoriteColor NullOrEmpty.
            // Fix2: Change string favoriteColor from null to a string.
            

            // BUGG 3
            
            //Console.Write("Enter your shoe size: ");
            //string shoeSizeInput = Console.ReadLine();
            //int shoeSize = int.Parse(shoeSizeInput);
            //Console.WriteLine("Your shoe size is: " + shoeSize);
            // System.FormatException: 'The input string 'asd' was not in a correct format.'
            

            //Console.Write("Enter your shoe size: ");
            //string shoeSizeInput = Console.ReadLine();

            //if (int.TryParse(shoeSizeInput, out int shoeSize))
            //{
            //    Console.WriteLine("Your shoe size is: " + shoeSize);
            //}
            //else
            //{
            //    Console.WriteLine("Fel");
            //}
            
            // Fix: Kontrollera med ett TryParse istället för Parse
            */

            /* Gruppövning bugg fixar */

            // BUGG 1
            Console.WriteLine("Enter your favorite number:");
            string input = Console.ReadLine();
            int favNumber; //= Convert.ToInt32(input)

            if (int.TryParse(input, out favNumber))
            {
                Console.WriteLine("Favorit nummer är: " + favNumber);
            }
            else
            {
                Console.WriteLine("Fel");
            }
            // Fix: Ändrade Conver.ToInt32() till en TryParse check.

            //// BUGG 2
            Console.WriteLine("Choose a fruit: apple, banana, cherry");
            string fruit = Console.ReadLine();
            DescribeFruit(fruit);
            // Fix: La till break points i metoden med switch case.

            //// BUGG 3
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            if (name.ToLower() == "alice")
            {
                Console.WriteLine("Welcome, Alice!");
            }
            else
            {
                Console.WriteLine("Access denied.");
            }
            // Fix: Ändra input till lower för att kolla med "alice"

            //// BUGG 4
            int result = Multiply(5);
            int result2 = Multiply(8);
            Console.WriteLine("5 multiplied by 2 is: " + result);
            Console.WriteLine("8 multiplied by 2 is: " + result2);
            // Fix: Ändrade metoden från statiskt 2x2 till nummer x 2.
        }

        /*
        // Metod för humör
        static string GetMood()
        {
            return null;
        }
        */

        // Metod som beskriver frukt
        static void DescribeFruit(string fruit)
        {
            switch (fruit)
            {
                case "apple":
                    Console.WriteLine("Apples are red.");
                    break;
                case "banana":
                    Console.WriteLine("Bananas are yellow.");
                    break;
                case "cherry":
                    Console.WriteLine("Cherries are sweet.");
                    break;
                default:
                    Console.WriteLine("Unknown fruit.");
                    break;
            }
        }

        //// Metod för multiplikation
        static int Multiply(int number)
        {
            return number * 2;
        }

    }
}
