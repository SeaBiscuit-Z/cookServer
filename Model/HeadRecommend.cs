using System;
namespace Cook.Model
{
	/// <summary>
	/// HeadRecommend:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	//[Serializable]
	public partial class HeadRecommend
	{
		public HeadRecommend() { }
        public int courseid { get; set; }
        public string describe { get; set; }
        public string time { get; set; }

	}
}

