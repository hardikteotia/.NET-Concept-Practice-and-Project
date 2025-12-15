namespace LoggerLibrary
{
    public class FileLogger
    {

        // so now this class constructor is private and cannot be instantiated from outside the class therefore we create its object here itself

        private static FileLogger myLogger = new FileLogger();


        //ddefault constructor of logger
        private FileLogger() {
            Console.WriteLine("Logger instance created || Logger Constructor Called");
        }



        //getter of logger   
        public static FileLogger CurrentLogger
        {
            get
            {
                return myLogger;
            }
            //set { myLogger = value; }
        }


        //message to be printed with timestamp as Log
        public void Log(string message)
        {
            string path = "D:\\Log.txt";

            FileStream stream = null;

            if (File.Exists(path))
            {
                stream = new FileStream(path, FileMode.Append, FileAccess.Write);
            }
            else
            {
                stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            }

            StreamWriter writer = new StreamWriter(stream);
                //it can be file handeling or maybe a DB handeling code
                writer.WriteLine(message + "- Logged at -" + DateTime.Now.ToString());

            writer.Close();
            stream.Close();
        }
    }
}
