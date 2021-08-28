using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace app_mysql
{
    public class DBConnect
    {
        public MySqlConnection connection;
 

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connStr = "server=localhost;user=root;database=pruebacsharp;port=3306;password='';SSL Mode=0";
			connection = new MySqlConnection(connStr);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                Debug.WriteLine("[MySQL] MySQL connection established...");
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Debug.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Debug.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

    }
}