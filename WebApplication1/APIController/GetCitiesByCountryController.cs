using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.globalweatherService;
using System.Data;
using System.IO;

namespace WebApplication1.APIController
{
    public class GetCitiesByCountryController : ApiController
    {
        public DataSet getDS(string xmlData)
        {
            StringReader theReader = new StringReader(xmlData);
            DataSet theDataSet = new DataSet();
           theDataSet.ReadXml(theReader);

            return theDataSet;
        }
       
        // GET: api/GetWeatherByCity/countryName
        public IEnumerable<string> Get(string countryName)
        {
            try
            {
                globalweatherService.GlobalWeatherSoapClient client = new GlobalWeatherSoapClient();
              //get the list of cities from the service
                var res = client.GetCitiesByCountry(countryName.Trim());
               //create the ds from the string
                var ds = getDS(res);
                if (ds == null || ds.Tables.Count == 0)
                    return null;
                var filePaths = ds.Tables[0]
                                .AsEnumerable()
                                .Where(p => p.Field<string>("Country").Equals(countryName, StringComparison.InvariantCultureIgnoreCase))
                                .Select(row => row.Field<string>("City"))
                                .ToArray();
                return filePaths;
                
            }
            catch { return null; }
        }
    
    }
}
