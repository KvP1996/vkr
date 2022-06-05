using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QBaseServer.Determinant;
using System.Web.Script.Serialization;
using QBaseServer.QBase;

namespace QBaseServer.Controllers
{
    public class TestController : ApiController
    {
        // GET api/test
        [ActionName("Index")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/test/5
        [ActionName("Index")]
        public HttpResponseMessage Get(int id)
        {
            //int[][] res = DBManager.GetCommonDeterminants(4, 5);
            string res = DBManager.CompareDeterminantsProcessors(4, 5);
            return new HttpResponseMessage()
            {
                Content = new StringContent(res)
            };
        }

        [ActionName("ticks")]
        public string GetTicks(int id)
        {
            return id.ToString();
        }

        // POST api/test
        public void Post([FromBody]string value)
        {
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
        }
    }
}
