using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public partial class select
    {
        //查询列表
        public select() { }
        public bool hasMovie { get; set; }
        public string newPage { get; set; }
        public int allCount { get; set; }
        public List<course_T> content { get; set; }
    }
}
