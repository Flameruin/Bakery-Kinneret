using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test5.Models;

namespace test5.Controllers
{
    public class CakeController : Controller
    {
        // GET: Cake
        public ActionResult Index()
        {
            List<Cake> cakes = new List<Cake>();
            cakes.Add(new Cake { CakeName = "Dekel cake", Description = "yum yum", IsSensitive = "false", Image = @"~/Pics/pic1.jpg" });
            cakes.Add(new Cake { CakeName = "Chase cake", Description = "yum yum", IsSensitive = "false", Image = @"~/Pics/pic2.jpg" });
            cakes.Add(new Cake { CakeName = "Neriya cake", Description = "yum yum", IsSensitive = "true", Image = @"~/Pics/pic3.jpg" });
            return View(cakes);
        }
    }
}