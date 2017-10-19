using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cook.BLL
{
    public abstract class baseBllById<T> where T : class
    {
        public baseBllById()
        {
            this.dal = getDal();
        }
        private DAL.baseDalById<T> dal;
        public abstract DAL.baseDalById<T> getDal();

        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public int creatTable(string tableid)
        {
            return dal.creatTable(tableid);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id,string tableid)
        {
            return dal.Exists(id, tableid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(T model, string tableid)
        {
            return dal.Add(model, tableid);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T model, string tableid)
        {
            return dal.Update(model, tableid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T GetModel(string id, string tableid)
        {

            return dal.GetModel(id, tableid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere, string orderby, string tableid)
        {
            return dal.GetList(strWhere, orderby, tableid);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder, string tableid)
        {
            return dal.GetList(Top, strWhere, filedOrder, tableid);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<T> GetModelList(string strWhere, string orderby, string tableid)
        {
            DataTable dt = dal.GetList(strWhere, orderby, tableid);
            return DataTableToList(dt);
        }

        /// <summary>
        /// 获得数据模型列表
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere, string tableid)
        {
            return dal.GetRecordCount(strWhere, tableid);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(int pageIndex, string strWhere, string orderby, string tableid)
        {
            return dal.GetListByPage(pageIndex, strWhere, orderby, tableid);
        }
    }
}
