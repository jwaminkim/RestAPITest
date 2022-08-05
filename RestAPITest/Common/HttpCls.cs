using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RestAPISample.Common
{
    public class HttpCls
    {
        public static string clientSiteKey
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["clientsitekey"]; }
        } 

        public static bool HttpHeaderAuth(HttpRequestMessage httpReqMsg)
        {
            bool authChk = false;
            var headers = httpReqMsg.Headers;
            if (httpReqMsg.Headers.Contains("clientsitekey"))
            {
                if (httpReqMsg.Headers.GetValues("clientsitekey").First() == clientSiteKey)
                {
                    authChk = true;
                }                
            }
            return authChk;
        }
    }
}