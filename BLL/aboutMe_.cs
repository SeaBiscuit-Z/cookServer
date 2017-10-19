using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cook.BLL
{
    public class aboutMe_ : baseBllById<Cook.Model.aboutMe_>
    {
        public override DAL.baseDalById<Model.aboutMe_> getDal()
        {
            return new DAL.aboutMe_();
        }
        public aboutMe_() { }

        /// <summary>
        /// 获得关于我分页信息
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public List<Model.aboutMe_> GetAboutMeNoRead(string token)
        {
            return DataTableToList(new Cook.DAL.aboutMe_().GetAboutMeNoRead(token));
        }

        /// <summary>
        /// 获得关于我分页信息
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public List<Model.aboutMe_> GetAboutMeRead(string token)
        {
            return DataTableToList(new Cook.DAL.aboutMe_().GetAboutMeRead(token));
        }

        public bool setRead(string token,int id) 
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return new DAL.aboutMe_().setRead(tableid,id);
        }
        public bool setRead(string token)
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            return new DAL.aboutMe_().setRead(tableid);
        }

        public bool addContent(Cook.Model.aboutMe_ model, string id)
        {
            return new Cook.DAL.aboutMe_().addContent(model,id);
        }

        public bool addfollow(Cook.Model.aboutMe_ model, string id)
        {
            return new Cook.DAL.aboutMe_().addfollow(model, id);
        }

    }
}
