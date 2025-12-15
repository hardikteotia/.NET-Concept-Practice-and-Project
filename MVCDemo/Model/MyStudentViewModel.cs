using Microsoft.Data.SqlClient;
namespace MVCDemo.Model
{
    public class MyStudentViewModel
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=examdb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False";

        public List<MyStudent> GetAllStudents()
        {
            List<MyStudent> studentsList = new List<MyStudent>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand("select * from MyStudent", connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                MyStudent student = new MyStudent();

                student.No= Convert.ToInt32(reader["No"]);
                student.Name = reader["Name"].ToString();
                student.Age = Convert.ToInt32(reader["Age"]);
                student.EMail= reader["EMail"].ToString();
                student.Address= reader["Address"].ToString();
                studentsList.Add(student);

            }

            connection.Close();
            return studentsList;
        }

        public MyStudent GetStudentByNumber(int No)
        {
            List<MyStudent> studentList = GetAllStudents();
            MyStudent filteredStudent = (from student in studentList
                                         where student.No == No
                                         select student).First();

            return filteredStudent;
        }

        public int AddStudent(MyStudent student)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string queryFormat = "insert into MyStudent(Name, Address, Age, EMail, isEMailValidated) values('{0}','{1}',{2},'{3}','{4}')";

            //string query = "AddRecord" --procedure name
           

            string query = string.Format(queryFormat, student.Name, student.Address, student.Age, student.EMail, true);

            //string queryFormat = "insert into MyStudent(Name, Address, Age, EMail) values('{0}','{1}','{2}','{3}')";

            //string query = string.Format(queryFormat, student.Name, student.Address, student.Age, student.EMail);


            SqlCommand command = new SqlCommand(query, connection);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            //command.CommandType = System.Data --check it from addrecord via procedure
            return rowsAffected;
        }

        public int UpdateStudent(MyStudent student)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string queryFormat = "update MyStudent set Name = '{0}', Address = '{1}', Age = {2}, EMail = '{3}' where No = {4}";

            string query = string.Format(queryFormat, student.Name, student.Address, student.Age, student.EMail, student.No);

            SqlCommand command = new SqlCommand(query, connection);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public int DeleteStudent(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string queryFormat = "delete from MyStudent where No = {0}";

            string query = string.Format(queryFormat,id);

            SqlCommand command = new SqlCommand(query, connection);

            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected;
        }
    }
}
