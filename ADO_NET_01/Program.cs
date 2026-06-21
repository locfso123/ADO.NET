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
            var sqlstringBuilder = new SqlConnectionStringBuilder();
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
                    command.CommandText = "getproductinfo";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var id = new SqlParameter("@id", 0);
                    command.Parameters.Add(id);

                    id.Value = 3;

                    var reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        reader.Read();
                        var tensp = reader["TenSanPham"];
                        var tendm = reader["TenDanhMuc"];

                        Console.WriteLine($"{tensp} - {tendm}");
                    }



                   /* var danhmuchid = new SqlParameter("@DanhmuchID", 5);
                    command.Parameters.Add(danhmuchid);*/

                    /*var kq = command.ExecuteNonQuery();
                    Console.WriteLine(kq);*/

                    /*// danhmuchid.Value = 2;
                    var hoten = new SqlParameter("@Hoten", "");
                    command.Parameters.Add(hoten);
                    var sodienthoai = new SqlParameter("@Sodienthoai", "");
                    command.Parameters.Add(sodienthoai);

                    for (int i = 0; i < 4; i++)
                    {
                        hoten.Value = "HoTen " + i;
                        sodienthoai.Value = "213213" + i;

                        var kq = command.ExecuteNonQuery();
                        Console.WriteLine(kq);
                    }*/

                   /* var returnvalue = command.ExecuteScalar();
                    Console.WriteLine(returnvalue);*/

                    /* var sqlreader = command.ExecuteReader();
                     if(sqlreader.HasRows) 
                     {
                         while (sqlreader.Read())
                         {
                             var id = sqlreader.GetInt32(0);
                             var ten = sqlreader["TenDanhMuc"];
                             var mota = sqlreader[2];

                             Console.WriteLine($"{id} - {ten} -{mota}");

                             //Console.WriteLine($"{sqlreader["TenSanpham"],10} Gia {sqlreader["Gia"],8}");
                         }
                     }
                     else
                     {
                         Console.WriteLine("Khong co du lieu");
                     }*/


                }
                connection.Close();
            }

            /*var sqlstringBuilder = new MySqlConnectionStringBuilder();
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
            }*/

        }
    }
}
