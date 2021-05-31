using System;
using System.Xml.Serialization;

namespace OOP3LAB
{
    public partial class Form1
    {
        [Serializable]
        [XmlInclude(typeof(Truck)), XmlInclude(typeof(FireTruck)), XmlInclude(typeof(TankerTruck)), XmlInclude(typeof(GarbageTruck)), XmlInclude(typeof(ArmoredCar)), XmlInclude(typeof(PassengerCar)), XmlInclude(typeof(PoliceCar)), XmlInclude(typeof(TaxiCar)), XmlInclude(typeof(Bus)), XmlInclude(typeof(Trolleybus)),]
        public abstract class Automobile : ICloneable
        {
            public Automobile() { }
            public Automobile(string name)
            {
                this.status = name;
            }
            public string name;
            public virtual string Type { get;}
            public string Mark { get; set; }
            public string Model { get; set; }
            public DriverInfo Driver { get; set; }
            public string Color { get; set; }
            public abstract string Move();
            public void DriveBy(IDriver driver)
            {
                driver.DrivingCar();
            }
            public string status;
            public void MakeTechnicalInspection()
            {
                TechnicalInspectionFacade technicalInspectionFacade = new TechnicalInspectionFacade(new HeadOfTheComission(), new Electrician(), new Mechanic());
                status = technicalInspectionFacade.MakeTechnicalInspection();
            }
            public abstract object Clone();
            public virtual string Add { get; set; }
            public abstract void SetAdd(string addition); 
        }
    }

}
