using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class PoliceCar : PassengerCar
        {
            public PoliceCar()
            {
                name = "Полицейская машина";
            }
            public string police_radio_model;
            public override string Type { get { return "Automobile.PassengerCar.PoliceCar"; }}
            public override string Move()
            {
                return "Police car running...";
            }
            public void CriminalTransportation()
            {
                Console.WriteLine("You're under arrest");
            }
            public override void SetAdd(string addition)
            { 
                try
                {
                    police_radio_model = addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim();
                }
                catch
                {
                    police_radio_model = "vol 4.1";
                }
                finally
                {
                    Add = "Модель автомобильного радио = "+ police_radio_model + ";";
                }
            }
            public override object Clone()
            {
                return new PoliceCar();
            }
        }
    }
}
