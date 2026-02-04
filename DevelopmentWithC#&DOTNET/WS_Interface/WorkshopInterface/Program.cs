namespace WorkshopInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentMethod method = new SwishPayment();
            PaymentProcessor processor = new PaymentProcessor(method);
            processor.ProcessPayment(500.00m);
        }
    }
}
