using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public partial class ResponseResult
    {
        public ResponseResult() { }
        public bool status { get; set; }
        public string message { get; set; }
        public JObject info { get; set; }
    }
}