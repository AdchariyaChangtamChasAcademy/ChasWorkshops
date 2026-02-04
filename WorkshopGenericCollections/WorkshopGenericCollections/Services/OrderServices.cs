using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopGenericCollections.Models;

namespace WorkshopGenericCollections.Services
{
    public static class OrderService
    {
        //public static IEnumerable<Product> GetSortedProducts(List<Product> products)
        //{
        //    return products.OrderBy(p => p.Price);
        //}

        //public static IEnumerable<Product> GetFilteredProducts(List<Product> products, decimal minPrice)
        //{
        //    return products.Where(p => p.Price >= minPrice);
        //}

        //public static HashSet<string> GetUniqueProductNames(List<Order> orders)
        //{
        //    return orders.SelectMany(o => o.ProductNames).ToHashSet();
        //}

        //public static void ProcessOrderQueue(Queue<string> orderQueue)
        //{
        //    while (orderQueue.Count > 0)
        //    {
        //        var order = orderQueue.Dequeue();
        //        Console.WriteLine($"Bearbetar order: {order}");
        //    }
        //}

        //public static void UndoLastOrder(Stack<string> orderHistory)
        //{
        //    if (orderHistory.Count > 0)
        //    {
        //        var undone = orderHistory.Pop();
        //        Console.WriteLine($"Ångrade senaste order: {undone}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ingen order att ångra.");
        //    }
        //}
    }
}
