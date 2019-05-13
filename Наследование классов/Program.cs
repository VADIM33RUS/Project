using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наследование_классов
{
    
    class Program
    {
        static void Main()
        {
            List<Plane> planes = new List<Plane>();
            planes.Add(new Plane_fighter("СУ-57", 9, true, 3000, 14));
            planes.Add(new Plane_carrier("АН-26",0,true, 540,29.2));
            planes.Add(new Plane_fighter("ЛА-5", 3, false, 648, 9.8));
            planes.Add(new Plane_carrier("ЛИ-2", 4, false, 290, 29.98));
            for (int i = 0; i < planes.Count(); i++)
            {
                Console.WriteLine(planes[i].information() + "\n");
            }
            Console.ReadKey();
        }
    }
}
