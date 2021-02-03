using MySql.Data.MySqlClient;
using System;

namespace NapelliFrameWork
{
    public class Connection
    {
        private static String ConnectionString { get; set; }
        private static MySqlConnection Conn { get; set; }

        private static String GetConnectionString()
        {
            ConnectionString = "server = localhost; database = vcr_napelli; user id = root; password = root"; /* Connection;*/
            return ConnectionString;
        }
        public static MySqlConnection GetConnection()
        {
            GetConnectionString();
            Conn = new MySqlConnection(ConnectionString);
            return Conn;
        }
    }
}
