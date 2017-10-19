using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
using System.Configuration;
namespace Cook.BLL
{
	/// <summary>
	/// search
	/// </summary>
    public partial class search : baseBll<Model.search>
	{
        public override DAL.baseDal<Model.search> getDal()
        {
            return new DAL.search();
        }
		public search() { }

        public Views.content_T<Model.search> GetListTop()
        {
            Views.content_T<Model.search> content = new Views.content_T<Model.search>();
            string name = ConfigurationManager.AppSettings["searchTop"];
            content.name = name;
            content.content = DataTableToList(new DAL.search().GetListTop());
            return content;
        }
        //热门搜索
        public List<Model.search> GetHotTop() 
        {
            DAL.search s = new DAL.search();
            return DataTableToList(s.GetHotTop());
        }
		
	}
}

