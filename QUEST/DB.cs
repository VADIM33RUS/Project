using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace class_inheritance
{
    class DB
    {

        private SqlConnection connect;
        public DB()
        {
            if (connect == null || connect.State == System.Data.ConnectionState.Closed)
            {
                Connection();
            }
            else
            {
                Console.WriteLine("Подключение уже установлено");
            }

        }
        public void Connection()
        {
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Project\QUEST\Database1.mdf;Integrated Security=True");
            connect.Open();
        }
        public void CloseConnection()
        {
            connect.Close();
            connect.Dispose();
        }
        public void GetValue(List<Plane> Spisok)
        {
            SqlCommand command = new SqlCommand(@"SELECT ID,Name,Type,Weapons,Wingspan,Speed,RLS FROM [Table]", connect);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                        switch (reader.GetValue(2))
                        {
                            case "Plane_fighter":
                                {
                                    Spisok.Add(new Plane_fighter(reader));
                                    break;
                                }
                            case "Plane_carrier":
                                {
                                    Spisok.Add(new Plane_carrier(reader));
                                    break;
                                }
                        }
                }
            }
            command.Dispose();
        }
        public void Output()
        {
            
            SqlCommand command = new SqlCommand(@"SELECT ID,Name,Type,Weapons,Wingspan,Speed,RLS FROM [Table]", connect);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\n\n", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6));
                    while (reader.Read())
                    {
                        var Id = reader.GetValue(0);
                        var Name = reader.GetValue(1);
                        var Type = reader.GetValue(2);
                        var Wingspan = reader.GetValue(3);
                        var Weapons = reader.GetValue(4);
                        var Speed = reader.GetValue(5);
                        var RLS = reader.GetValue(6);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", Id, Name, Type, Wingspan, Weapons, Speed, RLS);
                    }
                }
            }
            command.Dispose();
        }
    }
}
