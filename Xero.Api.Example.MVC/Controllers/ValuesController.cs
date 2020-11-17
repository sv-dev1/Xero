using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xero.Api.Example.MVC.Helpers;

namespace Xero.Api.Example.MVC.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/Values/CreateInvoice

        [HttpGet]
        [Route("CreateInvoice")]
        public HttpResponseMessage CreateInvoice()
        {

            using (StreamReader r = new StreamReader(@"E:\Chandan Projects\2020\Xero API\02-July\Xero-Net-master\Xero.Api.Example.MVC\App_Data\test.json"))
            {
                string json = r.ReadToEnd();
                Rootobject items = JsonConvert.DeserializeObject<Rootobject>(json);
                return Request.CreateResponse(items);
            }
        }
    }
}
