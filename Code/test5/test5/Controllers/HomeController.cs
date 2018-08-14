using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test5.Models;
using System.Web.Helpers;

namespace test5.Controllers
{
    public class HomeController : Controller
    {
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
        // GET: CakeTables
        public ActionResult Index()
        {
            CakeTablesController cakeTablesController = new CakeTablesController();
            var sensitivity = from m in cakeTablesController.db.Table
                              select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    sensitivity = sensitivity.Where(m => !m.IsSensitive.Contains(searchString));
            //}
            return View(sensitivity.ToList());
            // return View(db.Table.ToList());
        }

        public ActionResult About()
        {
          //  ViewBag.Message = "Your application description page."; //catch this messge from the view

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery(string searchString1, string searchString2)
        {
            CakeTablesController cakeTablesController = new CakeTablesController();
            var sensitivity = from m in cakeTablesController.db.Table
                              select m;

            if (!String.IsNullOrEmpty(searchString1))
            {
                sensitivity = sensitivity.Where(m => !m.IsSensitive.Contains(searchString1));
            }
            else if(!String.IsNullOrEmpty(searchString2))
            {
                sensitivity = sensitivity.Where(m => m.Size.Contains(searchString2));
            }

            return View(sensitivity.ToList());
           
        }
        public ActionResult SendEmail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(EmployeeModel obj)
        {
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "dekelfake@gmail.com";
                WebMail.Password = "Dekel123";

                //Sender email address.  
                WebMail.From = "dekelfake@gmail.com";

                string emailBody = "האימייל/טלפון נשלח מהכתובת" + " " + obj.EmailToReturn + "<br>" + obj.EMailBody;
               
                //Send email  
                WebMail.Send(to: "dekelfake@gmail.com", subject: obj.EmailSubject, body: emailBody, cc: obj.EmailCC, bcc: obj.EmailBCC, isBodyHtml: true);
                ViewBag.Status = "ההודעה נשלחה בהצלחה.";
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }
            return View();
        }

    }
}