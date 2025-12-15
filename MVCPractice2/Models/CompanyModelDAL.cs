using Microsoft.Data.SqlClient;

namespace MVCPractice2.Models
{
    public class CompanyModelDAL
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PracticeDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False";

        public List<CompanyModel> GetAllEmp()
        {
            List<CompanyModel> emplist = new List<CompanyModel>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand comamnd = new SqlCommand("select * from employee",connection);

            SqlDataReader reader = comamnd.ExecuteReader();

            while (reader.Read())
            {
                CompanyModel emp = new CompanyModel();

                emp.id = Convert.ToInt32(reader["id"]);
                emp.name = reader["name"].ToString();
                emp.email = reader["email"].ToString();
                emp.age = Convert.ToInt32(reader["age"]);
                emp.dept = reader["dept"].ToString();
                emp.salary = Convert.ToDouble(reader["salary"]);

                emplist.Add(emp);
            
            }

            return emplist;
        }

        public CompanyModel GetSingleEmp(int id)
        {
            List<CompanyModel> allEmps = GetAllEmp();

            CompanyModel filteredEmp = (from e in allEmps
                                       where e.id == id
                                       select e).First();

            

            return filteredEmp;

        }

        public int Create(CompanyModel emp)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string queryformat = "insert into employee(name,email,age,dept,salary) values('{0}','{1}',{2},'{3}',{4})";

            string query = string.Format(queryformat, emp.id,emp.email,emp.age,emp.dept,emp.salary);

            SqlCommand comamnd = new SqlCommand(query,connection);

            int rowsAffected = comamnd.ExecuteNonQuery();

            return rowsAffected;
        }

        public int Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string queryFormat = "delete from employee where id = '{0}'";

            string query = string.Format(queryFormat, id);

            SqlCommand command = new SqlCommand(query,connection);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }

        public int Update(CompanyModel emp)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string queryFormat = "update employee set name = '{0}', email = '{1}', age = {2}, dept = '{3}', salary = {4} where id = {5}";

            string query = string.Format (queryFormat, emp.name, emp.email, emp.age, emp.dept, emp.salary, emp.id);

            SqlCommand command = new SqlCommand(query,connection);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }
    }
}
