using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public class chef
    {
        public chef() { }

        public int id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        //转成汉字的type
        public string status { get; set; }
        public string url { get; set; }
        public string[] skill { get; set; }
        //荣誉
        public string content { get; set; }
    }
}
