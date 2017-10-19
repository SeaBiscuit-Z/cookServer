using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public partial class course_T
    {
        //course基本信息
        public course_T() { }

        public int id { get; set; }
        public decimal grade { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string content { get; set; }
    }
}
