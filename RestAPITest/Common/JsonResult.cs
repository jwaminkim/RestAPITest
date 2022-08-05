using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPISample.Common
{
    public class JsonResult
    {
        public static string JsonResultSuccess ()
        {            
            var jResult = JObject.Parse("{\"resultCode\" : \"1\", \"resultMsg\" : \"성공\" }");
            return JsonConvert.SerializeObject(jResult);
        }

        public static string JsonResultFail(Exception ex)
        {            
            var jResult = JObject.Parse("{\"resultCode\" : \"0\", \"resultMsg\" :  \"실패 - " + ex.Message + "\" }");
            return JsonConvert.SerializeObject(jResult);
        }

        public static string JsonResultFail(string exMsg)
        {
            var jResult = JObject.Parse("{\"resultCode\" : \"0\", \"resultMsg\" : \"실패 - " + exMsg + "\" }");
            return JsonConvert.SerializeObject(jResult);
        }
    }
}