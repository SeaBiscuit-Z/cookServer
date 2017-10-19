using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Configuration;//Please add references

namespace Cook.DAL
{
	/// <summary>
	/// 数据访问类:follow_1
	/// </summary>
	public partial class follow_ : baseDalById<Model.follow_>
    {
        public follow_() { }
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
                strSql.Append("select count(1) from follow_" + tableid + "");
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
        public override bool Add(Cook.Model.follow_ model, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into follow_" + tableid + "(");
			strSql.Append("id,time)");
			strSql.Append(" values (");
			strSql.Append("@id,@time)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.time;

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
        public override bool Update(Cook.Model.follow_ model, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update follow_" + tableid + " set ");
			strSql.Append("id=@id,");
			strSql.Append("time=@time");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@time", SqlDbType.VarChar,12)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.time;

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
        public override Cook.Model.follow_ GetModel(string oid, string tableid)
		{
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                //该表无主键信息，请自定义主键/条件字段
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 id,time from follow_" + tableid + " ");
                strSql.Append(" where id=@id ");
                SqlParameter[] parameters = {
                         new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                Cook.Model.follow_ model = new Cook.Model.follow_();
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
        public override Cook.Model.follow_ DataRowToModel(DataRow row)
		{
            Cook.Model.follow_ model = new Cook.Model.follow_();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
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
        public override DataTable GetList(string strWhere, string orderby, string tableid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,time ");
            strSql.Append(" FROM follow_" + tableid + " ");
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
			strSql.Append(" id,time ");
            strSql.Append(" FROM follow_" + tableid + " ");
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
            strSql.Append("select count(1) FROM follow_" + tableid + " ");
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
            strSql.Append(")AS Row, T.*  from follow_" + tableid + " T ");
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
            string sql = "CREATE TABLE follow_" + tableid + " ( id int primary key, time varchar(12) not null )";
            return DbHelperSQL.ExecuteSql(sql);
        }

        public Views.userSign getFollow(Model.users row) 
        {
            Views.userSign model = new Views.userSign();
            if (row != null)
            {
                model.id = row.id;
                if (row.name != null)
                {
                    model.name = row.name;
                }
                if (row.sex != null)
                {
                    model.sex = row.sex;
                }
                if (row.type != null)
                {
                    model.type = row.type;
                }
                if (row.url != null)
                {
                    model.url = row.url;
                }
                if (row.skill != null)
                {
                    model.skill = row.skill;
                }
            }
            return model;
        }


        public bool delete(string token, string oid)
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("DELETE FROM follow_" + tableid + "");
                strSql.Append(" WHERE id=@id");
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

        //根据token返回和id 添加
        public bool add(Cook.Model.follow_ model, string token)
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return Add(model, tableid);
        }


        public bool addfoll(Cook.Model.aboutMe_ model, string tableid)
        {
            try
            {
                return new Cook.DAL.aboutMe_().addfollow(model, tableid);
            }
            catch (Exception)
            {
                return false;
            }
        }

	}
}

