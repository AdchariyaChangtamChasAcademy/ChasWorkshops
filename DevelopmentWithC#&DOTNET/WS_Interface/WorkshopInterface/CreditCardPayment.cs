using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopInterface
{
    public class CreditCardPayment : IPaymentMethod
    {
        public void Pay(decimal amount) 
        {
            Console.WriteLine($"Betalar {amount} SEK med kreditkort.");
        }
    }
}
