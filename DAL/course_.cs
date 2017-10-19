using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Configuration;
using System.Collections.Generic;//Please add references
namespace Cook.DAL
{
	/// <summary>
	/// 数据访问类:course_17
	/// </summary>
	public partial class course_ : baseDalById<Model.course_>
	{
		public course_() {}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public override bool Exists(string oid, string tableid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from course_" + tableid + "");
                strSql.Append(" where num=@id ");
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
        public override bool Add(Cook.Model.course_ model, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into course_" + tableid + "(");
			strSql.Append("num,title,img,content)");
			strSql.Append(" values (");
			strSql.Append("@num,@title,@img,@content)");
			SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,20),
					new SqlParameter("@img", SqlDbType.VarChar,-1),
					new SqlParameter("@content", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.num;
			parameters[1].Value = model.title;
			parameters[2].Value = model.img;
			parameters[3].Value = model.content;

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
        public override bool Update(Cook.Model.course_ model, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update course_" + tableid + " set ");
			strSql.Append("num=@num,");
			strSql.Append("title=@title,");
			strSql.Append("img=@img,");
			strSql.Append("content=@content");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,20),
					new SqlParameter("@img", SqlDbType.VarChar,-1),
					new SqlParameter("@content", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.num;
			parameters[1].Value = model.title;
			parameters[2].Value = model.img;
			parameters[3].Value = model.content;

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
		/// 删除一条数据
		/// </summary>
        public bool Delete(string oid, string tableid)
		{
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                //该表无主键信息，请自定义主键/条件字段
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from course_" + tableid + " ");
                strSql.Append(" where num=@id ");
                SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
		}


		/// <summary>
		/// 得到一个对象实体()
		/// </summary>
        public override Cook.Model.course_ GetModel(string oid, string tableid)
		{
		    return null;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public override Cook.Model.course_ DataRowToModel(DataRow row)
		{
			Cook.Model.course_ model=new Cook.Model.course_();
			if (row != null)
			{
				if(row["num"]!=null && row["num"].ToString()!="")
				{
					model.num=int.Parse(row["num"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["img"]!=null)
				{
					model.img=row["img"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public override DataTable GetList(string strWhere, string orderby, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select num,title,img,content ");
            strSql.Append(" FROM course_" + tableid + " ");
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
        public override DataTable GetList(int Top, string strWhere, string filedOrder, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" num,title,img,content ");
            strSql.Append(" FROM course_" + tableid + " ");
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
        public override int GetRecordCount(string strWhere, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM course_" + tableid + " ");
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
        public override DataTable GetListByPage(int pageIndex, string strWhere, string orderby, string tableid)
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
			strSql.Append(")AS Row, T.*  from course_"+tableid+" T ");
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


        public override int creatTable(string tableid)
        {
            string sql = "CREATE TABLE course_" + tableid + " ( num int primary key, title nvarchar(20), img varchar(max), content nvarchar(250) not null )";
            return DbHelperSQL.ExecuteSql(sql);
        }


	}
}

