using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestAPISample.Models;

namespace RestAPISample.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("Values/v1")]
        public string Post([FromBody] TempModel data)
        {
            return JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        [Route ("Values/v2")]
        public string Post([FromBody] List<TempModel> data)
        {
            return JsonConvert.SerializeObject(data);
            //JArray jsonArr = JsonConvert.DeserializeObject<JArray>(value);

            //return jsonArr;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return id.ToString();
        }
    }
}
