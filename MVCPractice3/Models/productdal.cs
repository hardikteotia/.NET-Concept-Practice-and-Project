using Microsoft.Data.SqlClient;

namespace MVCPractice3.Models
{
    public class productdal
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PracticeDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False";

        public List<productpoco> getAllProducts()
        {
            List<productpoco> fetchedProdList = new List<productpoco>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = "select * from product";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                productpoco prod = new productpoco();
                prod.id = Convert.ToInt32(reader["id"]);
                prod.name = reader["name"].ToString();
                prod.price = Convert.ToDouble(reader["price"]);
                prod.quantity = Convert.ToInt32(reader["quantity"]);
                prod.isavailable = Convert.ToBoolean(reader["isavailable"]);
                fetchedProdList.Add(prod);
            }

            connection.Close();

            return fetchedProdList;
        }

        public int Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string queryFormat = "delete from product where id = {0}";

            string query = string.Format(queryFormat, id);

            SqlCommand command = new SqlCommand(query, connection);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public int Add(productpoco product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string queryFormat = "insert into product(name, price, quantity, isAvailable) values('{0}',{1},{2},'{3}')";

            string query = string.Format(queryFormat, product.name, product.price, product.quantity, true);

            SqlCommand command = new SqlCommand(query, connection);

            int rowsaffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsaffected;
        }


        public int Update(productpoco product)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string queryFormat = "update product set name='{0}', price = {1}, quantity = {2}, isAvailable = '{3}' where id = {4}";

            string query = string.Format(queryFormat, product.name, product.price, product.quantity, product.isavailable, product.id);

            SqlCommand command = new SqlCommand(query, connection);

            int rowsaffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsaffected;
        }


        public productpoco GetOneProd(int id)
        {
            productdal dalobj = new productdal();
            List<productpoco> prodlist = dalobj.getAllProducts();



            productpoco product = (from products in prodlist
                                   where products.id == id
                                   select products).First();

            return product;
        }

    }
}
