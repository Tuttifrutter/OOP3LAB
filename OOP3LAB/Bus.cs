using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class Bus : Automobile
        {
            public Bus()
            {
                name = "Автобус";
            }
            public int count_of_seats;
            public override string Type { get { return "Automobile.Bus"; } }
            public override string Move()
            {
                return "Bus running...";
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    count_of_seats = Convert.ToInt32(addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim());
                }
                catch
                {
                    count_of_seats = 44;
                }
                finally
                {
                    Add = "Кол-во мест = " + count_of_seats+";";
                }
            }
            public override object Clone()
            {
                return new Bus();
            }
        }
    }
}
