using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Configuration;
using System.Collections.Generic;

namespace Cook.DAL
{
	/// <summary>
	/// 数据访问类:genreRecommend
	/// </summary>
    public partial class genreRecommend : baseDal<Model.genreRecommend>
	{

        public genreRecommend() { }
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
                strSql.Append("select count(1) from genreRecommend");
                strSql.Append(" where id=@id");
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
        public override bool Add(Cook.Model.genreRecommend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into genreRecommend(");
			strSql.Append("id,type,time)");
			strSql.Append(" values (");
			strSql.Append("@id,@type,@time)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.type;
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
        public override bool Update(Cook.Model.genreRecommend model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update genreRecommend set ");
			strSql.Append("id=@id,");
			strSql.Append("type=@type,");
			strSql.Append("time=@time");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.type;
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
        public override Cook.Model.genreRecommend GetModel(string oid)
		{
			//该表无主键信息，请自定义主键/条件字段
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from genreRecommend");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                Cook.Model.genreRecommend model = new Cook.Model.genreRecommend();
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
            catch(Exception) {
                return null;
            }
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public override Cook.Model.genreRecommend DataRowToModel(DataRow row)
		{
			Cook.Model.genreRecommend model=new Cook.Model.genreRecommend();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["time"]!=null)
				{
					model.time=row["time"].ToString();
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
			strSql.Append("select id,type,time ");
			strSql.Append(" FROM genreRecommend ");
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

//        SELECT course.id,course.grade,course.name,course.url,course.content FROM  genreRecommend INNER JOIN course
//on genreRecommend.id = course.id and genreRecommend.type=0
//order by genreRecommend.time desc
        /// <summary>
        /// 获取某一种类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public Views.content_T<Views.course_T> GetModel_T(string type)
        {
            try
            {
                char t = Convert.ToChar(type);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT TOP 4 course.id,course.grade,course.name,course.url,course.content ");
                strSql.Append(" FROM  genreRecommend INNER JOIN course ");
                strSql.Append(" on genreRecommend.id = course.id and genreRecommend.type=@type ");
                strSql.Append(" order by genreRecommend.time desc ");
                SqlParameter[] parameters = {
                        new SqlParameter("@type", SqlDbType.Char,1)
			    };
                parameters[0].Value = t;

                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                List<Views.course_T> list = new List<Views.course_T>();
                course c = new course();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    list.Add(c.DataRowToModel_T(item));
                }
                Views.content_T<Views.course_T> gr = new Views.content_T<Views.course_T>();
                gr.name = ConfigurationManager.AppSettings["type" + type].ToString();
                gr.content = list;
                return gr;

            }
            catch(Exception) {
                return null;
            }
            
        }

        public List<Views.content_T<Views.course_T>> GetAllModel_T()
        {
            List<Views.content_T<Views.course_T>> list = new List<Views.content_T<Views.course_T>>();
            int typeNum = Convert.ToInt32(ConfigurationManager.AppSettings["typeNum"]);
            for (int i = 0; i <= typeNum; i++)
            {
                list.Add(GetModel_T(i + ""));
            }
            return list;
        }

        
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public override DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,type,time ");
			strSql.Append(" FROM genreRecommend ");
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
			strSql.Append("select count(1) FROM genreRecommend ");
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
			strSql.Append(")AS Row, T.*  from genreRecommend T ");
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

