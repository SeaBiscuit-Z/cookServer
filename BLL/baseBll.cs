using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cook.BLL
{
    public abstract class baseBll<T> where T : class
    {
        public baseBll()
        {
            this.dal = getDal();
        }
        private DAL.baseDal<T> dal;
        public abstract DAL.baseDal<T> getDal();



		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(T model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(T model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public T GetModel(string id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable GetList(string strWhere, string orderby)
		{
            return dal.GetList(strWhere, orderby);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<T> GetModelList(string strWhere, string orderby)
		{
            DataTable dt = dal.GetList(strWhere, orderby);
			return DataTableToList(dt);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<T> DataTableToList(DataTable dt)
		{
            List<T> modelList = new List<T>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                T model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable GetAllList()
		{
			return GetList("","");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataTable GetListByPage( int pageIndex,string strWhere, string orderby)
		{
            return dal.GetListByPage(pageIndex,strWhere, orderby);
		}
    }
}
