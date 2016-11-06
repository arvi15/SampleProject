using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.globalweatherService;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System.IO;
using System.Web.Script.Serialization;
namespace WebApplication1.APIController
{
   
  
    public class GetWeatherByCityController : ApiController
    {
        public static string appId = "1bd76a4dcafaa740ee653c710155f7eb";
        public static string apiURL = "http://api.openweathermap.org/data/2.5/weather?q=";
        // GET: api/GetWeatherByCity/countryName/cityName
        public weatherViewModel Get(string countryName, string cityName)
        {
            try { 
            //As the webservice given is not returning the data,I will be using web api to get the weather details
            // globalweatherService.GlobalWeatherSoapClient clientSvc = new GlobalWeatherSoapClient();
            //var res = clientSvc.GetWeather("India", "Delhi");
            //if (res == "Data Not Found")
            //{


                string url = apiURL + cityName + "&APPID=" + appId;
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);

                    RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);
                    weatherViewModel vm = new weatherViewModel();
                    vm.Location = weatherInfo.name + System.Environment.NewLine + " <br> Lon : " + weatherInfo.coord.lon + System.Environment.NewLine + " <br>  lat" + weatherInfo.coord.lat;
                    vm.Time = DateTime.Now.ToString();
                    vm.Wind = "deg :" + weatherInfo.wind.deg + "  Speed  " + weatherInfo.wind.speed;
                    vm.Visibility = "";
                    vm.Skyconditions = weatherInfo.weather.Count > 0 ? weatherInfo.weather[0].description : "";
                   
                    vm.Temperature = weatherInfo.main.temp ;
                    vm.DewPoint = "";
                    vm.RelativeHumidity = weatherInfo.main.humidity;
                    vm.Pressure = weatherInfo.main.pressure;

                    return vm;
                }
            }
            catch
            {
                return null;
            }
           
        }

    }
}
