using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.APIController
{
    public class PNLAPIController : ApiController
    {

        MyDealDBEntities dbcontext;
        public PNLAPIController()
        {
            dbcontext = new MyDealDBEntities();
        }
        // GET api/<controller>/strIn
        public IEnumerable<PNLViewModel> Get(string pnlInput)
        {
           /// return "value";
            var res = Helpers.Helper.getString(pnlInput);
            var model = res.GroupBy(t => t.booking).Select(g => new PNLViewModel
            {
                booking = g.Key,
                PNL = g
            });
            return model;
        }

      
    }
}