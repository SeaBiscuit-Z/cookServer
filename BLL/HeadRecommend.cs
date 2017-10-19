using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
namespace Cook.BLL
{
	/// <summary>
	/// HeadRecommend
	/// </summary>
	public partial class HeadRecommend : baseBll<Model.HeadRecommend>
	{
        public override DAL.baseDal<Model.HeadRecommend> getDal()
        {
            return new DAL.HeadRecommend();
        }
		public HeadRecommend() { }

        public List<Views.headrecommend_T> GetModel_T()
        { 
            DAL.HeadRecommend hr = new DAL.HeadRecommend();
            return hr.GetModel_T();
        }

		
	}
}

