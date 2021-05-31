using System;

namespace OOP3LAB
{
    public class TechnicalInspectionFacade
    {
        HeadOfTheComission comissionHead;
        Electrician electrician;
        Mechanic mechanic;

        public TechnicalInspectionFacade(HeadOfTheComission h, Electrician e, Mechanic m)
        {
            comissionHead = h;
            electrician = e;
            mechanic = m;
        }
        public string MakeTechnicalInspection()
        {
            DateTime dateTime = DateTime.Now;
            return mechanic.CheckingTheOperationOfTheBrakeSystem() +
            mechanic.CheckingTheOperationOfTheSteering() +
            electrician.AdjustmentOfHeadlightsAndTurnSignals() +
            electrician.CheckingTheSoundSignal() +
            comissionHead.CheckingTheContentOfCarbonDioxideInTheExhaust() +
            comissionHead.CheckingTheEmergencyKit() +
            comissionHead.CheckingTheLightTransmissionOfGlass() +
            comissionHead.CheckingTheOperationOfTheWiperAndWasher() +
            comissionHead.CheckingTiresAndTreadWear() +
            "Технический осмотр пройден: " + dateTime.ToString("dd.MM.yyyy") + ".";
        }
    }
}
