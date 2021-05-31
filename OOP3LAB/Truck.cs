using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class Truck : Automobile
        {
            public Truck()
            {
                name = "Грузовик";
            }
            public int load_capacity;
            public override string Type { get { return "Automobile.Truck"; } }
            public override string Move()
            {
                return "Truck running...";
            }
            public override object Clone()
            {
                return new Truck();
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    load_capacity = Convert.ToInt32(addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim());
                }
                catch
                {
                    load_capacity = 1000;
                }
                finally
                {
                    Add = "Грузоподъемость(кг) = "+load_capacity+";";
                }
            }
            
        }
    }
}
