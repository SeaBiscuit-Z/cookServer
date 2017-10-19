using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Configuration;
using System.Collections.Generic;
using Views;
namespace Cook.DAL
{
	/// <summary>
	/// 数据访问类:HeadRecommend
	/// </summary>
	public partial class HeadRecommend : baseDal<Model.HeadRecommend>
	{
		public HeadRecommend() { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public override bool Exists(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from HeadRecommend");
                strSql.Append(" where courseid=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
            catch (Exception)
            {
                return false;
            }
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public override bool Add(Cook.Model.HeadRecommend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HeadRecommend(");
			strSql.Append("courseid,describe,time)");
			strSql.Append(" values (");
			strSql.Append("@courseid,@describe,@time)");
			SqlParameter[] parameters = {
					new SqlParameter("@courseid", SqlDbType.Int,4),
					new SqlParameter("@describe", SqlDbType.NVarChar,10),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
			parameters[0].Value = model.courseid;
			parameters[1].Value = model.describe;
			parameters[2].Value = model.time;

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
		public override bool Update(Cook.Model.HeadRecommend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HeadRecommend set ");
			strSql.Append("courseid=@courseid,");
			strSql.Append("describe=@describe,");
			strSql.Append("time=@time");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@courseid", SqlDbType.Int,4),
					new SqlParameter("@describe", SqlDbType.NVarChar,10),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
			parameters[0].Value = model.courseid;
			parameters[1].Value = model.describe;
			parameters[2].Value = model.time;

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
		public override Cook.Model.HeadRecommend GetModel(string oid)
		{
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                //该表无主键信息，请自定义主键/条件字段
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from HeadRecommend ");
                strSql.Append(" where courseid=@id");
                SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                Cook.Model.HeadRecommend model = new Cook.Model.HeadRecommend();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return DataRowToModel(ds.Tables[0].Rows[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception) {
                return null;
            }
		}

//        SELECT TOP 4 HeadRecommend.courseid,HeadRecommend.describe,course.name,course.url,course.content
//FROM HeadRecommend INNER JOIN course
//ON HeadRecommend.courseid = course.id and course.stats != 1
//order by HeadRecommend.time desc

        /// <summary>
        /// 得到一个对象
        /// </summary>
        public List<Views.headrecommend_T> GetModel_T()
        {
            try
            {
                //该表无主键信息，请自定义主键/条件字段
                int num = Convert.ToInt32(ConfigurationManager.AppSettings["headImgNum"]);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT TOP " + num + " HeadRecommend.courseid,HeadRecommend.describe,course.name,course.url,course.content from HeadRecommend INNER JOIN course ");
                strSql.Append(" on HeadRecommend.courseid = course.id and course.stats != 1 ");
                strSql.Append(" order by HeadRecommend.time desc ");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Views.headrecommend_T> list = new List<Views.headrecommend_T>();
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        list.Add(DataRowToModel_T(item));
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public override Cook.Model.HeadRecommend DataRowToModel(DataRow row)
		{
			Cook.Model.HeadRecommend model=new Cook.Model.HeadRecommend();
			if (row != null)
			{
				if(row["courseid"]!=null && row["courseid"].ToString()!="")
				{
					model.courseid=int.Parse(row["courseid"].ToString());
				}
				if(row["describe"]!=null)
				{
					model.describe=row["describe"].ToString();
				}
				if(row["time"]!=null)
				{
					model.time=row["time"].ToString();
				}
			}
			return model;
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Views.headrecommend_T DataRowToModel_T(DataRow row)
        {
            Views.headrecommend_T model = new Views.headrecommend_T();
            if (row != null)
            {
                if (row["courseid"] != null && row["courseid"].ToString() != "")
                {
                    model.courseid = int.Parse(row["courseid"].ToString());
                }
                if (row["describe"] != null)
                {
                    model.describe = row["describe"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public override DataTable GetList(string strWhere,string orderby)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select courseid,describe,time ");
			strSql.Append(" FROM HeadRecommend ");
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
		/// 获得前几行数据
		/// </summary>
		public override DataTable GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" courseid,describe,time ");
			strSql.Append(" FROM HeadRecommend ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString()).Tables[0];
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public override int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM HeadRecommend ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from HeadRecommend T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", pageSize * (pageIndex - 1) + 1, pageSize * pageIndex);
            //删除排序行
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            dt.Columns.Remove("row");
            return dt;
		}




    }
}

