using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public partial class courseMsg
    {
        //教程具体信息
        public courseMsg() { }
        public int id { get; set; }
        public int authorid { get; set; }
        public string author { get; set; }
        public decimal grade { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public bool collect { get; set; }
        public List<Cook.Model.course_> procedure { get; set; }
    }
}
