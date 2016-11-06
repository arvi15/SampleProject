using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class URLMappersController : Controller
    {
        private MyDealDBEntities db = new MyDealDBEntities();

        // GET: URLMappers
        public ActionResult Index()
        {
            
            return View(db.URLMappers.ToList().OrderByDescending(p=>p.Id));
        }
        public ActionResult Rewrite(string name)
        {
            if(db.URLMappers.Count()==0)
                return View("PageNotFound");
            var mapper=  db.URLMappers.Where(p => p.shortURL.Equals(name)).FirstOrDefault();
            if(mapper!=null)
                return Redirect(mapper.longUrl);
            else
                  return View("PageNotFound");

            ///   return View(db.URLMappers.ToList().OrderByDescending(p => p.Id));
        }
      
        // GET: URLMappers/Create
        public ActionResult Create()
        {
            return View();
        }
        private static string RandomString(int Size)
        {
            Random random = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, Size)
                                   .Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }
        // POST: URLMappers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,shortURL,longUrl")] URLMapper uRLMapper)
        {
                if (ModelState.IsValid)
                {
                uRLMapper.shortURL= RandomString(7);
                db.URLMappers.Add(uRLMapper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uRLMapper);
        }

        // GET: URLMappers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URLMapper uRLMapper = db.URLMappers.Find(id);
            if (uRLMapper == null)
            {
                return HttpNotFound();
            }
            return View(uRLMapper);
        }

        // POST: URLMappers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,shortURL,longUrl")] URLMapper uRLMapper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uRLMapper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uRLMapper);
        }

        // GET: URLMappers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            URLMapper uRLMapper = db.URLMappers.Find(id);
            if (uRLMapper == null)
            {
                return HttpNotFound();
            }
            return View(uRLMapper);
        }

        // POST: URLMappers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            URLMapper uRLMapper = db.URLMappers.Find(id);
            db.URLMappers.Remove(uRLMapper);
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
