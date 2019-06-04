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

        private string name;
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
        /// <param name="_name">Название самолёта</param>
        public Plane(string _name, double _speed, double WingS)
        {
            speed = _speed;
            wingspan = WingS;
            name = _name;
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

        public virtual string information()
        {
            return $"Название: {Name}, Скорость: {Speed} км/ч  ,Размах крыла: {Wingspan} (метр.) ";
            
        }
    }
    
    internal class Warplane : Plane
    {
        public void Serialize(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            Speed = Convert.ToInt32(reader["Speed"]);
            Wingspan = Convert.ToInt32(reader["Wingspan"]);
        }
        private int N_weapons;
        private bool RLS;
        public int N_weapons1 { get => N_weapons; set => N_weapons = value; }
        public bool RLS1 { get => RLS; set => RLS = value; }
        public Warplane() : base() { }
        public Warplane(int n_weapons, bool radio, string _name, double _speed, double WingS) : base(_name,_speed, WingS)
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
        public Plane_fighter(SqlDataReader reader) : base()
        {
            Serialize(reader);
        }
        public Plane_fighter(int n_weapons, bool radio, string _name, double _speed, double WingS, string Type = "Fighter") : base(n_weapons,radio, _name, _speed,WingS)
        {
            n_weapons = 1;
            radio = false;
            _name = null;
            _speed = 100;
            WingS = 1;
            type = Type;
        }
        public override string information()
        {
            return base.information() + $"Тип: {type}";
        }
    }
    
    class Plane_carrier : Warplane
    {
        private string type;
        
        public Plane_carrier(SqlDataReader reader) : base()
        {
            Serialize(reader);
        }
        public Plane_carrier(int n_weapons, bool radio, string _name, double _speed, double WingS, string Type = "Carrier") : base(n_weapons, radio, _name, _speed, WingS)
        {
            n_weapons = 0;
            radio = false;
            type = Type;
            _name = null;
            _speed = 100;
            WingS = 1;
        }
        public override string information()
        {
            return base.information() + $"Тип: {type}";
        }
    }
}
