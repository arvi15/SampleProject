using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    

    public class FileListController : Controller
    {
      
       private IFileListRepository fileRepository;
        //As the dependcy is defined in the unity container no need of the default constructor
        //public  FileListController()
        //{
           
        //   // dbcontext = new MyDealDBEntities();
        //    fileRepository = new FileListRepository(new MyDealDBEntities());
        //}
        public FileListController(IFileListRepository fileRepository)
        {
            
            this.fileRepository = fileRepository;
        }
        // GET: FileList
        public ActionResult Index()
        {
         //   return View(dbcontext.FileLists.ToList().OrderByDescending(p => p.Id));
            return View(fileRepository.GetCourses());
        }
        public ActionResult InvokeAPI(int  id)
        {
           // string content = "";
            var data=fileRepository.getDataFromWebAPI(id, Server.MapPath("~/App_Data/uploads"));
            return View(data);
            

        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if(file==null)
                return RedirectToAction("Index");
            if (file.ContentLength > 0)
            {
                try
                {
                    var fileName = "PNLFile-" + DateTime.Now.ToString("yyyyddMHHmmss")+".txt";// Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    fileRepository.uploadData(Server.MapPath("~/App_Data/uploads"), fileName);
                   
                }
                catch (DbEntityValidationException e)
                {
                    
                    throw;
                }
            }

            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            fileRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}