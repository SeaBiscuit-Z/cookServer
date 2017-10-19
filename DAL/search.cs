using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Configuration;

namespace Cook.DAL
{
	/// <summary>
	/// 数据访问类:search
	/// </summary>
	public partial class search : baseDal<Model.search>
	{
		public search() { } 
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public override bool Exists(string name)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from search");
			strSql.Append(" where name=@name ");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20)			};
			parameters[0].Value = name;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public override bool Add(Cook.Model.search model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into search(");
			strSql.Append("name,num)");
			strSql.Append(" values (");
			strSql.Append("@name,@num)");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@num", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.num;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public override bool Update(Cook.Model.search model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update search set ");
			strSql.Append("num=@num");
			strSql.Append(" where name=@name ");
			SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.num;
			parameters[1].Value = model.name;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public override Cook.Model.search GetModel(string name)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from search ");
			strSql.Append(" where name=@name ");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20)			};
			parameters[0].Value = name;

			Cook.Model.search model=new Cook.Model.search();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public override Cook.Model.search DataRowToModel(DataRow row)
		{
			Cook.Model.search model=new Cook.Model.search();
			if (row != null)
			{
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["num"]!=null && row["num"].ToString()!="")
				{
					model.num=int.Parse(row["num"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public override DataTable GetList(string strWhere, string orderby)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select name,num ");
			strSql.Append(" FROM search ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            //排序
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
		}

        /// <summary>
        /// 获得搜索排名
        /// </summary>
        /// <returns></returns>
        public DataTable GetListTop() 
        {
            int num = Convert.ToInt32(ConfigurationManager.AppSettings["topNum"]);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP " + num + " * ");
            strSql.Append(" FROM search ");
            strSql.Append("order by num desc ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public DataTable GetHotTop()
        {
            int hotSelect = Convert.ToInt32(ConfigurationManager.AppSettings["hotSelect"]); ;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP " + hotSelect + " * ");
            strSql.Append(" FROM search ");
            strSql.Append("order by num desc ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public override DataTable GetList(int Top, string strWhere, string order)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" name,num ");
			strSql.Append(" FROM search ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + order);
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
        public override int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM search ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public override DataTable GetListByPage(int pageIndex, string strWhere, string orderby)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.name desc");
			}
			strSql.Append(")AS Row, T.*  from search T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", pageSize * (pageIndex - 1) +1, pageSize * pageIndex);
			//删除排序行
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            dt.Columns.Remove("row");
            return dt;
		}

	}
}

