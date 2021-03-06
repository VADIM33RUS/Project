﻿#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

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
            connect.Dispose();//Этой командой мы говорим, что больше объект использоваться нами не будет
        }
        /// <summary>
        /// Метод создан для получения списка и добавления в него по Type нового объекта
        /// </summary>
        /// <param name="Spisok">Список самолётов</param>
        public List<Plane> GetPlanes()
        {
            var plane = new List<Plane>();
            using (SqlCommand command = new SqlCommand(@"SELECT Id,Name,Type,Weapons,Wingspan,Speed,RLS FROM [Planes_selector]", connect))
            {
                using (var reader = command.ExecuteReader())
                {
                    Plane p = null;
                    while (reader.Read())
                    {
                        switch (reader["Type"])
                        {
                            case "Plane_fighter":
                                {
                                    p = new Plane_fighter();
                                    break;
                                }
                            case "Plane_carrier":
                                {
                                    p = new Plane_carrier();
                                    break;
                                }
                        }
                        p.Serialize(reader);
                        plane.Add(p);
                    }
                }
            }
            return plane;
        }
        /// <summary>
        /// Метод создан для вывода информации из БД
        /// </summary>
#if DEBUG
        public void Output()
        {

            SqlCommand command = new SqlCommand(@"SELECT Id,Name,Type,Weapons,Wingspan,Speed,RLS FROM [Table]", connect);
            using (var reader = command.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\n\n", "Id", "Name", "Type", "Wingspan", "Weapons", "Speed", "RLS");
                    while (reader.Read())
                    {
                        var Id = reader["Id"];
                        var Name = reader["Name"];
                        var Type = reader["Type"];
                        var Wingspan = reader["Wingspan"];
                        var Weapons = reader["Weapons"];
                        var Speed = reader["Speed"];
                        var RLS = reader["RLS"];
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", Id, Name, Type, Wingspan, Weapons, Speed, RLS);
                    }
                }
            }
            command.Dispose();
        }
#endif
    }
}
