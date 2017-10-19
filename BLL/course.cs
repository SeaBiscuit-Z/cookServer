using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;

namespace Cook.BLL
{
	/// <summary>
	/// course
	/// </summary>
	public partial class course : baseBll<Model.course>
	{
        public override DAL.baseDal<Model.course> getDal()
        {
            return new DAL.course();
        }
		public course() { }

        public Views.content_T<Views.courseTop> GetListTop()
        {
            Views.content_T<Views.courseTop> content = new Views.content_T<Views.courseTop>();
            List<Views.courseTop> list = new List<Views.courseTop>();
            DAL.course c = new DAL.course();
            foreach (DataRow item in c.GetListTop().Rows)
            {
                list.Add(c.DataRowToModelTop(item));
            }
            string name = ConfigurationManager.AppSettings["courseTop"];
            content.name = name;
            content.content = list;
            return content;
        }


        /// <summary>
        /// 返回搜索后的DataTable
        /// </summary>
        /// <param name="searchKey">搜索关键字</param>
        /// <param name="type">0图文 1视频</param>
        /// <returns></returns>
        public List<Views.course_T> GetListToSelect(int pageIndex, string searchKey, string type)
        {
            List<Views.course_T> list = new List<Views.course_T>();
            StringBuilder strSql = new StringBuilder();
            if (searchKey != "")
            {
                strSql.Append(" ( searchkey LIKE @key1 OR content LIKE @key2 ) ");
                strSql.Append(" and type = @type ");
                SqlParameter[] parameters = {
					    new SqlParameter("@key1", SqlDbType.NVarChar,250),
                        new SqlParameter("@key2", SqlDbType.NVarChar,250),
                        new SqlParameter("@type", SqlDbType.Char,1)
			    };
                parameters[0].Value = string.Format("%{0}%", searchKey.Trim());
                parameters[1].Value = string.Format("%{0}%", searchKey.Trim());
                parameters[2].Value = type.Trim();

                DAL.course c = new DAL.course();
                foreach (DataRow itme in c.GetListByPage(pageIndex, strSql.ToString(), parameters, " time desc").Rows)
                {
                    list.Add(c.DataRowToModel_T(itme));
                }
                return list;
            }
            else 
            {
                strSql.Append(" type = @type ");
                SqlParameter[] parameters = {
                        new SqlParameter("@type", SqlDbType.Char,1)
			        };
                parameters[0].Value = type.Trim();
                DAL.course c = new DAL.course();
                foreach (DataRow itme in c.GetListByPage(pageIndex, strSql.ToString(), parameters, " time desc").Rows)
                {
                    list.Add(c.DataRowToModel_T(itme));
                }
                return list;

            }
            

        }
        /// <summary>
        /// 是否有视频教程
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public bool hasMovie(string searchKey)
        {
            return new DAL.course().Exists_T(searchKey);
        }
        
        /// <summary>
        /// 返回一共有多少个
        /// </summary>
        /// <param name="searchKey">搜索关键字</param>
        /// <param name="type">0图文 1视频</param>
        /// <returns></returns>
        public int GetCount(string searchKey, string type) 
        {
            if (searchKey != "")
            {
                int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" ( searchkey LIKE @key1 OR content LIKE @key2 ) ");
                strSql.Append(" and type = @type ");
                SqlParameter[] parameters = {
					        new SqlParameter("@key1", SqlDbType.NVarChar,250),
                            new SqlParameter("@key2", SqlDbType.NVarChar,250),
                            new SqlParameter("@type", SqlDbType.Char,1)
			        };
                parameters[0].Value = string.Format("%{0}%", searchKey.Trim());
                parameters[1].Value = string.Format("%{0}%", searchKey.Trim());
                parameters[2].Value = type.Trim();
                return Convert.ToInt32(new DAL.course().GetCount(strSql.ToString(), parameters));
            }
            else {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" type = @type ");
                SqlParameter[] parameters = {
                            new SqlParameter("@type", SqlDbType.Char,1)
			        };
                parameters[0].Value = type.Trim();
                return Convert.ToInt32(new DAL.course().GetCount(strSql.ToString(), parameters));

            }
        }

        /// <summary>
        /// 获取具体某个教程信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Views.courseMsg DataRowToSelectMsg(string id,string token = "") 
        {
            DAL.course c = new DAL.course();
            DataRow course = c.GetModelSelectMsg(id);

            return c.DataRowToSelectMsg(course, new BLL.course_().GetModelList("", "", id),token);
        }

        /// <summary>
        /// 获取最新trends
        /// </summary>
        /// <returns></returns>
        public List<Views.trends> GetNewTrends(int pageIndex,string token="") 
        {
            List<Views.trends> List = new List<Views.trends>();
            DAL.course c = new DAL.course();
            DataTable dt = c.GetListByPage(pageIndex, "", " time desc ");
            foreach (DataRow item in dt.Rows)
            {
                List.Add(c.DataRowToTrends(item, token));
            }
            return List;
        }

        //通过token获取我的教程
        public List<Views.trends> GetMyCourse(string type , string token)
        {
            string id = new Cook.DAL.load().GetIdByToken(token);
            List<Views.trends> List = new List<Views.trends>();
            DAL.course c = new DAL.course();

            DataTable dt = c.GetList(" authorid =" + id + " and type = " + type + " ", " time desc ");
            foreach (DataRow item in dt.Rows)
            {
                List.Add(c.DataRowToTrends(item, token));
            }
            return List;
        }

        //获取别人的教程
        public List<Views.trends> GetMyCoursebyid(string type, string id, string token="")
        {
            //string id = new Cook.DAL.load().GetIdByToken(token);
            List<Views.trends> List = new List<Views.trends>();
            DAL.course c = new DAL.course();

            DataTable dt = c.GetList(" authorid =" + id + " and type = " + type + " ", " time desc ");
            foreach (DataRow item in dt.Rows)
            {
                List.Add(c.DataRowToTrends(item, token));
            }
            return List;
        }
        public string getcoursenameByid(string id) 
        {
            return new Cook.DAL.course().getcoursenameByid(id);
        }

	}
}

