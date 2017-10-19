using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cook.DAL
{
    public abstract class baseDalById<T>
    {
        public baseDalById() { }

        public abstract int creatTable(string tableid);

        /// <summary>
		/// 是否存在该记录
		/// </summary>
        public abstract bool Exists(string id, string tableid);

        /// <summary>
		/// 增加一条数据
		/// </summary>
        public abstract bool Add(T model, string tableid);

        /// <summary>
		/// 更新一条数据
		/// </summary>
        public abstract bool Update(T model, string tableid);

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public abstract T GetModel(string id, string tableid);

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public abstract T DataRowToModel(DataRow row);

        /// <summary>
		/// 获得数据列表
        /// <para>strWhere条件语句 </para>
        /// <para>排序方式  字段 DESC降序 ASC升序</para>
		/// </summary>
        public abstract DataTable GetList(string strWhere, string orderby, string tableid);
		
        /// <summary>
		/// 获得前几行数据
		/// </summary>
        public abstract DataTable GetList(int Top, string strWhere, string filedOrder, string tableid);

        /// <summary>
		/// 获取记录总数
		/// </summary>
        public abstract int GetRecordCount(string strWhere, string tableid);

        /// <summary>
		/// 分页获取数据列表
        /// <para>pageIndex查询哪一页</para>
        /// <para>strWhere查询判断</para>
        /// <para>orderby排序</para>
		/// </summary>
        public abstract DataTable GetListByPage(int pageIndex, string strWhere, string orderby, string tableid);
    }
}
