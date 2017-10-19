using System;
namespace Cook.Model
{
	/// <summary>
	/// course_17:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	//[Serializable]
	public partial class course_
	{
		public course_() { }
        public int num { get; set; }
        public string title { get; set; }
        public string img { get; set; }
        public string content { get; set; }

	}
}

