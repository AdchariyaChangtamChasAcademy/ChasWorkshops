namespace WorkshopLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User {Name = "Alice", Age = 30, Role = "Admin", Skills = new List<string>{ "C#", "SQL"} },
                new User {Name = "Bob", Age = 25, Role = "User", Skills = new List<string>{ "HTML", "CSS"} },
                new User {Name = "Charlie", Age = 35, Role = "User", Skills = new List<string>{ "JavaScript", "React"} },
                new User {Name = "Diana", Age = 22, Role = "Admin", Skills = new List<string>{ "Python", "C#"} },
                new User {Name = "Eve", Age = 20, Role = "User", Skills = new List<string>{ "C#", "Azure"} }
            };


            Console.WriteLine("Users over 25:");
            var over25 = users.Where(u => u.Age > 25);
            foreach(var user in over25)
            {
                Console.WriteLine($"{user.Name} ({user.Age})");
            }

            Console.WriteLine("\nUsers sorted by name:");
            var sortedByName = users.OrderBy(u => u.Name);
            foreach(var user in sortedByName)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("\nUsers sorted by age:");
            var sortedByAge = users.OrderByDescending(u => u.Age);
            foreach (var user in sortedByAge)
            {
                Console.WriteLine($"{user.Name} ({user.Age})");
            }

            Console.WriteLine("\nList of names:");
            var names = users.Select(u => u.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nFirst user with the role 'User':");
            var firstUser = users.FirstOrDefault(u => u.Role == "User");
            Console.WriteLine(firstUser != null ? firstUser.Name : "User with role 'User' not found.");

            Console.WriteLine("\nUser with 'React' skill exists:");
            bool hasReact = users.Any(u => u.Skills.Contains("React"));
            Console.WriteLine(hasReact ? "Yes" : "No");

            Console.WriteLine("\nDoes everyone have at least a skill:");
            bool allSKilled = users.All(u => u.Skills.Count > 0);
            Console.WriteLine(allSKilled ? "Yes" : "No");

            Console.WriteLine("\nUsers grouped by role:");
            var groupedByRole = users.GroupBy(u => u.Role);
            foreach(var group in groupedByRole)
            {
                Console.WriteLine($"\nRole: {group.Key}");
                foreach(var user in group)
                {
                    Console.WriteLine($"- {user.Name}");
                }
            }

            Console.WriteLine("\nAmount of users per role:");
            var roleCount = users
                .GroupBy(u => u.Role)
                .Select(g => new {Role = g.Key, Count = g.Count()});
            foreach(var rc in roleCount)
            {
                Console.WriteLine($"{rc.Role}: {rc.Count}");
            }
        }
    }
}
