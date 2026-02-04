using WorkshopGenericCollections.Models;
using WorkshopGenericCollections.Repositories;
using WorkshopGenericCollections.Services;

namespace WorkshopGenericCollections
{
    class Program
    {
        static void Main()
        {
            /* Code Along
            // Queue
            //Queue<string> taskQueue = new Queue<string>();
            //taskQueue.Enqueue("Svara på mail");
            //taskQueue.Enqueue("Skriv rapport");
            //taskQueue.Enqueue("Ha möte med Stella");
            //foreach (var task in taskQueue)
            //{
            //    Console.WriteLine($"- {task}");
            //}
            //Console.WriteLine("\nBearbetar uppgift: ");
            //string nextTask = taskQueue.Dequeue();
            //Console.WriteLine($"Utför: {nextTask}");
            //Console.WriteLine("Kvar i kön: ");
            //foreach (var task in taskQueue)
            //{
            //    Console.WriteLine($"- {task}");
            //}

            // Stack
            //Stack<string> actionHistory = new Stack<string>();
            //actionHistory.Push("Lade till produkt");
            //actionHistory.Push("Uppdaterade pris");
            //actionHistory.Push("Tog bort produkt");
            //Console.WriteLine("Åtgärder kvar i stacken: ");
            //foreach(var action in actionHistory)
            //{
            //    Console.WriteLine($"- {action}");
            //}
            //Console.WriteLine("Ångrar senaste åtgärd: ");
            //string undoneAction = actionHistory.Pop();
            //Console.WriteLine($"Ångrade: {undoneAction}");
            //Console.WriteLine("Kvar i stacken ");
            //foreach (var action in actionHistory)
            //{
            //    Console.WriteLine($"- {action}");
            //}
            */

            var repo = new ProductRepository();
            var shop = new ShopService(repo);

            Console.WriteLine("== List<Product> ==");
            Console.WriteLine("Billigast först:");
            foreach (var p in shop.GetProductsSortedByPrice()) Console.WriteLine(p);

            Console.WriteLine("\nDyrast först (>= 2000):");
            foreach (var p in shop.FilterProductsByMinPrice(2000).OrderByDescending(p => p.Price)) Console.WriteLine(p);

            Console.WriteLine("\nEndast Accessories:");
            foreach (var p in shop.FilterProductsByCategory("Accessories")) Console.WriteLine(p);

            Console.WriteLine("\n== Dictionary: Lagersaldo ==");
            shop.PrintInventory();
            var target = "Laptop Pro 14";
            Console.WriteLine($"\nFörsöker reservera 2 st {target}...");
            shop.TryReserve(target, 2);
            shop.PrintInventory();

            Console.WriteLine("\n== HashSet: Unika produktnamn ==");
            var added1 = shop.TryAddProductName("USB‑C Hub");
            var added2 = shop.TryAddProductName("Webcam 4K");
            Console.WriteLine($"Lade till 'USB‑C Hub'? {added1}");
            Console.WriteLine($"Lade till 'Webcam 4K'? {added2}");

            Console.WriteLine("\n== Queue: Orderkö ==");
            var o1 = repo.CreateOrder(1, 3);
            var o2 = repo.CreateOrder(2, 1);
            shop.EnqueueOrder(o1);
            shop.EnqueueOrder(o2);
            shop.PrintQueue();

            Console.WriteLine("\nProcessar nästa order...");
            var processed = shop.ProcessNextOrder();
            Console.WriteLine($"Klar: {processed}");
            shop.PrintQueue();

            Console.WriteLine("\n== Stack: Ångra ==");
            Console.WriteLine("Ångrar senaste åtgärd...");
            shop.UndoLast();
            shop.PrintQueue();

            Console.WriteLine("\nÅngrar föregående (återställ reserv)...");
            shop.UndoLast();
            shop.PrintInventory();

            Console.WriteLine("\n== Logg ==");
            shop.PrintLog();

            Console.WriteLine("\nKlart. Tryck på valfri tangent för att avsluta.");
            Console.ReadKey();
        }
    }
}
