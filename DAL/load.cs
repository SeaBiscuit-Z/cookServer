using System;
using System.Collections.Generic;
using System.Text;
using Cook;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Configuration;
using System.Data;


namespace Cook.DAL
{
    public partial class load : baseDal<Model.load>
    {
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
                strSql.Append("select count(1) from load");
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
        public override bool Add(Model.load model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into load(");
            strSql.Append("phone,pwd,token,status)");
            strSql.Append(" values (");
            strSql.Append("@phone,@pwd,@token,@status)");
            SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
					new SqlParameter("@pwd", SqlDbType.VarChar,20),
                    new SqlParameter("@token", SqlDbType.VarChar,-1),
					new SqlParameter("@status", SqlDbType.Char,1)};
            parameters[0].Value = model.phone;
            parameters[1].Value = model.pwd;
            parameters[2].Value = model.token;
            parameters[3].Value = model.status;

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
        public override bool Update(Model.load model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update load set ");
            strSql.Append("id=@id,");
            strSql.Append("phone=@phone,");
            strSql.Append("pwd=@pwd,");
            strSql.Append("status=@status");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
					new SqlParameter("@pwd", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Char,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.phone;
            parameters[2].Value = model.pwd;
            parameters[3].Value = model.status;

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
        public override Model.load GetModel(string phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" where phone = @phone");
            SqlParameter[] parameters = {
                new SqlParameter("@phone", SqlDbType.NVarChar,20)
			};
            parameters[0].Value = phone;
            Model.load model = new Model.load();
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public override Model.load DataRowToModel(DataRow row)
        {
            Model.load model = new Model.load();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["token"] != null)
                {
                    model.token = row["token"].ToString();
                }
                if (row["createdate"] != null)
                {
                    model.createdate = row["createdate"].ToString();
                }
                if (row["expiredate"] != null)
                {
                    model.expiredate = row["expiredate"].ToString();
                }
                if (row["status"] != null)
                {
                    model.status = row["status"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public override DataTable GetList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,phone,pwd,status ");
            strSql.Append(" FROM load ");
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
        public override DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,phone,pwd,status ");
            strSql.Append(" FROM load ");
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
        public override int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM load ");
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
        public override DataTable GetListByPage(int pageIndex, string strWhere, string orderby)
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
            strSql.Append(")AS Row, T.*  from load T ");
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
        /// 根据手机号密码，返回用户id
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int GetUserIdByInfo(string phone, string pwd)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id from load");
                strSql.Append(" where phone=@phone and pwd=@pwd and status = '0'");
                SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
                    new SqlParameter("@pwd", SqlDbType.NVarChar,20)
			    };
                parameters[0].Value = phone;
                parameters[1].Value = pwd;
                Object o = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                if (o == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(o);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 手机号是否使用了 -1: 无人使用 -2: 有人使用 -3: 账号已被冻结  -4: 数据库出错
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int phoneValidate(string phone)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select status from load");
                strSql.Append(" where phone=@phone");
                SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NVarChar,20)
			    };
                parameters[0].Value = phone;
                Object o = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                if (o == null) {
                    return -1;
                }
                if (Convert.ToInt32(o) == 0){
                    return -2;
                }
                else {
                    return -3;
                }
            }
            catch (Exception)
            {
                return -4;
            }
        }

        /// <summary>
        /// 返回值 0:密码错误 正数 : 成功  -2:phone错误  -3:账号已被冻结  -4: 数据库出错 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int loadValidate(string phone, string pwd)
        {
            try
            {
                int type = phoneValidate(phone);
                switch (type)
                { 
                    case -1:
                        return -2;
                    case -2:
                        int id = GetUserIdByInfo(phone, pwd);
                        if (id == 0) {
                            return 0;
                        } else {
                            return id;
                        }
                    case -3:
                        return -3;
                    case -4 :
                        return -4;
                }
                return -4;
            }
            catch (SqlException)
            {
                return -4;
            }
        }

        /// <summary>
        /// 根据用户名获得数据模型
        /// </summary>
        /// <param name="id">用户名</param>
        /// <returns></returns>
        public Model.load GetTicketByUserId(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select *");
                strSql.Append(" where id = @id");
                SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Char,4)
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

        public bool DeleteByUserId(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid,out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update load set ");
                strSql.Append(" token = '' ");
                strSql.Append(" where id=@id ");
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

        public bool DeleteTokenByToken(string token)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update load set ");
                strSql.Append(" token = '' ");
                strSql.Append(" where token=@token ");
                SqlParameter[] parameters = {
					new SqlParameter("@token", SqlDbType.VarChar,-1)
                };
                parameters[0].Value = token;
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

        public bool AddByUserId(string oid,string token, string CreateDate, string ExpireDate)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update load set ");
                strSql.Append(" token = @token,createdate = @CreateDate,expiredate = @ExpireDate ");
                strSql.Append(" where id=@id ");
                SqlParameter[] parameters = {
                    new SqlParameter("@token", SqlDbType.VarChar,-1),
                    new SqlParameter("@CreateDate", SqlDbType.VarChar,-1),
                    new SqlParameter("@ExpireDate", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)
                };
                parameters[0].Value = token;
                parameters[1].Value = CreateDate;
                parameters[2].Value = ExpireDate;
                parameters[3].Value = id;
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
        /// 根据token获得数据模型
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Model.load GetTicketByToken(string token)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from load");
                strSql.Append(" where token = @token");
                SqlParameter[] parameters = {
                    new SqlParameter("@token", SqlDbType.NVarChar,-1)
			    };
                parameters[0].Value = token;
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
        /// 根据token获得id
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetIdByToken(string token)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id from load");
                strSql.Append(" where token = @token");
                SqlParameter[] parameters = {
                    new SqlParameter("@token", SqlDbType.NVarChar,-1)
			    };
                parameters[0].Value = token;
                return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
                
            }
            catch (Exception)
            {
                return "";
            }
        }


        public Model.load GetModelByUser(string phone, string pwd)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from load");
                strSql.Append(" where phone=@phone and pwd=@pwd and status = '0'");
                SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
                    new SqlParameter("@pwd", SqlDbType.NVarChar,20)
			    };
                parameters[0].Value = phone;
                parameters[1].Value = pwd;
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
        /// 根据token返回url
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetUrl(string token)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select users.url from load INNER JOIN users ");
                strSql.Append(" on load.token = @token and users.id = load.id ");
                SqlParameter[] parameters = {
                    new SqlParameter("@token", SqlDbType.NVarChar,-1)
			    };
                parameters[0].Value = token;
                return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
