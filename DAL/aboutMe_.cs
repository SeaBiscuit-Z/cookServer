using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Cook.DAL
{
    public class aboutMe_ : baseDalById<Cook.Model.aboutMe_>
    {
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
                strSql.Append("select count(1) from aboutMe_" + tableid + "");
                strSql.Append(" where aboutMeId=@aboutMeId");
                SqlParameter[] parameters = {
					    new SqlParameter("@aboutMeId", SqlDbType.Int,4)
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
        public override bool Add(Cook.Model.aboutMe_ model, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into aboutMe_" + tableid + " (");
            strSql.Append("sourceId,sourceName,targetId,targetName,content,type,isRead,time)");
            strSql.Append(" values (");
            strSql.Append("@sourceId,@sourceName,@targetId,@targetName,@content,@type,@isRead,@time)");
            SqlParameter[] parameters = {
					new SqlParameter("@sourceId", SqlDbType.Int,4),
					new SqlParameter("@sourceName", SqlDbType.NVarChar,20),
					new SqlParameter("@targetId", SqlDbType.Int,4),
					new SqlParameter("@targetName", SqlDbType.NVarChar,20),
					new SqlParameter("@content", SqlDbType.NVarChar,250),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@isRead", SqlDbType.Char,1),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
            parameters[0].Value = model.sourceId;
            parameters[1].Value = model.sourceName;
            parameters[2].Value = model.targetId;
            parameters[3].Value = model.targetName;
            parameters[4].Value = model.content;
            parameters[5].Value = model.type;
            parameters[6].Value = model.isRead;
            parameters[7].Value = model.time;

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
        public override bool Update(Cook.Model.aboutMe_ model, string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update aboutMe_" + tableid + " set ");
            strSql.Append("sourceId=@sourceId,");
            strSql.Append("sourceName=@sourceName,");
            strSql.Append("targetId=@targetId,");
            strSql.Append("targetName=@targetName,");
            strSql.Append("content=@content,");
            strSql.Append("type=@type,");
            strSql.Append("isRead=@isRead,");
            strSql.Append("time=@time");
            strSql.Append(" where aboutMeId=@aboutMeId");
            SqlParameter[] parameters = {
					new SqlParameter("@sourceId", SqlDbType.Int,4),
					new SqlParameter("@sourceName", SqlDbType.NVarChar,20),
					new SqlParameter("@targetId", SqlDbType.Int,4),
					new SqlParameter("@targetName", SqlDbType.NVarChar,20),
					new SqlParameter("@content", SqlDbType.NVarChar,250),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@isRead", SqlDbType.Char,1),
					new SqlParameter("@time", SqlDbType.VarChar,12),
					new SqlParameter("@aboutMeId", SqlDbType.Int,4)};
            parameters[0].Value = model.sourceId;
            parameters[1].Value = model.sourceName;
            parameters[2].Value = model.targetId;
            parameters[3].Value = model.targetName;
            parameters[4].Value = model.content;
            parameters[5].Value = model.type;
            parameters[6].Value = model.isRead;
            parameters[7].Value = model.time;
            parameters[8].Value = model.aboutMeId;

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
        public override Cook.Model.aboutMe_ GetModel(string oid, string tableid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 aboutMeId,sourceId,sourceName,targetId,targetName,content,type,isRead,time from aboutMe_" + tableid + " ");
                strSql.Append(" where aboutMeId=@aboutMeId");
                SqlParameter[] parameters = {
					    new SqlParameter("@aboutMeId", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;

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
        public override Cook.Model.aboutMe_ DataRowToModel(DataRow row)
        {
            Cook.Model.aboutMe_ model = new Cook.Model.aboutMe_();
            if (row != null)
            {
                if (row["aboutMeId"] != null && row["aboutMeId"].ToString() != "")
                {
                    model.aboutMeId = int.Parse(row["aboutMeId"].ToString());
                }
                if (row["sourceId"] != null && row["sourceId"].ToString() != "")
                {
                    model.sourceId = int.Parse(row["sourceId"].ToString());
                }
                if (row["sourceName"] != null)
                {
                    model.sourceName = row["sourceName"].ToString();
                }
                if (row["targetId"] != null && row["targetId"].ToString() != "")
                {
                    model.targetId = int.Parse(row["targetId"].ToString());
                }
                if (row["targetName"] != null)
                {
                    model.targetName = row["targetName"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["isRead"] != null)
                {
                    model.isRead = row["isRead"].ToString();
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
            strSql.Append("select aboutMeId,sourceId,sourceName,targetId,targetName,content,type,isRead,time ");
            strSql.Append(" FROM aboutMe_"+tableid+" ");
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
            strSql.Append(" aboutMeId,sourceId,sourceName,targetId,targetName,content,type,isRead,time ");
            strSql.Append(" FROM aboutMe_"+tableid+" ");
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
            strSql.Append("select count(1) FROM aboutMe_" + tableid + " ");
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
                strSql.Append("order by T.aboutMeId desc");
            }
            strSql.Append(")AS Row, T.*  from aboutMe_" + tableid + " T ");
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

        /// <summary>
        /// 获取未被阅读的list
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public DataTable GetAboutMeNoRead(string token)
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return GetList(" isRead = '0' ", " time desc ", tableid);
        }

        /// <summary>
        /// 获取已被阅读的list
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public DataTable GetAboutMeRead(string token)
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return GetList(" isRead = '1' ", " time desc ", tableid);
        }


        public override int creatTable(string tableid)
        {
            string sql = "CREATE TABLE aboutMe_" + tableid + " ( aboutMeId int identity(1,1) primary key, sourceId int not null, sourceName nvarchar(20) not null, targetId int, targetName nvarchar(20), content nvarchar(250), type char(1) not null, isRead char(1) not null, time varchar(12) not null )";
            return DbHelperSQL.ExecuteSql(sql);
        }

        //获取aboutme数量
        public int getaboutnum(string id)
        {
            return new DAL.aboutMe_().GetRecordCount(" isRead = '0' ", id);
        }

        public bool setRead(string tableid, int aboutMeId) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update aboutMe_" + tableid + " set ");
            strSql.Append("isRead = '1' ");
            strSql.Append(" where aboutMeId=@aboutMeId");
            SqlParameter[] parameters = {
					new SqlParameter("@aboutMeId", SqlDbType.Int,4)};
            parameters[0].Value = aboutMeId;

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

        public bool setRead(string tableid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update aboutMe_" + tableid + " set ");
            strSql.Append(" isRead = '1' ");
            strSql.Append(" where type='2' ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //添加评论
        public bool addContent(Cook.Model.aboutMe_ model,string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into aboutMe_" + id + " (");
            strSql.Append("sourceId,sourceName,targetId,targetName,content,type,isRead,time)");
            strSql.Append(" values (");
            strSql.Append("@sourceId,@sourceName,@targetId,@targetName,@content,'1','0',@time)");
            SqlParameter[] parameters = {
					new SqlParameter("@sourceId", SqlDbType.Int,4),
					new SqlParameter("@sourceName", SqlDbType.NVarChar,20),
					new SqlParameter("@targetId", SqlDbType.Int,4),
					new SqlParameter("@targetName", SqlDbType.NVarChar,20),
					new SqlParameter("@content", SqlDbType.NVarChar,250),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
            parameters[0].Value = model.sourceId;
            parameters[1].Value = model.sourceName;
            parameters[2].Value = model.targetId;
            parameters[3].Value = model.targetName;
            parameters[4].Value = model.content;
            parameters[5].Value = model.time;

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

        //添加关注
        public bool addfollow(Cook.Model.aboutMe_ model, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into aboutMe_" + id + " (");
            strSql.Append("sourceId,sourceName,type,isRead,time)");
            strSql.Append(" values (");
            strSql.Append("@sourceId,@sourceName,'2','0',@time)");
            SqlParameter[] parameters = {
					new SqlParameter("@sourceId", SqlDbType.Int,4),
					new SqlParameter("@sourceName", SqlDbType.NVarChar,20),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
            parameters[0].Value = model.sourceId;
            parameters[1].Value = model.sourceName;
            parameters[2].Value = model.time;

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

    }
}
