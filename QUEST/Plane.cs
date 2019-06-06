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
            name = null;
            speed = 0;
            wingspan = 0;
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
        public virtual void Serialize(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            Speed = Convert.ToDouble(reader["Speed"]);
            Wingspan = Convert.ToDouble(reader["Wingspan"]);
        }
        public virtual string information()
        {
            return $"Название: {Name}, Скорость: {Speed} км/ч  ,Размах крыла: {Wingspan} (метр.) ";
            
        }
    }
    internal class Warplane : Plane
    {
        private int N_weapons;
        private bool RLS;
        public int N_weapons1 { get => N_weapons; set => N_weapons = value; }
        public bool RLS1 { get => RLS; set => RLS = value; }
        public Warplane() : base()
        {
            N_weapons = 1;
            RLS = false;
        }
        public Warplane(int n_weapons, bool radio, string _name, double _speed, double WingS) : base(_name,_speed, WingS)
        {
            N_weapons = n_weapons;
            RLS = radio;
        }
        public override void Serialize(SqlDataReader reader)
        {
            base.Serialize(reader);
            N_weapons = Convert.ToInt32(reader["Weapons"]);
            RLS = Convert.ToBoolean(reader["RLS"]);
        }
        public override string information()
        { 
            return base.information() + $"\n Кол-во подвесного вооружения: {N_weapons1} ,Радиолокационная станция: {RLS1}";
        }
      
    }
    class Plane_fighter : Warplane
    {
        private string type;
        public Plane_fighter():base()
        {  
            type = "Plane_fighter";
        }
        public Plane_fighter(int n_weapons, bool radio, string _name, double _speed, double WingS) : base(n_weapons,radio, _name, _speed,WingS)
        { 
        }
        public Plane_fighter(SqlDataReader reader) : base()
        {
            Serialize(reader);
        }
        public override void Serialize(SqlDataReader reader)
        {
            base.Serialize(reader);
            type = reader["Type"].ToString();
        }
        public override string information()
        {
            return base.information() + $"Тип: {type}";
        }
    }
    
    class Plane_carrier : Warplane
    {
        private string type;
        public Plane_carrier():base()
        {
            type = "Plane_carrier";
            
        }
        public Plane_carrier(int n_weapons, bool radio, string _name, double _speed, double WingS) : base(n_weapons, radio, _name, _speed, WingS)
        {
        }
        public Plane_carrier(SqlDataReader reader) : base()
        {
            Serialize(reader);
        }
        public override void Serialize(SqlDataReader reader)
        {
            base.Serialize(reader);
            type = reader["Type"].ToString();
        }
        public override string information()
        {
            return base.information() + $"Тип: {type}";
        }
    }
}
