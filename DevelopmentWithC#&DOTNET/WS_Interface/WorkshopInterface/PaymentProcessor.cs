using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopInterface
{
    public class PaymentProcessor
    {
        private IPaymentMethod _paymentMethod;

        public PaymentProcessor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }
        public void ProcessPayment(decimal amount)
        {
            _paymentMethod.Pay(amount);
        }
    }
}
