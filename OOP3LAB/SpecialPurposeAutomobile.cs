using System;

namespace OOP3LAB
{
    public partial class Form1
    {
        public class SpecialPurposeAutomobile : AutomobileDecorator
        {
            public SpecialPurposeAutomobile(Automobile p)
            : base(p.status + " СПЕЦИАЛЬНОГО НАЗНАЧЕНИЯ", p)
            { }
            public override object Clone()
            {
                return new SpecialPurposeAutomobile(automobile);
            }
            public override string Move()
            {
                automobile.Move();
                return " for special purpose";
            }
            public override void SetAdd(string addition)
            {
                automobile.SetAdd(addition);
            }
        }
    }

}
