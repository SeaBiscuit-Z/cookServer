using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Cook.DAL
{
    public class discuss_ : baseDalById<Model.discuss_>
    {

        public discuss_() { }
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
                strSql.Append("select count(1) from discuss_" + tableid + "");
                strSql.Append(" where id=@id ");
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
        public override bool Add(Model.discuss_ model, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into discuss_" + tableid + "(");
            strSql.Append("id,type,content,time)");
            strSql.Append(" values (");
            strSql.Append("@id,@type,@content,@time)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@content", SqlDbType.NVarChar,150),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.type;
            parameters[2].Value = model.content;
            parameters[3].Value = model.time;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public override bool Update(Model.discuss_ model, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update discuss_"+tableid+" set ");
            strSql.Append("id=@id,");
            strSql.Append("type=@type,");
            strSql.Append("content=@content,");
            strSql.Append("time=@time");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@content", SqlDbType.NVarChar,150),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.type;
            parameters[2].Value = model.content;
            parameters[3].Value = model.time;

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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override Model.discuss_ GetModel(string oid, string tableid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                //该表无主键信息，请自定义主键/条件字段
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 id,type,content,time from discuss_" + tableid + " ");
                strSql.Append(" where ");
                SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                Model.discuss_ model = new Model.discuss_();
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
            catch(Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override Model.discuss_ DataRowToModel(DataRow row)
        {
            Model.discuss_ model = new Model.discuss_();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["time"] != null)
                {
                    model.time = row["time"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public override DataTable GetList(string strWhere, string orderby, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,type,content,time ");
            strSql.Append(" FROM discuss_"+tableid+" ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,type,content,time ");
            strSql.Append(" FROM discuss_" + tableid + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public override int GetRecordCount(string strWhere, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM discuss_" + tableid + " ");
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public override DataTable GetListByPage(int pageIndex, string strWhere, string orderby, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from discuss_" + tableid + " T ");
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
            string sql = "CREATE TABLE discuss_" + tableid + " ( id int not null, type char(1) not null, content nvarchar(150) not null, time varchar(12) not null )";
            return DbHelperSQL.ExecuteSql(sql);
        }

        //tableid 教程id
        //添加对教程的评论
        public bool addDis(Cook.Model.aboutMe_ model,string tableid) 
        {
            try
            {
                string authorid = new Cook.DAL.course().getAuthorByid(tableid);
                Cook.Model.discuss_ dis = new Model.discuss_();
                dis.id = model.sourceId;
                dis.content = model.content;
                dis.type = "0";
                dis.time = model.time;
                if (Add(dis, tableid))
                {
                    return new aboutMe_().addContent(model, authorid);
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
