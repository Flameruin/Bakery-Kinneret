using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test5.Models;

namespace test5.Controllers
{
    public class PeopleController : Controller
    {
        
        // GET: People
        public ActionResult Index()
        {
            return View();
        }
        
        

        public ActionResult ListPeople()
        {
            List<PersonModel> people = new List<PersonModel>();
            people.Add(new PersonModel { FirstName = "dekel", LastName = "moshe", Age = 25 });
            people.Add(new PersonModel { FirstName = "nisim", LastName = "zo", Age = 25 });
            people.Add(new PersonModel { FirstName = "bob", LastName = "aln", Age = 25 });
            return View(people);
        }
    }
}