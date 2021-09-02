using AZWebAppDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AZWebAppDB.Services
{
    public class CourseService
    {
        //private static string db_source = "tks007dbserver.database.windows.net";
        //private static string db_user = "tks007";
        //private static string db_password = "Tksantra007))&";
        //private static string db_database = "tks007DB";


        private SqlConnection GetConnection(string _connection_string)
        {
            // Here we are creating the SQL connection
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;
            //return new SqlConnection(_builder.ConnectionString);
            return new SqlConnection(_connection_string);
        }
        public IEnumerable<Course> GetCourses(string _connection_string)
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT courseid,coursename,rating from Course";
            SqlConnection _connection = GetConnection(_connection_string);
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        Courseid = _reader.GetInt32(0),
                        Coursename = _reader.GetString(1),
                        Rating = _reader.GetInt32(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }
    }
}
