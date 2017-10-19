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
	/// 数据访问类:course
	/// </summary>
    public partial class course : baseDal<Model.course>
	{
		public course() { }
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
                strSql.Append("select count(1) from course");
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
        public override bool Add(Cook.Model.course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into course(");
			strSql.Append("authorid,type,grade,name,url,content,time,searchkey,stats)");
			strSql.Append(" values (");
			strSql.Append("@authorid,@type,@grade,@name,@url,@content,@time,@searchkey,@stats)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@authorid", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@grade", SqlDbType.Decimal,5),
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@url", SqlDbType.VarChar,-1),
					new SqlParameter("@content", SqlDbType.NVarChar,250),
					new SqlParameter("@time", SqlDbType.VarChar,12),
					new SqlParameter("@searchkey", SqlDbType.NVarChar,-1),
					new SqlParameter("@stats", SqlDbType.Char,1)};
			parameters[0].Value = model.authorid;
			parameters[1].Value = model.type;
			parameters[2].Value = model.grade;
			parameters[3].Value = model.name;
			parameters[4].Value = model.url;
			parameters[5].Value = model.content;
			parameters[6].Value = model.time;
			parameters[7].Value = model.searchkey;
			parameters[8].Value = model.stats;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return false;
			}
			else
			{
				int t = Convert.ToInt32(obj);
                if (t > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public override bool Update(Cook.Model.course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update course set ");
			strSql.Append("authorid=@authorid,");
			strSql.Append("type=@type,");
			strSql.Append("grade=@grade,");
			strSql.Append("name=@name,");
			strSql.Append("url=@url,");
			strSql.Append("content=@content,");
			strSql.Append("time=@time,");
			strSql.Append("searchkey=@searchkey,");
			strSql.Append("stats=@stats");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@authorid", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@grade", SqlDbType.Decimal,5),
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@url", SqlDbType.VarChar,-1),
					new SqlParameter("@content", SqlDbType.NVarChar,250),
					new SqlParameter("@time", SqlDbType.VarChar,12),
					new SqlParameter("@searchkey", SqlDbType.NVarChar,-1),
					new SqlParameter("@stats", SqlDbType.Char,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.authorid;
			parameters[1].Value = model.type;
			parameters[2].Value = model.grade;
			parameters[3].Value = model.name;
			parameters[4].Value = model.url;
			parameters[5].Value = model.content;
			parameters[6].Value = model.time;
			parameters[7].Value = model.searchkey;
			parameters[8].Value = model.stats;
			parameters[9].Value = model.id;

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
        public override Cook.Model.course GetModel(string oid)
		{
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from course ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					    new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

                Cook.Model.course model = new Cook.Model.course();
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
            catch (Exception)
            {
                return null;
            }
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public override Cook.Model.course DataRowToModel(DataRow row)
		{
			Cook.Model.course model=new Cook.Model.course();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["authorid"]!=null && row["authorid"].ToString()!="")
				{
					model.authorid=int.Parse(row["authorid"].ToString());
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["grade"]!=null && row["grade"].ToString()!="")
				{
					model.grade=decimal.Parse(row["grade"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["time"]!=null)
				{
					model.time=row["time"].ToString();
				}
				if(row["searchkey"]!=null)
				{
					model.searchkey=row["searchkey"].ToString();
				}
				if(row["stats"]!=null)
				{
					model.stats=row["stats"].ToString();
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
			strSql.Append("select id,authorid,type,grade,name,url,content,time,searchkey,stats ");
			strSql.Append(" FROM course ");
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
        public override DataTable GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,authorid,type,grade,name,url,content,time,searchkey,stats ");
			strSql.Append(" FROM course ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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

        public int GetCount(string strWhere, SqlParameter[] parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM course ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
            //排序
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from course T ");
            //判断条件
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


        public DataTable GetListByPage(int pageIndex, string strWhere, SqlParameter[] parameters, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //排序
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from course T ");
            //判断条件
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", pageSize * (pageIndex - 1) + 1, pageSize * pageIndex );
            //删除排序行
            DataTable dt = DbHelperSQL.Query(strSql.ToString(),parameters).Tables[0];
            dt.Columns.Remove("row");
            return dt;
        }
        //        SELECT TOP 10 id,name,grade FROM course
        //order by grade desc
        /// <summary>
        /// 搜索结果是否有视频教程
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists_T(string key)
        {
            try
            {
                if (key != "")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("select count(1) from course ");
                    strSql.Append(" where ( searchkey LIKE @key1 OR content LIKE @key2 ) and type = '1' ");
                    SqlParameter[] parameters = {
					    new SqlParameter("@key1", SqlDbType.NVarChar,250),
                        new SqlParameter("@key2", SqlDbType.NVarChar,250)
			            };
                    parameters[0].Value = string.Format("%{0}%", key.Trim());
                    parameters[1].Value = string.Format("%{0}%", key.Trim());

                    return DbHelperSQL.Exists(strSql.ToString(), parameters);
                }
                else {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("select count(1) from course ");
                    strSql.Append(" where type = '1' ");
                    return DbHelperSQL.Exists(strSql.ToString());
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 输出评分排名
        /// </summary>
        /// <returns></returns>
        public DataTable GetListTop()
        {
            int num = Convert.ToInt32(ConfigurationManager.AppSettings["topNum"]);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP " + num + " id,name,grade ");
            strSql.Append(" FROM course ");
            strSql.Append("order by grade desc ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public Views.courseTop DataRowToModelTop(DataRow row)
        {
            Views.courseTop model = new Views.courseTop();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["grade"] != null && row["grade"].ToString() != "")
                {
                    model.grade = decimal.Parse(row["grade"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Views.course_T DataRowToModel_T(DataRow row)
        {
            Views.course_T model = new Views.course_T();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["grade"] != null)
                {
                    model.grade = Convert.ToDecimal(row["grade"]);
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
        /// 得到具体教程的信息
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public DataRow GetModelSelectMsg(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id,name,grade,authorid,url,content,type from course ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					    new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

                Cook.Model.course model = new Cook.Model.course();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
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
        /// 搜索后的信息
        /// </summary>
        /// <param name="row"></param>
        /// <param name="iscollect"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public Views.courseMsg DataRowToSelectMsg(DataRow row,List<Cook.Model.course_> list,string token = "")
        {
            Views.courseMsg model = new Views.courseMsg();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["authorid"] != null)
                {
                    model.authorid = Convert.ToInt32(row["authorid"]);
                }
                if (row["authorid"] != null)
                {
                    model.author = new users().getAuthorName(Convert.ToInt32(row["authorid"]));
                }
                if (row["grade"] != null)
                {
                    model.grade = Convert.ToDecimal(row["grade"]);
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
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (token != "")
                {
                    try
                    {
                        model.collect = new collect_().isCollect(token, model.id.ToString());
                    }
                    catch (Exception)
                    {
                        model.collect = false;
                    }
                }
                model.procedure = list;
            }
            return model;
        }

        /// <summary>
        /// 获得trends对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Views.trends DataRowToTrends(DataRow row,string token = "")
        {
            Views.trends model = new Views.trends();
            DAL.users user = new DAL.users();
            collect_ collect = new collect_();
            DAL.discuss_ dis = new DAL.discuss_();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["authorid"] != null && row["authorid"].ToString() != "")
                {
                    model.authorid = row["authorid"].ToString();
                }
                if (row["authorid"] != null && row["authorid"].ToString() != "")
                {
                    model.author = user.getAuthorName(int.Parse(row["authorid"].ToString()));
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["grade"] != null && row["grade"].ToString() != "")
                {
                    model.grade = decimal.Parse(row["grade"].ToString());
                }
                if (row["name"] != null)
                {
                    model.title = row["name"].ToString();
                }
                if (row["url"] != null)
                {
                    model.img = row["url"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["time"] != null)
                {
                    model.time = row["time"].ToString();
                }
                if (token != "")
                {
                    try
                    {
                        model.collect = collect.isCollect(token, model.id.ToString());
                    }
                    catch (Exception) {
                        model.collect = false;
                    }
                }
                try
                {
                    model.discussNum = dis.GetRecordCount("", model.id.ToString()).ToString();
                }
                catch (SqlException) {
                    model.discussNum = "0";
                }
            }
            return model;
        }


        public string getAuthorByid(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select authorid from course");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					    new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

                return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
            }
            catch (Exception)
            {
                return "";

            }
        }

        public string getcoursenameByid(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select name from course");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					    new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

                return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
            }
            catch (Exception)
            {
                return "";

            }
        }

    }
}

