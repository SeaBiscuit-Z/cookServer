using System;
namespace Cook.Model
{
	/// <summary>
	/// users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	//[Serializable]
	public partial class users
	{
		public users() { }

        public int id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string bg { get; set; }
        public string pagebg { get; set; }
        public int henchman { get; set; }
        public int follow { get; set; }
        public string[] skill { get; set; }
        public string[] honor { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string introdice { get; set; }
        public string status { get; set; }

	}
}

