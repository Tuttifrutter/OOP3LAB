using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        // класс беспилотника
        class Drone : IAI
        {
            public string CarControl()
            {
                return "ИИ управляет машиной";
            }
        }
    }
}
