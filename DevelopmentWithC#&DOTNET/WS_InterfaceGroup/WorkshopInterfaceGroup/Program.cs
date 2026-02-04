namespace WorkshopInterfaceGroup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger myLogger1 = new FileLogger();
            ILogger myLogger2 = new FileLogger();
            ILogger myLogger3 = new ConsoleLogger();
            ILogger myLogger4 = new FileLogger();

            List<ILogger> myLoggers = new List<ILogger>();

            myLoggers.Add(myLogger1);
            myLoggers.Add(myLogger2);
            myLoggers.Add(myLogger3);
            myLoggers.Add(myLogger4);

            foreach (var logger in myLoggers)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100);
                logger.Log($"Nummer {randomNumber.ToString()}", DateTime.Now);
            }

            ILogger myLogger = new FileLogger();
            LogManager myLogManager = new LogManager(myLogger);
            myLogManager.LogMessage("Test Meddelande", DateTime.Now);
        }
    }
}
