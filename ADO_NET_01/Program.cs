using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var sqlstringBuilder = new SqlConnectionStringBuilder();
            sqlstringBuilder["Server"] = "192.168.1.2,1433";
            sqlstringBuilder["Database"] = "xtlab";
            sqlstringBuilder["UID"] = "sa";
            sqlstringBuilder["PWD"] = "123456";

            var sqlStringConnection = sqlstringBuilder.ToString();
            Console.WriteLine(sqlStringConnection);

            //string sqlStringConnection = "Data Source=192.168.1.2,1433;Initial Catalog=xtlab;User ID=sa;Password=123456;";
            using (var connection = new SqlConnection(sqlStringConnection))
            {
                Console.WriteLine(connection.State);

                connection.Open();

                Console.WriteLine(connection.State);

                using (DbCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP (10) * FROM Sanpham";
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"{dataReader["TenSanpham"],10} Gia {dataReader["Gia"],8}");
                    }
                }

                connection.Close();
            }*/

            var sqlstringBuilder = new MySqlConnectionStringBuilder();
            sqlstringBuilder["Server"] = "192.168.1.2";
            sqlstringBuilder["Database"] = "xtlab";
            sqlstringBuilder["UID"] = "root";
            sqlstringBuilder["PWD"] = "123456";
            sqlstringBuilder["Port"] = "3306";

            var sqlStringConnection = sqlstringBuilder.ToString();
            Console.WriteLine(sqlStringConnection);

            //string sqlStringConnection = "Data Source=192.168.1.2,1433;Initial Catalog=xtlab;User ID=sa;Password=123456;";
            using (var connection = new MySqlConnection(sqlStringConnection))
            {
                Console.WriteLine(connection.State);

                connection.Open();

                Console.WriteLine(connection.State);

                using (DbCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Sanpham Limit 0, 10";
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"{dataReader["TenSanpham"],10} Gia {dataReader["Gia"],8}");
                    }
                }

                connection.Close();
            }

        }
    }
}
