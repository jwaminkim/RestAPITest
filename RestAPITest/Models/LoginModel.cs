using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPISample.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string LoginPath { get; set; }
        public string UserIp { get; set; }
        public string SerialNum { get; set; }
    }
}