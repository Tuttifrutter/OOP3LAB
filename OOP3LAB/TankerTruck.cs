using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class TankerTruck : Truck
        {
            public TankerTruck()
            {
                name = "Автоцистерна";
            }
            public string transported_liquid;
            public override string Type { get { return "Automobile.Truck.TankerTruck"; } }
            public override string Move()
            {
                return "Tanker truck running...";
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    transported_liquid = addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim();
                }
                catch
                {
                    transported_liquid = "нефть";
                }
                finally
                {
                    Add = "Перевозимая жидкость = "+ transported_liquid + ";";
                }
            }
            public override object Clone()
            {
                return new TankerTruck();
            }
        }
    }
}
