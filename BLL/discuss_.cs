using System;
using System.Collections.Generic;
using System.Text;

namespace Cook.BLL
{
    public partial class discuss_ : baseBllById<Model.discuss_>
    {
        public override DAL.baseDalById<Model.discuss_> getDal()
        {
            return new DAL.discuss_();
        }
        public discuss_() { }

        public bool addDis(Cook.Model.aboutMe_ model, string tableid)
        {
            return new DAL.discuss_().addDis(model, tableid);
        }
        /// <summary>
        /// 获取discuss集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Views.discuss> getdiscuss(string id)
        {
            List<Views.discuss> discuss = new List<Views.discuss>();
            List<Cook.Model.discuss_> dis = new discuss_().GetModelList("", "", id);
            foreach (Cook.Model.discuss_ item in dis) 
            {
                Views.discuss model = new Views.discuss();
                model.id = item.id;
                model.content = item.content;
                model.time = item.time;
                string[] str = new Cook.DAL.users().getinfo(item.id);
                model.name = str[0];
                model.url = str[1];
                discuss.Add(model);
            }
            return discuss;
        }
    }
}
