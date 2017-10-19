using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public class trends
    {
        public trends() { }

        public int id { get; set; }
        public decimal grade { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string authorid { get; set; }
        public string type { get; set; }
        public string img { get; set; }
        public string content { get; set; }
        public string time { get; set; }
        public bool collect { get; set; }
        public string discussNum { get; set; }
    }
}
