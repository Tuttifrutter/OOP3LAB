using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        public class TaxiCar : PassengerCar
        {
            public TaxiCar()
            {
                name = "Машина такси";
            }
            public string taximeter_model;
            public override string Type { get { return "Automobile.PassengerCar.TaxiCar"; } }
            public override string Move()                                       
            {
                return "Passenger car running...";
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    taximeter_model = addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim();
                }
                catch
                {
                    taximeter_model = "vol 4.1";
                }
                finally
                {
                    Add = "Модель таксометра = "+ taximeter_model + ";";
                }
            }
            public override object Clone()
            {
                return new TaxiCar();
            }
        }
    }
}
