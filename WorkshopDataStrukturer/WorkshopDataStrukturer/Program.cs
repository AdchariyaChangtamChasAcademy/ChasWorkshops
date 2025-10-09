namespace WorkshopDataStrukturer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> users = new List<string> { "Alice","Bob","Charlie"};

            Console.WriteLine("Användare i listan: ");

            foreach(var user in users)
            {
                Console.WriteLine($"{user}");
            }

            users.Add("Diana");

            Console.WriteLine("\nUppdaterad lista 1: ");

            foreach(var user in users)
            {
                Console.WriteLine($"{user}");
            }

            users.Add("Alice");

            Console.WriteLine("\nUppdaterad lista 2: ");

            foreach (var user in users)
            {
                Console.WriteLine($"{user}");
            }

            if(users.Contains("Bob"))
            {
                Console.WriteLine("\nBob finns i listan.");
            }

            users.Remove("Charlie");
            users.Sort();

            Console.WriteLine("\nUppdaterad lista 3: ");

            foreach (var user in users)
            {
                Console.WriteLine($"{user}");
            }

            Dictionary<string, int> userAges = new Dictionary<string, int> 
            {
                { "Alice", 30 },
                { "Bob", 25}
            };

            userAges["Diana"] = 27;

            Console.WriteLine("\nUser ages: ");

            foreach(var kvp in userAges)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} år gammal.");
            }

            if(userAges.TryGetValue("Bob", out int age))
            {
                Console.WriteLine($"{age} är Bobs ålder");
            }

            Console.WriteLine("\nAlla användarnamn: ");

            foreach(var key in userAges.Keys)
            {
                Console.WriteLine($"{key}");
            }

            Console.WriteLine("\nAlla åldrar: ");

            foreach (var value in userAges.Values)
            {
                Console.WriteLine($"{value}");
            }

            HashSet<string> loggedInUsers = new HashSet<string>();

            loggedInUsers.Add("Alice");
            loggedInUsers.Add("Bob");
            loggedInUsers.Add("Alice");

            if(loggedInUsers.Contains("Bob"))
            {
                Console.WriteLine("Bob är inloggad.");
            }
        }
    }
}
