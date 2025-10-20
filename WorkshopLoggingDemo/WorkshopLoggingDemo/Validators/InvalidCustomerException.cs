namespace WorkshopLoggingDemo.Validators
{
    public class InvalidCustomerException : Exception
    {
        public InvalidCustomerException(string message) : base(message) { }
    }
}
