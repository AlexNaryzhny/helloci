using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                int ch = 0;
                Console.WriteLine(
                "Enter your choice: 1-Select, 2-Delete, 3-Update, 4-Insert, 5-Call stored procedure, 0-EXIT");
                try
                {
                   ch = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numbers only.");
                    Console.ReadKey();
                }
                switch (ch)
                {
                    case 1:
                        Select();
                        break;
                    case 2:
                        Console.WriteLine("Enter TerritoryID to delete: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Delete(id);
                        break;
                    case 3:
                        Console.WriteLine("Enter TerritoryID to update: ");
                        int territoryId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new values... ");
                        Console.WriteLine("TerritoryDescription:");
                        string territoryDescription = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("RegionID:");
                        int regionId = Convert.ToInt32(Console.ReadLine());
                        Update(territoryId,territoryDescription,regionId);
                        break;
                    case 4:
                        Console.WriteLine("Enter values to insert... ");
                        Console.WriteLine("Enter TerritoryID to update: ");
                        int territoryIdIns = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("TerritoryDescription:");
                        string territoryDescriptionIns = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("RegionID:");
                        int regionIdIns = Convert.ToInt32(Console.ReadLine());
                        Insert(territoryIdIns, territoryDescriptionIns, regionIdIns);
                        break;
                    case 5:
                        Console.WriteLine("To check CustomerID enter 1, to Run Stored Procedure enter 2, 0-EXIT");
                        int c = Convert.ToInt32(Console.ReadLine());
                        switch (c)
                        {
                            case 1:
                                CheckCustId();
                                break;
                            case 2:
                                Console.WriteLine("Enter CustomerID for SP: ");
                                string orderId = Convert.ToString(Console.ReadLine().ToUpper());
                                RunStoredProcedure(orderId);
                                break;
                            case 0:
                                return;
                        }
                        break;

                    case 0:
                        return;
                }
            }
        }

        private static void Select()
        {
            string connectionString =
                @"Data Source=LEXX\sqlexpress;Initial Catalog=Northwind;"
                + "Integrated Security=true";

            string queryString = "SELECT TerritoryID, TerritoryDescription, RegionID FROM dbo.Territories";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(" ");
            }
        }

        private static void Delete(int id)
        {
            string connectionString =
                @"Data Source=LEXX\sqlexpress;Initial Catalog=Northwind;"
                + "Integrated Security=true";

            string queryString = "DELETE FROM dbo.Territories where TerritoryID ='" + id + "'";

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Deleted!");
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Not Deleted: " + ex.Message);
                }
                Console.WriteLine(" ");
            }
        }

        private static void Update(int territoryId, string territoryDescription, int regionId)
        {
            string connectionString =
                @"Data Source=LEXX\sqlexpress;Initial Catalog=Northwind;"
                + "Integrated Security=true";

            string queryString = "UPDATE dbo.Territories SET TerritoryDescription = '" + territoryDescription + "', RegionID = '" + regionId + "' where TerritoryID='" + territoryId + "'";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Updated!");
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Not updated: " + ex.Message);
                }
                Console.WriteLine(" ");
            }
        }

        private static void Insert(int territoryId, string territoryDescription, int regionId)
        {
            string connectionString =
                @"Data Source=LEXX\sqlexpress;Initial Catalog=Northwind;"
                + "Integrated Security=true";

            string queryString = "INSERT INTO dbo.Territories VALUES(" + territoryId + ", '" + territoryDescription + "'," + regionId + ")";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Inserted!");
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Not inserted: " + ex.Message);
                }
                Console.WriteLine(" ");
            }
        }

        private static void RunStoredProcedure(string orderId)
        {
            string connectionString =
                @"Data Source=LEXX\sqlexpress;Initial Catalog=Northwind;"
                + "Integrated Security=true";

            var customerOrdersOrders = new DataTable();
            using (SqlConnection connection = 
                new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand("CustOrdersOrders", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@CustomerID", SqlDbType.NChar, 5);
                parameter.Value = orderId;
                cmd.Parameters.Add(parameter);

                connection.Open();
                var dr = cmd.ExecuteReader();
                customerOrdersOrders.Load(dr);

                foreach (DataRow row in customerOrdersOrders.Rows)
                {
                    Console.WriteLine("-> OrderID: {0}, Order Date: {1}, Required Date: {2}, Shipped Date: {3}\n",
                        row["OrderID"],
                        row["OrderDate"],
                        row["RequiredDate"],
                        row["ShippedDate"]);
                }

            }

        }

        private static void CheckCustId()
        {
            string connectionString =
                @"Data Source=LEXX\sqlexpress;Initial Catalog=Northwind;"
                + "Integrated Security=true";

            string queryString = "SELECT CustomerID, CompanyName, ContactName, ContactTitle FROM dbo.Customers";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(" ");
            }
        }
    }
}
