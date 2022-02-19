using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ""C:\Users\Alexandru Oprinca\Documents\testdb.mdf""; Integrated Security = True; Connect Timeout = 30";
            SqlConnection cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();

                Console.WriteLine("open");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            SqlCommand command;
            SqlDataReader dataReader;

            string sqlQuery = "Select * from Employees";
            command = new SqlCommand(sqlQuery, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
            }


            Console.ReadKey();
            cnn.Close();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
