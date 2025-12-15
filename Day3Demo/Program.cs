using LoggerLibrary;
namespace Day3Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Logger logger = new Logger(); instead of this

            Logger logger = Logger.CurrentLogger; // we are getting the instance of logger class using its static property CurrentLogger
            logger.Log("Main method called");

            Logger.CurrentLogger.Log("Logging using CurrentLogger property directly");
            Logger.CurrentLogger.Log("Logging using CurrentLogger property directly");

            Console.ReadLine(); 
        }
    }

   
}
