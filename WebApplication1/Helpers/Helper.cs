using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public static class GlobalVariable{
        public static string baseURL = ConfigurationManager.AppSettings["baseUrl"];//.c. "http://localhost:8416/";
    }
    public class Helper
    {
        public static List<PNL> getString(string strInput)
        {
            string tempStr = "";
            List<PNL> PNLs = new List<PNL>();
            StringReader strReader = new StringReader(strInput);
            using (StringReader reader = new StringReader(strInput))

            {
                while ((tempStr = reader.ReadLine()) != null)
                {
                    try
                    {
                        if (tempStr.StartsWith("1"))
                        {
                            var arr = tempStr.Split(' ');
                            if (arr.Length == 2)
                            {
                                if (arr[1].StartsWith(".L/"))
                                {
                                    PNL pnl = new PNL();
                                    pnl.name = arr[0].Substring(1).Split('-')[0];
                                    pnl.pnlType = "1";

                                    pnl.key = arr[0].Substring(1).Split('-').Length > 1 ? arr[0].Substring(1).Split('-')[1] : "-";
                                    pnl.booking = arr[1].Substring(3);

                                    PNLs.Add(pnl);
                                }

                            }
                        }
                    }
                    catch { }
                }
            }
            return PNLs;
        }
    }
}