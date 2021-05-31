using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        public interface IDriver
        {
            string DrivingCar();
        }
        [Serializable]
        public class DriverInfo: IDriver
        {
            public string firstName;
            public string secondName;
            public string age;
            public string profession;
            public string DrivingCar()
            {
                return "Водитель управляет машиной";
            }
        }
    }
}
