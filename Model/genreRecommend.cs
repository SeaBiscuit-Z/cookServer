using System;
namespace Cook.Model
{
	/// <summary>
	/// genreRecommend:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	//[Serializable]
	public partial class genreRecommend
	{
		public genreRecommend() { }
        public int id { get; set; }
        public string type { get; set; }
        public string time { get; set; }

	}
}

