using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class Trolleybus : Bus
        {
            public Trolleybus()
            {
                name = "Троллейбус";
            }
            public int trolley_pole_length;
            public override string Type { get { return "Automobile.Trolleybus"; }}
            public override string Move()
            {
                return "Trolleybus running...";
            }
            public void MainsPowerSupply()
            {
                Console.WriteLine("Trolleybus charging...");
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    trolley_pole_length = Convert.ToInt32(addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim());
                }
                catch
                {
                    trolley_pole_length = 5;
                }
                finally
                {
                    Add = "Длинна штанги = "+ trolley_pole_length + ";";
                }
            }
            public override object Clone()
            {
                return new Trolleybus();
            }
        }
    }
}
