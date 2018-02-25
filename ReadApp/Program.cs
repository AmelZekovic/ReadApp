using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            try
            {
                using (conn)
                {
                    conn.Open();
                    string sql = "SELECT Products.ProductID, Products.ProductName, Categories.CategoryName FROM Products LEFT JOIN Categories ON Products.CategoryID=Categories.CategoryID";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader;
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["ProductName"] + ", " + reader["CategoryName"]);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine("Error reading the database");
                Console.WriteLine(err.Message);
            }

            
        }
    }
}
