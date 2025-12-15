namespace DemoHelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string aValue;
            string bValue;
            aValue = Console.ReadLine();
            bValue = Console.ReadLine();

            //Console.ReadLine(Convert.ToInt32());

            Console.WriteLine("Value of a: " + aValue);
            int a = Convert.ToInt32(aValue);

            Console.WriteLine("Value of b: " + bValue);
            int b = Convert.ToInt32(bValue);

            Math obj = new Math();

            int result = obj.AddNumbers(a, b);
            
            Console.WriteLine(result);
            //Console.ReadLine(aValue+bValue);
            Console.ReadLine();
        }

        

    }

    public class Math
    {
        public static int AddNumbers(int a, int b)
        {
            int c = a + b;
            return c;
        }
    }
}
