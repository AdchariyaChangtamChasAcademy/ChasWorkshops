using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopGenericCollections.Models;
using WorkshopGenericCollections.Repositories;

namespace WorkshopGenericCollections.Services
{
    class ShopService
    {
        private readonly ProductRepository _repo;
        private readonly List<Product> _productsView;
        private readonly Dictionary<string, int> _inventory = new(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _uniqueProductNames = new(StringComparer.OrdinalIgnoreCase);
        private readonly Queue<string> _orderQueue = new();
        private readonly Stack<string> _undoStack = new();
        private readonly List<string> _log = new();

        public ShopService(ProductRepository repo)
        {
            _repo = repo;
            _productsView = _repo.Products.ToList();
            foreach (var p in _repo.Products) _inventory[p.Name] = Random.Shared.Next(0, 20);
            foreach (var p in _repo.Products) _uniqueProductNames.Add(p.Name);
        }

        // List: sortera, filtrera
        public IEnumerable<Product> GetProductsSortedByPrice(bool asc = true)
            => asc ? _productsView.OrderBy(p => p.Price) : _productsView.OrderByDescending(p => p.Price);
        public IEnumerable<Product> FilterProductsByCategory(string category)
            => _productsView.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        public IEnumerable<Product> FilterProductsByMinPrice(decimal min)
            => _productsView.Where(p => p.Price >= min).OrderBy(p => p.Price);

        // Dictionary: lager
        public int GetStock(string productName)
            => _inventory.TryGetValue(productName, out var qty) ? qty : 0;
        public bool TryReserve(string productName, int qty)
        {
            if (_inventory.TryGetValue(productName, out var stock) && stock >= qty)
            {
                _inventory[productName] = stock - qty;
                _log.Add($"Reserverade {qty} st {productName} (kvar: {_inventory[productName]})");
                _undoStack.Push($"RESTORE:{productName}:{qty}");
                return true;
            }
            _log.Add($"Kunde inte reservera {qty} st {productName} (lager: {stock})");
            return false;
        }

        // HashSet: unika namn
        public bool TryAddProductName(string name) => _uniqueProductNames.Add(name);

        // Queue: orderkö
        public void EnqueueOrder(Order order)
        {
            var msg = $"ORDER {order.Id} (C{order.CustomerId}) P{order.ProductId}";
            _orderQueue.Enqueue(msg);
            _log.Add($"Lade i kö: {msg}");
            _undoStack.Push($"DEQUEUE:{msg}");
        }
        public string? ProcessNextOrder()
        {
            if (_orderQueue.Count == 0) return null;
            var msg = _orderQueue.Dequeue();
            _log.Add($"Processade: {msg}");
            _undoStack.Push($"ENQUEUE:{msg}");
            return msg;
        }

        // Stack: ångra
        public bool UndoLast()
        {
            if (_undoStack.Count == 0) return false;
            var action = _undoStack.Pop();
            var parts = action.Split(':');
            switch (parts[0])
            {
                case "RESTORE":
                    var name = parts[1];
                    var qty = int.Parse(parts[2]);
                    _inventory[name] = GetStock(name) + qty;
                    _log.Add($"Ångra: Återställde {qty} till {name} (lager: {_inventory[name]})");
                    return true;
                case "DEQUEUE":
                    var msg = string.Join(':', parts.Skip(1));
                    var buf = new Queue<string>();
                    var removed = false;
                    while (_orderQueue.Count > 0)
                    {
                        var x = _orderQueue.Dequeue();
                        if (!removed && x == msg) { removed = true; continue; }
                        buf.Enqueue(x);
                    }
                    while (buf.Count > 0) _orderQueue.Enqueue(buf.Dequeue());
                    _log.Add($"Ångra: Tog bort ur kö: {msg}");
                    return true;
                case "ENQUEUE":
                    var toEnqueue = string.Join(':', parts.Skip(1));
                    _orderQueue.Enqueue(toEnqueue);
                    _log.Add($"Ångra: Lade tillbaka i kö: {toEnqueue}");
                    return true;
                default:
                    _log.Add($"Okänd ångra‑åtgärd: {action}");
                    return false;
            }
        }

        public void PrintInventory()
        {
            foreach (var product in _uniqueProductNames)
            {
                Console.WriteLine($"- {product}");
            }
        }

        public void PrintQueue()
        {
            foreach (var order in _orderQueue)
            {
                Console.WriteLine($"- {order}");
            }
        }

        public void PrintLog()
        {
            foreach (var log in _log)
            {
                Console.WriteLine($"- {log}");
            }
        }
    }
}
