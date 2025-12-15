namespace Day4Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySQL mySQL = new MySQL();

            mySQL.AfterInsert += AfterInsertCalled;//whenever this after insert happens then we have to handle the event and call the method AfterInsertCalled
            mySQL.Insert("Some data"); 

            Oracle oracle = new Oracle();
            oracle.AfterInsert += AfterInsertCalled;
            oracle.Insert("Some data for Oracle DB");


            Console.ReadLine();
        }

        static void AfterInsertCalled()
        {
            Console.WriteLine("After Insert event triggered. || Insert done at"+ DateTime.Now.ToString());
        }
    }

    public class MySQL
    {

        public event Action AfterInsert;
        public void  Insert(string message)
        {
            Console.WriteLine($"Inserting '{message}' into MySQL database.");

            AfterInsert();
        }
    }

    public class Oracle
    {

        public event Action AfterInsert;
        public void Insert(string message)
        {
            Console.WriteLine($"Inserting '{message}' into MySQL database.");

            AfterInsert();
        }
    }
}
