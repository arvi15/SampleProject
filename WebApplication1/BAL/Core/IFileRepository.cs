using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public interface IFileListRepository : IDisposable
    {
        IEnumerable<FileList> GetCourses();
        IEnumerable<PNLViewModel> getDataFromWebAPI(int CoursId, string filePath);
        void uploadData(string filepath, string filename);
    }
}