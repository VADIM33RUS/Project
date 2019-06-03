using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace class_inheritance
    
{
    /// <summary>
    /// Класс описывающий самолёт
    /// </summary>
    
    class Plane
    {

        
        private double speed;
        private double wingspan;
        
        public Plane()
        {
            
        }
        /// <summary>
        /// Конструктор класса Plane
        /// </summary>
        /// <param name="_speed">Максимальная скорость самолёта</param>
        /// <param name="WingS">Размах крыла самолета</param>
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
        public Warplane() : base() { }
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
        private string type;
        private string name;
        public void Serialize(SqlDataReader reader)
        {
            Name = reader.GetValue(1).ToString();
            Speed = Convert.ToInt32(reader.GetValue(5));
            Wingspan = Convert.ToInt32(reader.GetValue(3));
        }
        public Plane_fighter(SqlDataReader reader) : base()
        {
            Serialize(reader);
        }
        public Plane_fighter(string _name,int n_weapons, bool radio, double _speed, double WingS, string Type = "Fighter") : base(n_weapons,radio,_speed,WingS)
        {
            name = _name;
            type = Type;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public override string information()
        {
            return $"Название самолета: {Name} " + base.information();
        }
    }
    
    class Plane_carrier : Warplane
    {
        private string type;
        private string name;
        public void Serialize(SqlDataReader reader)
        {
            Name = reader.GetValue(1).ToString();
            Speed = Convert.ToInt32(reader.GetValue(5));
            Wingspan = Convert.ToInt32(reader.GetValue(3));
        }
        public Plane_carrier(SqlDataReader reader) : base()
        {
            Serialize(reader);
        }
        public Plane_carrier(string _name, int n_weapons, bool radio, double _speed, double WingS, string Type = "Carrier") : base(n_weapons, radio, _speed, WingS)
        {
            name = _name;
            type = Type;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public override string information()
        {
            return $"Название самолета: {Name}" + base.information();
        }
    }
}
