using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarQuote.VieModel
{
    public class CarInsuranceVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public bool DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public string CoverageType { get; set; }
        public double Total { get; set; }

        public double quote()
        {
            int baseMoney = 50;
            int agemoney = 0;
            int yearMoney = 0;
            int carmakemoney = 0;
            double total = 0;

            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (age < 25 && age > 18)
            {
                agemoney += 25;
            }
            else if (age < 18)
            {
                agemoney += 100;
            }
            else if (age > 100)
            {
                agemoney += 25;
            }

            if (CarYear > 2015)
            {
                yearMoney += 25;
            }

            else if (CarYear < 2000)
            {
                yearMoney += 25;
            }
            if (CarMake == "Porsche")
            {
                carmakemoney += 25;
                if (CarModel == "911 carrera")
                {
                    carmakemoney += 25;
                }
            }
            total = baseMoney + agemoney + carmakemoney + yearMoney;

            if (SpeedingTickets > 0)
            { total += 10 * SpeedingTickets; }

            if (DUI)
            {
                total += (total *0.25);

            }

           
            if (CoverageType.ToLower() == "full")
            {
                total += (total * 0.5);
            }

            Total = Math.Round(total,2);
            return Total;
        }
    }
}
    
   