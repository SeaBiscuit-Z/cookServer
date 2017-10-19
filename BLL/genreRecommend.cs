using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
namespace Cook.BLL
{
	/// <summary>
	/// genreRecommend
	/// </summary>
    public partial class genreRecommend : baseBll<Model.genreRecommend>
	{
        public override DAL.baseDal<Model.genreRecommend> getDal()
        {
            return new DAL.genreRecommend();
        }
        public genreRecommend() { }
        public List<Views.content_T<Views.course_T>> getAllGenreRecommend_T()
        {
            DAL.genreRecommend g = new DAL.genreRecommend();
            return g.GetAllModel_T(); ;
        }
        public Views.content_T<Views.course_T> getGenreRecommend_T(string type)
        {
            DAL.genreRecommend g = new DAL.genreRecommend();
            return g.GetModel_T(type);
        }
	}
}

