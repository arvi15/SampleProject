using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class weatherViewModel
    {
        
            public string Country { get; set; }
            public string City { get; set; }
            public string Location { get; set; }
            public string Time { get; set; }
            public string Wind { get; set; }
            public string Skyconditions { get; set; }
            public string Temperature { get; set; }
            public string DewPoint { get; set; }
            public string RelativeHumidity { get; set; }
            public string Pressure { get; set; }
            public string Visibility { get; set; }
        
    }
}