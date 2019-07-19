using CarQuote.VieModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarQuote.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarinsuranceEntities db = new CarinsuranceEntities())
            {
              
                var finalQuote = db.Cars;
                var QuoteVM = new List<CarInsuranceVM>();
                foreach (var quote in finalQuote)
                {
                    var carVM = new CarInsuranceVM();
                    carVM.FirstName = quote.FirstName;
                    carVM.LastName = quote.LastName;
                    carVM.EmailAddress = quote.EmailAddress;
                    carVM.DateOfBirth = quote.DateOfBirth.Value;
                    carVM.CarYear = quote.Caryear.Value;
                    carVM.CarMake = quote.Carmake;
                    carVM.CarModel = quote.Carmodel;
                    carVM.CoverageType = quote.CoverageType;
                   
                    if (quote.DUI.HasValue == true)
                    {
                        carVM.DUI = quote.DUI.Value;
                    }
                    else
                    {
                        carVM.DUI = false;
                    }

                    if (quote.NumberofspeedingTickets != 0)
                    { carVM.SpeedingTickets = quote.NumberofspeedingTickets.Value; }
                    else
                        carVM.SpeedingTickets = 0;


                    carVM.quote();
                    QuoteVM.Add(carVM);


                }
                return View(QuoteVM);
            }
        }
    }
}