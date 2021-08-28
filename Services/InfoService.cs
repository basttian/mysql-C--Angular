using app_mysql.Models;
using System.Collections.Generic;
using System.Linq;

using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace app_mysql.Services
{

    public class InfoService
    {

        static List<Info> Infos { get; set; }
        //static int nextId = 1;

        static InfoService()
        {
			Infos = new List<Info>{};
			todo();
        }

        public static List<Info> GetAll() => Infos;

        public static Info Get(int id) => Infos.FirstOrDefault(p => p.id == id);

        public static void Add(Info info)
        {
            //info.id = nextId++;
            //Infos.Add(info);
			
			DBConnect conn = new DBConnect();
			if (conn.OpenConnection() == true)
			{
				string sql = "INSERT INTO tableinfo (name, age) VALUES('" +@info.name+ "','" +@info.age+ "');";
				MySqlCommand cmd = new MySqlCommand(sql,  conn.connection);
				cmd.ExecuteNonQuery();
				conn.CloseConnection();
				Infos.Clear();
				todo();
			};

        }


        public static void Delete(int id)
        {
            /*var info = Get(id);
            if(info is null)
                return;
            Infos.Remove(info);*/

			DBConnect conn = new DBConnect();
			if (conn.OpenConnection() == true)
			{
				string sql = "DELETE FROM tableinfo WHERE id='"+@id+"'";
				MySqlCommand cmd = new MySqlCommand(sql,  conn.connection);
				cmd.ExecuteNonQuery();
				Infos.Clear();
				todo();
				conn.CloseConnection();
			};


        }

        public static void Update(Info info)
        {
            /*var index = Infos.FindIndex(p => p.id == info.id);
            if(index == -1)
                return;
            Infos[index] = info;*/

			DBConnect conn = new DBConnect();
			if (conn.OpenConnection() == true)
			{
				string sql = "UPDATE tableinfo SET name='"+@info.name+"', age='"+@info.age+"' WHERE id='"+@info.id+"'";
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandText = sql;
				cmd.Connection = conn.connection;
				cmd.ExecuteNonQuery();
				Infos.Clear();
				todo();
				conn.CloseConnection();
			};

        }


		public static void todo(){
			DBConnect conn = new DBConnect();
			if (conn.OpenConnection() == true)
			{
				string sql = "SELECT * FROM tableinfo";
				MySqlCommand cmd = new MySqlCommand(sql, conn.connection);
				MySqlDataReader rdr = cmd.ExecuteReader();

					while (rdr.Read())
					{
						Infos.Add(new Info{
							id=Convert.ToInt32(rdr[0]),
							name=rdr[1].ToString(),
							age=Convert.ToInt32(rdr[2])
						});
					}

				rdr.Close();
				conn.CloseConnection();
			}
		}



    }
}