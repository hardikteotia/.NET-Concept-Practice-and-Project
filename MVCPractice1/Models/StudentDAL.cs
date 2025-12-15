using Microsoft.Data.SqlClient;

namespace MVCPractice1.Models
{
    public class StudentDAL
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=examdb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False";

        public List<Student> GetStudents()
        {
            List<Student> studentsList = new List<Student>();
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand("select * from Student",connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) { 
                
                Student student = new Student();
                student.id = Convert.ToInt32(reader["id"]);
                student.name = reader["name"].ToString();

                student.sclass = reader["sclass"].ToString();
                student.age = Convert.ToInt32(reader["age"]);
                student.isActive = Convert.ToBoolean(reader["isActive"]);
                //i want that whenever an object us being create isactive set to trueitself since its default is already set to true

                //student.isActive = true;

                //or one thing i can do is i can set isActive here true by default instead of doing it in the Student POCO 
                studentsList.Add(student);
            
            }

            return studentsList;
        }

        public int AddStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryString = "insert into Student(name, sclass, age) values('{0}','{1}','{2}')";
            
            string query = string.Format(queryString, student.name, student.sclass, student.age);

            SqlCommand command = new SqlCommand(query,connection);


            int rowsAffected = command.ExecuteNonQuery(); 

            return rowsAffected;
        }

    }
}
