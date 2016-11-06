using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
   
    public class FileListRepository:IFileListRepository,IDisposable
    {
        HttpClient Client = new HttpClient();
        Uri BaseAddress = new Uri(WebApplication1.Helpers.GlobalVariable.baseURL);
        MyDealDBEntities context;
       
        public FileListRepository(MyDealDBEntities context)
        {
            this.context = context;
        }
        public   IEnumerable<FileList>  GetCourses()
        {
            return context.FileLists.ToList().OrderByDescending(p => p.Id);
        }

        public IEnumerable<PNLViewModel> getDataFromWebAPI(int fileId,string filepath)
        {
            string content = "";
            string fileName = context.FileLists.FirstOrDefault(p=>p.Id==fileId).FileName;
            using (StreamReader sr = new StreamReader(Path.Combine(filepath, fileName)))
            {
                content = sr.ReadToEnd();
            }
            Client.BaseAddress = BaseAddress;
            string url = "/api/PNLAPI?pnlInput=" + content;

            HttpResponseMessage response = Client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {

                var data = response.Content.ReadAsAsync<IEnumerable<PNLViewModel>>().Result;
                return data;
            }
            return null;
        }

        public void uploadData(string path,string fileName)
        {
            FileList filelist = new FileList();
            filelist.FileName = fileName;

            using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
            {

                foreach (PNL pnl in Helpers.Helper.getString(sr.ReadToEnd()))
                {
                    filelist.PNLs.Add(pnl);
                }
                ///  filelist.PNLs=Helpers.Helper.getString(sr.ReadToEnd());
            }


            context.FileLists.Add(filelist);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FileListRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}