using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        public class ReservedAutomobile : AutomobileDecorator
        {
            public ReservedAutomobile(Automobile p)
            : base(p.status + " ЗАРЕЗЕРВИРОВАННЫЙ", p)
            { }
            public override object Clone()
            {
                return new SpecialPurposeAutomobile(automobile);
            }
            public override string Move()
            {
                automobile.Move();
                return " for reservation";
            }
            public override void SetAdd(string addition)
            {
                automobile.SetAdd(addition);
            }
        }
    }

}
