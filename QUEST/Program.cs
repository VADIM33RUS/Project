using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace class_inheritance
{
    
    class Program
    {
        
        static void Main()
        {
            try
            {
                var db = new DB();
                db.Connection();
                foreach (Plane p in db.GetPlanes())
                {
                    Console.WriteLine(p.information());
                }
                db.CloseConnection();
                Console.ReadKey();
            }
            catch(SqlException sex)
            {
                Console.WriteLine("Произошла ошибка, перезапустите БД или измените путь к файлу\n\n" + sex.ToString());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Programm: Damn it. Sorry, my Creator is too dumb to handle this exception.\n\n" + ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
//var planes = new List<Plane>
//{
//    new Plane_fighter("СУ-57", 9, true, 3000, 14),
//    new Plane_carrier("АН-26", 0, true, 540, 29.2),
//    new Plane_fighter("ЛА-5", 3, false, 648, 9.8),
//    new Plane_carrier("ЛИ-2", 4, false, 290, 29.98)
//};
//foreach (var p in planes)
//{
//    Console.WriteLine(p.information() + "\n");
//}
//Console.ReadKey();
//Console.Clear();