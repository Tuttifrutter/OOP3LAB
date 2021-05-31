using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class ArmoredCar : Truck
        {
            public ArmoredCar()
            {
                name = "Бронеавтомобиль";
            }
            public string installed_armament;
            public override string Type { get { return "Automobile.Truck.ArmoredCar"; } }
            public override string Move()
            {
                return "Tanker truck running...";
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    installed_armament = addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim();
                }
                catch
                {
                    installed_armament = "водомет";
                }
                finally
                {
                    Add = "Установленное вооружение = " + installed_armament + ";";
                }
            }
            public override object Clone()
            {
                return new ArmoredCar();
            }
        }
    }
}
