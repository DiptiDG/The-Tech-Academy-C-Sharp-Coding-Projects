using CarQuote.Models;
using CarQuote.VieModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarQuote.Controllers
{
    public class HomeController : Controller
    {
     //  private readonly string connectionString = @"Data Source=LAPTOP-N50USG3R\SQLEXPRESS;Initial Catalog=Carinsurance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Signup(string firstname, string lastname, string emailaddress, DateTime dateofbirth, int caryear, string carmake, string carmodel, 
            bool? dui, int? speedingTickets, string coverageType)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(emailaddress) || string.IsNullOrEmpty((dateofbirth).ToString())
                      || string.IsNullOrEmpty(caryear.ToString()) || string.IsNullOrEmpty(carmodel) || string.IsNullOrEmpty(carmake) || dui == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarinsuranceEntities db = new CarinsuranceEntities())
                {
                    var carqoute = new Car();
                    carqoute.FirstName = firstname;
                    carqoute.LastName = lastname;
                    carqoute.EmailAddress = emailaddress;
                    carqoute.DateOfBirth = dateofbirth;
                    carqoute.Caryear = caryear;
                    carqoute.Carmodel = carmodel;
                    carqoute.Carmake = carmake;
                    carqoute.DUI = dui;
                    carqoute.NumberofspeedingTickets = speedingTickets;
                    carqoute.CoverageType = coverageType;
               

                    db.Cars.Add(carqoute);
                    db.SaveChanges();
                }

                return RedirectToAction("Index","Admin");

            }
        }







            //    string queryString = @"Insert Into Car (FirstName, LastName, EmailAddress, DateOfBirth, Caryear, Carmodel, Carmake, bool DUI, int numberOfSpeedingTickets, string coverageType) Values(@FirstName, @LastName, @EmailAddress, @DateOfBirth, @Caryear, @Carmodel, @Carmake, @DUI, @numberofSpeedingTickets, @coverageType)";

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        SqlCommand command = new SqlCommand(queryString, connection);

            //        command.Parameters.Add("@FirstName", SqlDbType.VarChar);
            //        command.Parameters.Add("@LastName", SqlDbType.VarChar);
            //        command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
            //        command.Parameters.Add("@DateOfBirth", SqlDbType.Date);
            //        command.Parameters.Add("@Caryear", SqlDbType.Int);
            //        command.Parameters.Add("@Carmodel", SqlDbType.VarChar);
            //        command.Parameters.Add("@Carmake", SqlDbType.VarChar);
            //        command.Parameters.Add("@DUI", SqlDbType.VarChar);
            //        command.Parameters.Add("@numberofSpeedingTickets", SqlDbType.Int);
            //        command.Parameters.Add("@coveragType", SqlDbType.VarChar);


            //        command.Parameters["@FirstName"].Value = firstname;
            //        command.Parameters["@LastName"].Value = lastname;
            //        command.Parameters["@EmailAddress"].Value = emailaddress;
            //        command.Parameters["@DateOfBirth"].Value = dateofbirth;
            //        command.Parameters["@Caryear"].Value = caryear;
            //        command.Parameters["@Carmodel"].Value = carmodel;
            //        command.Parameters["@Carmake"].Value = carmake;
            //        command.Parameters["@DUI"].Value = dui;
            //        command.Parameters["@numberofSpeedingTickets"].Value = numberOfSpeedingTickets;
            //        command.Parameters["@coveragType"].Value = coverageType;


            //        connection.Open();
            //        command.ExecuteNonQuery();
            //        connection.Close();
            //    }
            //    return RedirectToAction("Admin");
            //}

            //string queryString = @"SELECT * FROM Car";
            //List<CarInsuranceQuote> finalQuote = new List<CarInsuranceQuote>();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        var carQuote = new CarInsuranceQuote();

            //        carQuote.Id = Convert.ToInt32(reader["Id"]);
            //        carQuote.FirstName = reader["Firstname"].ToString();
            //        carQuote.LastName = reader["Lastname"].ToString();
            //        carQuote.EmailAddress = reader["EmailAddress"].ToString();
            //        carQuote.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]).Date;
            //        carQuote.CarMake = reader["CarMake"].ToString();
            //        carQuote.CarModel = reader["CarModel"].ToString();
            //        carQuote.CarYear = Convert.ToInt32(reader["CarYear"]);
            //       // carQuote.NumberOfSpeedingTickets = Convert.ToInt32(reader["NumberOfSpeedingTickets"]);
            //      //  carQuote.DUI = Convert.ToBoolean(reader["DUI"]);
            //       // carQuote.CoverageType = reader["CoverageType"].ToString();
            //        int total = carQuote.quote();
            //        finalQuote.Add(carQuote);
            //    }

            //}



        }
    }