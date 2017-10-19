using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
namespace Cook.BLL
{
	/// <summary>
	/// users
	/// </summary>
	public partial class users : baseBll<Model.users>
	{
        public override DAL.baseDal<Model.users> getDal()
        {
            return new DAL.users();
        }
		public users() { }
        /// <summary>
        /// 获取大厨数据
        /// </summary>
        /// <returns></returns>
        public List<Views.chef> GetChefList() 
        {
            List<Views.chef> chef = new List<Views.chef>();
            DAL.users user = new DAL.users();
            foreach(DataRow item in user.GetChefList().Rows)
            {
                chef.Add(user.DataRowToChef(item));
            }
            return chef;
        }

        /// <summary>
        /// 获取金牌大厨焦点图数据
        /// </summary>
        /// <returns></returns>
        public List<Views.chef> GetChefImgList()
        {
            List<Views.chef> chef = new List<Views.chef>();
            DAL.users user = new DAL.users();
            foreach (DataRow item in user.GetChefImgList().Rows)
            {
                chef.Add(user.DataRowToChef(item));
            }
            return chef;
        }

        /// <summary>
        /// 获得动态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<Views.trends> GetTrends(string id,int pageIndex,string token = "")
        {
            List<Views.trends> trends = new List<Views.trends>();
            Cook.DAL.course course = new DAL.course();
            foreach (DataRow item in new Cook.DAL.users().GetTrends(id, pageIndex).Rows)
            {
                trends.Add(course.DataRowToTrends(item, token));
            }
            return trends;
        }

        /// <summary>
        /// 获得user类型
        /// </summary>
        /// <returns></returns>
        public Views.user GetUser(string id)
        {
            DAL.users user = new DAL.users();
            return user.GetUser(id);
        }

        /// <summary>
        /// 有没有phone存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool ExistsPhone(string phone) 
        {
            return new Cook.DAL.users().ExistsPhone(phone);
        }

        //修改用户信息
        public bool setinfo(Cook.Model.users model,string token) 
        {
            int tableid = Convert.ToInt32(new Cook.DAL.load().GetIdByToken(token));
            return new DAL.users().setinfo(model,tableid);
        }

        public bool setbg(string bg,string token)
        {
            int tableid = Convert.ToInt32(new Cook.DAL.load().GetIdByToken(token));
            return new DAL.users().setbg(bg,tableid);
        }

        public bool setpagebg(string pagebg, string token) 
        {
            int tableid = Convert.ToInt32(new Cook.DAL.load().GetIdByToken(token));
            return new DAL.users().setpagebg(pagebg, tableid);
        }

        public bool addfollow(string id) 
        {
            return new Cook.DAL.users().setfollow(id,1);
        }

        public bool delfollow(string id)
        {
            return new Cook.DAL.users().setfollow(id, 0);
        }

        public bool addhenchman(string id)
        {
            return new Cook.DAL.users().sethenchman(id, 1);
        }

        public bool delhenchman(string id)
        {
            return new Cook.DAL.users().sethenchman(id, 0);
        }

        public string[] getuserinfo(string token) 
        {
            return new Cook.DAL.users().getuserinfo(token);
        }

        public string getAuthorName(int id)
        {
            return new Cook.DAL.users().getAuthorName(id);
        }
	}
}

