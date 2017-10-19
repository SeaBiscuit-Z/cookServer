using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Cook.Model;
namespace Cook.BLL
{
	/// <summary>
	/// henchman_1
	/// </summary>
    public partial class henchman_ : baseBllById<Model.henchman_>
	{
        public override DAL.baseDalById<Model.henchman_> getDal()
        {
            return new DAL.henchman_();
        }
        public henchman_() { }

        public List<Views.userSign> gethenchman(string token)
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return gethenchmanbyid(tableid);
        }

        public List<Views.userSign> gethenchmanbyid(string id)
        {
            List<Views.userSign> signList = new List<Views.userSign>();
            Cook.DAL.henchman_ hen = new Cook.DAL.henchman_();
            Cook.DAL.users user = new DAL.users();
            List<Cook.Model.henchman_> followList = DataTableToList(hen.GetList("", "", id));
            foreach (Cook.Model.henchman_ item in followList)
            {
                Views.userSign sign = hen.gethenchman(user.GetModel(item.id.ToString()));
                sign.time = item.time;
                signList.Add(sign);
            }
            return signList;
        }

        public bool delete(string token, string id)
        {
            return new Cook.DAL.henchman_().delete(token, id);
        }
        public bool add(Cook.Model.henchman_ model, string token)
        {
            return new Cook.DAL.henchman_().add(model, token);
        }


	}
}

