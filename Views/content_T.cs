using System;
using System.Collections.Generic;
using System.Text;

namespace Views
{
    public partial class content_T<T>
    {
        //排行
        public content_T() { }

        public string name { get; set; }
        public List<T> content { get; set; }

    }
}
