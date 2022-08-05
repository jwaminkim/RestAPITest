using Milkt.Framework.Db;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestAPISample.Common;
using RestAPISample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPISample.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public string Post([FromBody] LoginModel data)
        {
            try
            {
                bool headerResult = HttpCls.HttpHeaderAuth(Request);               
                string jResult = "";
                if (headerResult)
                {
                    jResult = JsonResult.JsonResultSuccess();
                    JArray jArrResult = new JArray();                    
                    DataTable dt = GetUserInfo(data.UserName);
                    
                    jArrResult.Add(jResult);
                    jArrResult.Add(JsonConvert.SerializeObject(dt));

                    jResult = JsonConvert.SerializeObject(jArrResult);
                }
                else
                {
                    jResult = JsonResult.JsonResultFail("Header Error");                    
                }
                return jResult;
            }
            catch(Exception ex)
            {
                return JsonResult.JsonResultFail(ex);
            }
        }

        public DataTable GetUserInfo(string strUserID)
        {

            SqlParameter[] parValue = {
                        new SqlParameter("@in_UserName" , SqlDbType.VarChar,  20) { Value = strUserID }
                    };

            //회원 정보
            DataTable ds = DBHelper.GetDataTableByProcedure("Platform_App.dbo.USP_APP_USERINFO_USERNAME_VIEW", parValue);
            return ds;
        }
    }
}
