using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Configuration;

namespace Cook.DAL
{
	/// <summary>
	/// 数据访问类:users
	/// </summary>
    public partial class users : baseDal<Model.users>
	{
		public users() { }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public override bool Exists(string oid)
		{
            try {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from users");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			    };
                parameters[0].Value = id;
                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
            catch (Exception) {
                return false;
            }
            
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public override bool Add(Cook.Model.users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into users(");
			strSql.Append("name,sex,type,url,bg,pagebg,henchman,follow,skill,honor,email,phone,address,introdice,status,id)");
			strSql.Append(" values (");
			strSql.Append("@name,@sex,@type,@url,@bg,@pagebg,@henchman,@follow,@skill,@honor,@email,@phone,@address,@introdice,@status,@id)");
			//strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.Char,2),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@url", SqlDbType.VarChar,-1),
					new SqlParameter("@bg", SqlDbType.VarChar,-1),
					new SqlParameter("@pagebg", SqlDbType.VarChar,-1),
					new SqlParameter("@henchman", SqlDbType.Int,4),
					new SqlParameter("@follow", SqlDbType.Int,4),
					new SqlParameter("@skill", SqlDbType.NVarChar,200),
					new SqlParameter("@honor", SqlDbType.NVarChar,-1),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@introdice", SqlDbType.NVarChar,200),
					new SqlParameter("@status", SqlDbType.Char,1),
                    new SqlParameter("@id", SqlDbType.Int,4)
                };
			parameters[0].Value = model.name;
			parameters[1].Value = model.sex;
			parameters[2].Value = model.type;
			parameters[3].Value = model.url;
			parameters[4].Value = model.bg;
			parameters[5].Value = model.pagebg;
			parameters[6].Value = model.henchman;
			parameters[7].Value = model.follow;
			parameters[8].Value = model.skill;
			parameters[9].Value = model.honor;
			parameters[10].Value = model.email;
			parameters[11].Value = model.phone;
			parameters[12].Value = model.address;
			parameters[13].Value = model.introdice;
			parameters[14].Value = model.status;
            parameters[15].Value = model.id;
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
        public override bool Update(Cook.Model.users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update users set ");
			strSql.Append("name=@name,");
			strSql.Append("sex=@sex,");
			strSql.Append("type=@type,");
			strSql.Append("url=@url,");
			strSql.Append("bg=@bg,");
			strSql.Append("pagebg=@pagebg,");
			strSql.Append("henchman=@henchman,");
			strSql.Append("follow=@follow,");
			strSql.Append("skill=@skill,");
			strSql.Append("honor=@honor,");
			strSql.Append("email=@email,");
			strSql.Append("phone=@phone,");
			strSql.Append("address=@address,");
			strSql.Append("introdice=@introdice,");
			strSql.Append("status=@status");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.Char,2),
					new SqlParameter("@type", SqlDbType.Char,1),
					new SqlParameter("@url", SqlDbType.VarChar,-1),
					new SqlParameter("@bg", SqlDbType.VarChar,-1),
					new SqlParameter("@pagebg", SqlDbType.VarChar,-1),
					new SqlParameter("@henchman", SqlDbType.Int,4),
					new SqlParameter("@follow", SqlDbType.Int,4),
					new SqlParameter("@skill", SqlDbType.NVarChar,200),
					new SqlParameter("@honor", SqlDbType.NVarChar,-1),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,20),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@introdice", SqlDbType.NVarChar,200),
					new SqlParameter("@status", SqlDbType.Char,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.sex;
			parameters[2].Value = model.type;
			parameters[3].Value = model.url;
			parameters[4].Value = model.bg;
			parameters[5].Value = model.pagebg;
			parameters[6].Value = model.henchman;
			parameters[7].Value = model.follow;
			parameters[8].Value = model.skill;
			parameters[9].Value = model.honor;
			parameters[10].Value = model.email;
			parameters[11].Value = model.phone;
			parameters[12].Value = model.address;
			parameters[13].Value = model.introdice;
			parameters[14].Value = model.status;
			parameters[15].Value = model.id;

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
        public override Cook.Model.users GetModel(string oid)
		{
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from users ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
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
            catch (Exception) {
                return null;
            }
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public override Cook.Model.users DataRowToModel(DataRow row)
		{
			Cook.Model.users model=new Cook.Model.users();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["bg"]!=null)
				{
					model.bg=row["bg"].ToString();
				}
				if(row["pagebg"]!=null)
				{
					model.pagebg=row["pagebg"].ToString();
				}
				if(row["henchman"]!=null && row["henchman"].ToString()!="")
				{
					model.henchman=int.Parse(row["henchman"].ToString());
				}
				if(row["follow"]!=null && row["follow"].ToString()!="")
				{
					model.follow=int.Parse(row["follow"].ToString());
				}
				if(row["skill"]!=null)
				{
					model.skill = getArr(row["skill"].ToString());
				}
				if(row["honor"]!=null)
				{
					model.honor = getArr(row["honor"].ToString());
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["introdice"]!=null)
				{
					model.introdice=row["introdice"].ToString();
				}
				if(row["status"]!=null)
				{
					model.status=row["status"].ToString();
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
			strSql.Append("select id,name,sex,type,url,bg,pagebg,henchman,follow,skill,honor,email,phone,address,introdice,status ");
			strSql.Append(" FROM users ");
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
			strSql.Append(" id,name,sex,type,url,bg,pagebg,henchman,follow,skill,honor,email,phone,address,introdice,status ");
			strSql.Append(" FROM users ");
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
			strSql.Append("select count(1) FROM users ");
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
			strSql.Append(")AS Row, T.*  from users T ");
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

        /// <summary>
        /// 根据作者id返回作者名
        /// </summary>
        /// <param name="authorid"></param>
        /// <returns></returns>
        public string getAuthorName(int authorid)
        {
            try
            {
                string buf = "select name from users where id=@authorid";
                SqlParameter[] parameters = new SqlParameter[]{
                        new SqlParameter("@authorid",SqlDbType.Int,4)
                    };
                parameters[0].Value = authorid;

                return DbHelperSQL.GetSingle(buf.ToString(), parameters).ToString();
            }
            catch (Exception) {
                return "";
            }
        }

        /// <summary>
        /// 得到一个chef实体对象
        /// </summary>
        public Views.chef DataRowToChef(DataRow row)
        {
            Views.chef model = new Views.chef();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["honor"] != null)
                {
                    model.content = row["honor"].ToString();
                }
                if (row["type"] != null)
                {
                    model.status = getType(row["type"].ToString());
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["skill"] != null)
                {
                    model.skill = getArr(row["skill"].ToString());
                }
            }
            return model;
        }

        //type 1 普通用户 4  金牌 3  签约  2 认证
        public string getType(string type) 
        {
            switch (type)
            {
                case "0" :
                    return "管理员";
                case "1" :
                    return "普通用户";
                case "2":
                    return "认证";
                case "3":
                    return "签约";
                case "4":
                    return "金牌";
                default :
                    return "";
            }
        }

        //将，分割的字符串转换成数组
        public string[] getArr(string text)
        {
            return text.Split(',');
        }

        /// <summary>
        /// 获得chef形式数据
        /// </summary>
        public DataTable GetChefList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,sex,type,url,skill,honor ");
            strSql.Append(" FROM users ");
            strSql.Append(" where type != 1 and type != 0");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得chef焦点图数据
        /// </summary>
        public DataTable GetChefImgList()
        {
            int num = Convert.ToInt32(ConfigurationManager.AppSettings["chefImgNum"]);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TOP " + num + " users.id,users.name,users.sex,users.type,chefs.url,users.skill,users.honor ");
            strSql.Append(" FROM users INNER JOIN chefs ");
            strSql.Append(" on (users.type != 1 and users.type != 0) and chefs.id = users.id");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取动态信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataTable GetTrends(string id,int pageIndex)
        {
            //获取所有关注的人
            DAL.follow_ folloew = new follow_();
            DataRowCollection drs = folloew.GetList("", "", id).Rows;
            StringBuilder str = new StringBuilder();
            for(int i = 0; i < drs.Count ; i++)
            {
                if (i == 0)
                {
                    str.AppendFormat(" authorid = {0} ", drs[i]["id"].ToString());
                }
                else {
                    str.AppendFormat(" or authorid = {0} ", drs[i]["id"].ToString());
                }
            }
            //获取关注的人的教程信息
            DAL.course course = new DAL.course();
            return course.GetListByPage(pageIndex, "(" + str.ToString() + ") and stats = 0 ", " time desc ");
        }

        /// <summary>
        /// 转成user类型
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Views.user DataRowToUser(DataRow row)
        {
            Views.user model = new Views.user();
            Views.userinfo info = new Views.userinfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["bg"] != null)
                {
                    model.bg = row["bg"].ToString();
                }
                if (row["pagebg"] != null)
                {
                    model.pagebg = row["pagebg"].ToString();
                }
                if (row["henchman"] != null && row["henchman"].ToString() != "")
                {
                    model.henchman = int.Parse(row["henchman"].ToString());
                }
                if (row["follow"] != null && row["follow"].ToString() != "")
                {
                    model.follow = int.Parse(row["follow"].ToString());
                }
                if (row["skill"] != null)
                {
                    info.skill = getArr(row["skill"].ToString());
                }
                if (row["honor"] != null)
                {
                    info.honor = getArr(row["honor"].ToString());
                }
                if (row["email"] != null)
                {
                    info.email = row["email"].ToString();
                }
                if (row["phone"] != null)
                {
                    info.phone = row["phone"].ToString();
                }
                if (row["address"] != null)
                {
                    info.address = row["address"].ToString();
                }
                if (row["introdice"] != null)
                {
                    info.introdice = row["introdice"].ToString();
                }
                if (row["status"] != null)
                {
                    model.status = row["status"].ToString();
                }
                model.aboutMe = new DAL.aboutMe_().getaboutnum(model.id.ToString());
                model.msg = info;
            }
            return model;
        }

        /// <summary>
        /// 获得一个user
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public Views.user GetUser(string oid)
        {
            try
            {
                int id;
                Int32.TryParse(oid, out id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from users ");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			        };
                parameters[0].Value = id;

                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return DataRowToUser(ds.Tables[0].Rows[0]);
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
        /// 手机号是否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool ExistsPhone(string phone)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from users");
                strSql.Append(" where phone=@phone");
                SqlParameter[] parameters = {
					new SqlParameter("@phone", SqlDbType.VarChar,20)
			    };
                parameters[0].Value = phone;
                return DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
            catch (Exception)
            {
                return false;
            }
        }

        //修改用户信息
        public bool setinfo(Cook.Model.users model,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append("name=@name,");
            strSql.Append("sex=@sex,");
            strSql.Append("skill=@skill,");
            strSql.Append("honor=@honor,");
            strSql.Append("email=@email,");
            strSql.Append("address=@address,");
            strSql.Append("introdice=@introdice");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@sex", SqlDbType.Char,2),
					new SqlParameter("@skill", SqlDbType.NVarChar,200),
					new SqlParameter("@honor", SqlDbType.NVarChar,-1),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@introdice", SqlDbType.NVarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.sex;
            parameters[2].Value = model.skill[0];
            parameters[3].Value = model.honor[0];
            parameters[4].Value = model.email;
            parameters[5].Value = model.address;
            parameters[6].Value = model.introdice;
            parameters[7].Value = id;

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
        //修改用户信息
        public bool setbg(string bg, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append(" bg=@bg ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@bg", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = bg;
            parameters[1].Value = id;

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
        //修改用户信息
        public bool setpagebg(string pagebg, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append(" pagebg=@pagebg ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@pagebg", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = pagebg;
            parameters[1].Value = id;

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
        public bool setfollow(string tableid, int type)
        {
            int num = new Cook.DAL.follow_().GetRecordCount("", tableid);
            if (type == 0)
            {
                num--;
                if (num < 0) { num = 0; }
            }
            else if (type == 1)
            {
                num++;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append(" follow=@follow ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@follow", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = num;
            parameters[1].Value = tableid;

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
        public bool sethenchman(string tableid,int type)
        {
            int num = new Cook.DAL.henchman_().GetRecordCount("", tableid);
            if (type == 0)
            {
                num--;
                if (num < 0) { num = 0; }
            }
            else if( type==1 )
            {  
                num++; 
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update users set ");
            strSql.Append(" henchman=@henchman ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@henchman", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = num;
            parameters[1].Value = tableid;

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

        //根据token获取id和用户名
        public string[] getuserinfo(string token)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT users.id,users.name ");
            strSql.Append(" FROM  users INNER JOIN load ");
            strSql.Append(" on users.id = load.id and load.token=@token ");
            SqlParameter[] parameters = {
                        new SqlParameter("@token", SqlDbType.VarChar,20)
			    };
            parameters[0].Value = token;
            DataTable dt = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
            DataRow row = dt.Rows[0];
            string[] info = new string[2];
            info[0] = row[0].ToString();
            info[1] = row[1].ToString();
            return info;
        }

        /// <summary>
        /// 根据id获取 名字,头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string[] getinfo(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT name,url ");
            strSql.Append(" FROM  users ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4)
			    };
            parameters[0].Value = id;
            DataTable dt = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
            DataRow row = dt.Rows[0];
            string[] info = new string[2];
            info[0] = row[0].ToString();
            info[1] = row[1].ToString();
            return info;
        }

	}
}

