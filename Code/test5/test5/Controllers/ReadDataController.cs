using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace test5.Controllers
{
    public class ReadDataController : Controller
    {
        // GET: ReadData
        public ActionResult Index()
        {
            string text = "";
            // Open the file to read from. 
            // string path = @"C:\Users\Dekel\source\repos\test5\test5\App_Data\DataText.txt"; //its static right now - need to fix
           string path = Server.MapPath(@"App_Data\DataText.txt");

            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string s = "";

                while ((s = reader.ReadLine()) != null)
                {
                    text += s;
                }
            }

            return View((object)text);
        }
    }
}