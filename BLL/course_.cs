using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
namespace Cook.BLL
{
	/// <summary>
	/// course_17
	/// </summary>
    public partial class course_ : baseBllById<Model.course_>
	{
        public override DAL.baseDalById<Model.course_> getDal()
        {
            return new DAL.course_();
        }
		public course_() {}

        //是否收藏
        public bool isCollect(string token, string id) 
        {
            return new Cook.DAL.collect_().isCollect(token,id);
        }

	}
}

