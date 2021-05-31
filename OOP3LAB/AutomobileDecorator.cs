namespace OOP3LAB
{
    public partial class Form1
    {
        public abstract class AutomobileDecorator : Automobile
        {
            public Automobile automobile; 
            public AutomobileDecorator(string n, Automobile automobile)
            { 
                this.automobile = automobile;
                automobile.status = n ;
            }
        }
    }

}
