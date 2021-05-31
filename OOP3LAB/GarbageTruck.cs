using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class GarbageTruck : Truck
        {
            public GarbageTruck()
            {
                name = "Муссоровоз";
            }
            public string volume_of_waste;
            public override string Type { get { return "Automobile.Truck.SnowPlow"; } }
            public override string Move()
            {
                return "Garbage truck running...";
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    volume_of_waste = addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim();
                }
                catch
                {
                    volume_of_waste = "нефть";
                }
                finally
                {
                    Add = "Перевозимая жидкость = " + volume_of_waste + ";";
                }
            }
            public override object Clone()
            {
                return new GarbageTruck();
            }
        }
    }
}
