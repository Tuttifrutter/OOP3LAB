namespace OOP3LAB
{
    public partial class Form1
    {
        // Адаптер от Drone к IDriver
        class DroneToDriverAdapter : IDriver
        {
            Drone drone;
            public DroneToDriverAdapter(Drone d)
            {
                drone = d;
            }
            public string DrivingCar()
            {
                return drone.CarControl();
            }
        }
    }
}
