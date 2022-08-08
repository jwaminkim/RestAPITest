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
    public class TempController : ApiController
    {
        [HttpGet]
        [Route("temp/templist")]
        public string Get()
        {
            try
            {
                JArray jArrResult = new JArray();
                var jResult1 = JObject.Parse("{\"name\" : \"김좌민\", \"id\" : 1}");
                var jResult2 = JObject.Parse("{\"name\" : \"김동우\", \"id\" : 4}");
                jArrResult.Add(jResult1);
                jArrResult.Add(jResult2);
                return JsonConvert.SerializeObject(jArrResult);
            }
            catch (Exception ex)
            {
                JArray jArrResult = new JArray();
                var jResult = JObject.Parse("{\"resultCode\" : \"0\", \"resultMsg\" : \" 실패 : " + ex.Message + "\" }");
                jArrResult.Add(jResult);
                return JsonConvert.SerializeObject(jArrResult);
            }            
        }

        [HttpGet]
        [Route("temp/tempview/{id}")]
        public string Get(int id)
        {
            var jResult = JObject.Parse("{\"name\" : \"김좌민\", \"id\" : "+ id + "}");
            return JsonConvert.SerializeObject(jResult);
        }

        [HttpPost]
        [Route("temp/v1")]
        public string Post([FromBody] TempModel data)
        {
            return JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        [Route("temp/v2")]
        public string Post([FromBody] List<TempModel> data)
        {
            try
            {
                JArray jArrResult = new JArray();
                var jResult = JObject.Parse("{\"resultCode\" : \"1\", \"resultMsg\" : \"성공\" }");

                /*
                JArray jArrResult = new JArray();
                var jResult = new JObject();
                jResult.Add("resultCode", "1");
                jResult.Add("resultMsg", "성공");
                */
                var jsonParams = new JObject();
                jsonParams.Add("params", JsonConvert.SerializeObject(data));

                jArrResult.Add(jResult);
                jArrResult.Add(jsonParams);

                return JsonConvert.SerializeObject(jArrResult);
            }
            catch (Exception ex)
            {
                JArray jArrResult = new JArray();
                var jResult = JObject.Parse("{\"resultCode\" : \"0\", \"resultMsg\" : \" 실패 : " + ex.Message + "\" }");

                return JsonConvert.SerializeObject(jArrResult);
            }
                        
        }

        [HttpDelete]
        [Route("temp/{id}")]
        public string Delete(int id)
        {
            return id.ToString();
        }
    }
}