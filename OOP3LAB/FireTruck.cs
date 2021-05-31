using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class FireTruck : Truck
        {
            public FireTruck()
            {
                name = "Пожарная машина";
            }
            public int liquad_volume;
            public override string Type { get { return "Automobile.Truck.FireTruck"; } }
            public override string Move()
            {
                return "Fire truck running...";
            }
            public void FireFighting()
            {
                Console.WriteLine("pshhhhhhhhhhhhh");
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    liquad_volume = Convert.ToInt32(addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim());
                }
                catch
                {
                    liquad_volume = 3000;
                }
                finally
                {
                    Add = "Объем вмещаемой воды(л) = "+ liquad_volume + ";";
                }
            }
            public override object Clone()
            {
                return new FireTruck();
            }
        }
    }
}
