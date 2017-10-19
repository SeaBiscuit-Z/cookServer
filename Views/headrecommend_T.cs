using System;
using System.Collections.Generic;
using System.Web;

namespace Views
{
    public partial class headrecommend_T
    {
        //主页面推荐
        public headrecommend_T() { }
        public int courseid { get; set; }
        public string describe { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string content { get; set; }
    }
}