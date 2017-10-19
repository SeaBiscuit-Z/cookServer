using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
namespace Cook.BLL
{
	/// <summary>
	/// follow_1
	/// </summary>
    public partial class follow_ : baseBllById<Model.follow_>
	{
        public override DAL.baseDalById<Model.follow_> getDal()
        {
            return new DAL.follow_();
        }
		public follow_() { }

        public List<Views.userSign> getFollow(string token) 
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return getFollowbyid(tableid);
        }

        public List<Views.userSign> getFollowbyid(string id)
        {
            List<Views.userSign> signList = new List<Views.userSign>();
            Cook.DAL.follow_ follow = new Cook.DAL.follow_();
            Cook.DAL.users user = new DAL.users();
            List<Cook.Model.follow_> followList = DataTableToList(follow.GetList("", "", id));
            foreach (Cook.Model.follow_ item in followList)
            {
                Views.userSign sign = follow.getFollow(user.GetModel(item.id.ToString()));
                sign.time = item.time;
                signList.Add(sign);
            }
            return signList;
        }

        public bool delete(string token, string id)
        {
            return new Cook.DAL.follow_().delete(token, id);
        }

        public bool add(Cook.Model.follow_ model, string token)
        {
            return new Cook.DAL.follow_().add(model, token);
        }

        public bool addfoll(Model.aboutMe_ model,string id) 
        {
            return new Cook.DAL.follow_().addfoll(model,id);
        }



	}
}

