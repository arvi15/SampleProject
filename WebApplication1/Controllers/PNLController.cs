using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PNLController : Controller
    {
        MyDealDBEntities dbcontext;
        public PNLController()
        {
            dbcontext = new MyDealDBEntities();
        }
        //GET: PNL
        public ActionResult Search(int? ID,string tbsearch)
        {
            if (ID == null)
                return View("Index", dbcontext.PNLs.Where(p => p.name.Contains(tbsearch) || p.booking.Contains(tbsearch)));
            return View("Index", dbcontext.PNLs.Where(p => p.FileListId == ID&& ( p.name.Contains(tbsearch) || p.booking.Contains(tbsearch))));
        }
        // GET: PNL
        public ActionResult Index(int? ID)
        {
            ViewBag.ID = ID.ToString();
            if(ID==null)
                return View("Index", dbcontext.PNLs);

            return View("Index", dbcontext.PNLs.Where(p => p.FileListId == ID));
        }
        public ActionResult Create(int? ID)
        {


            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? ID, [Bind(Include = "name,key,booking")] PNL pnl)
        {
            if (ModelState.IsValid)
            {


                pnl.FileListId = ID == null ? 0 : (int)ID;

                dbcontext.FileLists.First(p => p.Id == ID).PNLs.Add(pnl);
                dbcontext.SaveChanges();
                string fileName = dbcontext.FileLists.Where(p => p.Id == ID).First().FileName;
                using (StreamWriter sw = new StreamWriter(Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName), true))
                {
                    sw.WriteLine(Environment.NewLine + "1" + pnl.name + "-" + pnl.key + " .L/" + pnl.booking);
                }

                return View("Index", dbcontext.FileLists.First(p => p.Id == ID).PNLs);
            }
            ModelState.AddModelError("error_msg", "Error.Please enter all values");
            return View("Create");
        }
    
      
    }
}