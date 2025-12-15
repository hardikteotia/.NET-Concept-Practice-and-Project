using ProductCrud.Model;
namespace ProductCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Inserting the data in db
            //first we will create an object of product
            ProductModel productModelObj = new ProductModel();

            //now we will take inputs from user to get the product details (we only need pname and pprice)
            Console.WriteLine("Enter product name and price");
            string nameOfProduct = Console.ReadLine();
            //after taking the input we are setting object fields
            productModelObj.pName = nameOfProduct;

            double priceOfProduct = Convert.ToDouble(Console.ReadLine());
            productModelObj.pPrice = priceOfProduct;



            //Console.WriteLine(productModelObj.ToString()); just checking if is it setting the values in object or not
            Console.ReadLine();
            #endregion
        }
    }
}
