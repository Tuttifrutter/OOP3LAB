using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable] 
        public class PassengerCar : Automobile
        {
            public PassengerCar()
            {
                name = "Пассажирский автомобиль";
            }
            public override string Type { get { return "Automobile.PassengerCar"; } }
            public int passengerscount;
            public override string Move()
            {
                return "Passenger car running...";
            }
            public override void SetAdd(string addition)
            {
                try
                {
                    passengerscount = Convert.ToInt32(addition.Substring(addition.IndexOf("=") + 1, addition.IndexOf(";") - addition.IndexOf("=") - 1).Trim());
                }
                catch
                {
                    passengerscount = 4;
                }
                finally
                {
                    Add = "Количество пассажирских мест = " + passengerscount.ToString() + ";";
                }
            }
            public override object Clone()
            {
                return new PassengerCar();
            }
        }
    }
}
