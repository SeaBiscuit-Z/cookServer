using System;
using System.Collections.Generic;
using System.Text;

namespace Cook.Model
{
    public partial class aboutMe_
    {
        public aboutMe_() { }
        public int aboutMeId { get; set; }
        public int sourceId { get; set; }
        public string sourceName { get; set; }
        public int targetId { get; set; }
        public string targetName { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public string isRead { get; set; }
        public string time { get; set; }
    }
}
