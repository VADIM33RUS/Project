using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Наследование_классов
{
    class Plane
    {
        private double speed;
        private double wingspan;
        public Plane()
        {
            speed = 0;
            wingspan = 0;
            
        }
        public Plane(double _speed, double WingS)
        {
            speed = _speed;
            wingspan = WingS;
        }
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public double Wingspan
        {
            get
            {
                return wingspan;
            }
            set
            {
                wingspan = value;
            }
        }
        public virtual string information()
        {
            return $"Скорость: {Speed} км/ч  ,Размах крыла: {Wingspan} (метр.) ";
            
        }
    }
    internal class Warplane : Plane
    {
        private int N_weapons;
        private bool RLS;
        public int N_weapons1 { get => N_weapons; set => N_weapons = value; }
        public bool RLS1 { get => RLS; set => RLS = value; }
        public Warplane(int n_weapons, bool radio,double _speed, double WingS) : base(_speed, WingS)
        {
            N_weapons = n_weapons;
            RLS = radio;
        }
        public override string information()
        { 
            return base.information() + $"\n Кол-во подвесного вооружения: {N_weapons1} ,Радиолокационная станция: {RLS1}";
        }
    }
    class Plane_fighter : Warplane
    {
        private string name;
        public Plane_fighter(string _name,int n_weapons, bool radio, double _speed, double WingS) : base(n_weapons,radio,_speed,WingS)
        {
            name = _name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

            }
        }
        public override string information()
        {
            return $"Название самолета: {Name}" + base.information();
        }
    }
    class Plane_carrier : Warplane
    {
        private string name;
        public Plane_carrier(string _name, int n_weapons, bool radio, double _speed, double WingS) : base(n_weapons, radio, _speed, WingS)
        {
            name = _name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

            }
        }
        public override string information()
        {
            return $"Название самолета: {Name}" + base.information();
        }
    }
}
