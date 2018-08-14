using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test5.Models;

namespace test5.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CakeTablesController : Controller
    {
        public CakeDbPortalEntities db = new CakeDbPortalEntities();

        // GET: CakeTables
        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            if (User.IsInRole("Administrator"))
            {
                // ...

                var sensitivity = from m in db.Table
                                  select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    sensitivity = sensitivity.Where(m => !m.IsSensitive.Contains(searchString));
                }

                return View(sensitivity.ToList());
            }
            return RedirectToAction("NotAuthorize", "Logon");
           // return View(db.Table.ToList());
        }

        // GET: CakeTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeTable cakeTable = db.Table.Find(id);
            if (cakeTable == null)
            {
                return HttpNotFound();
            }
            return View(cakeTable);
        }

        // GET: CakeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CakeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CakeName,Image,IsSensitive,Description,Size")] CakeTable cakeTable, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (cakeTable.Description != null && cakeTable.CakeName != null  && cakeTable.IsSensitive != null && cakeTable.Size != null && file.ContentLength > 0)
                    {
                        try
                        {
                            string _FileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/Pics"), _FileName);
                            file.SaveAs(_path);
                            ViewBag.Message = "File Uploaded Successfully!!";

                            cakeTable.Image = "~/Pics/" + _FileName;
                            db.Table.Add(cakeTable);
                            db.SaveChanges();
                            // TempData["msg"] = "<script>alert('return 1');</script>";  //msg for Debug
                            ViewBag.IsOk = true;
                            return RedirectToAction("Index");
                        }
                        catch
                        {
                            ViewBag.Message = "File upload failed!!";
                            ViewBag.IsOk = false;
                            return View(cakeTable);
                        }

                    }
                }
                
            }
            ViewBag.IsOk = false;
            return View(cakeTable);
        }

        // GET: CakeTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeTable cakeTable = db.Table.Find(id);
            if (cakeTable == null)
            {
                return HttpNotFound();
            }
            return View(cakeTable);
        }

        // POST: CakeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CakeName,Image,IsSensitive,Description,Size")] CakeTable cakeTable)
        {
            if (ModelState.IsValid)
            {
                if (cakeTable.Description != null && cakeTable.CakeName != null && cakeTable.Image != null && cakeTable.Size != null && cakeTable.IsSensitive != null)
                {
                    db.Entry(cakeTable).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(cakeTable);
        }

        // GET: CakeTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeTable cakeTable = db.Table.Find(id);
            if (cakeTable == null)
            {
                return HttpNotFound();
            }
            return View(cakeTable);
        }

        // POST: CakeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CakeTable cakeTable = db.Table.Find(id);
            db.Table.Remove(cakeTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
