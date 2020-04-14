using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;



namespace connection_example
{
    class connection
    {
        public void Mssql()
        {
            try
            {
                string connectString = "Server=FR-310-20\\SQLEXPRESS;"
                                                 + "uid=PIS;" + "pwd=qkrdlstjs;"
                                                 + "database=TSQL2012;";                
                SqlConnection Conn = new SqlConnection(connectString);
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("select * from dbo.Customers",Conn);
                Conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                    Console.WriteLine(dr.GetInt32(0) + " " + dr.GetString(1) +
                                " " + dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4));
                dr.Close();
                Conn.Close();

            }
            catch (Exception DE)
            {
                Console.WriteLine(DE.Message);
                Console.WriteLine(DE.Source);
                Console.WriteLine(DE.StackTrace);
            }
        }
    }
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            connection co = new connection();

            co.Mssql();
        }
    }

}
