using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class DBInterface
    {
        public DBInterface()
        {
            sqlServerConnection = new SqlConnection(sqlServerConnectionInfo);
        }

        public List <Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            sqlServerConnection.Open();
            string queryToExecute = "Select * from Employees";
            query = new SqlCommand(queryToExecute, sqlServerConnection);
            dataReader = query.ExecuteReader();
            while (dataReader.Read())
            {
                Employee employee = new Employee();
                int Id = (int)dataReader.GetValue(0);
                //
                employees.Add(employee);
            }

            return employees;     
        }

        public List<Employee> getAllOldEmployees()
        {
            List<Employee> employees = new List<Employee>();
            sqlServerConnection.Open();
            string queryToExecute = "Select Id, Name, Age from Employees WHERE Age > 65";
            query = new SqlCommand(queryToExecute, sqlServerConnection);
            dataReader = query.ExecuteReader();
            while (dataReader.Read())
            {
                Employee employee = new Employee();
                int Id = (int)dataReader.GetValue(0);
                //
                employees.Add(employee);
            }

            return employees;
        }

        private string sqlServerConnectionInfo = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Alexandru Oprinca\Documents\testdb.mdf""; Integrated Security = True; Connect Timeout = 30";
        private SqlConnection sqlServerConnection;// = new SqlConnection(connectionString);
        private SqlCommand query;
        private SqlDataReader dataReader;
    }
}
