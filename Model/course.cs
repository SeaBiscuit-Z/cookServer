using System;
namespace Cook.Model
{
	/// <summary>
	/// course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	//[Serializable]
	public partial class course
	{
		public course() { }
        public int id { get; set; }
        public int authorid { get; set; }
        public string type { get; set; }
        public decimal grade { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string content { get; set; }
        public string time { get; set; }
        public string searchkey { get; set; }
        public string stats { get; set; }


	}
}

