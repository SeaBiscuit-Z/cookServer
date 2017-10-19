using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cook.BLL
{
    public partial class collect_ : baseBllById<Cook.Model.collect_>
    {
        public override DAL.baseDalById<Model.collect_> getDal()
        {
            return new DAL.collect_();
        }
        public collect_() { }

        public bool delete(string token, string id) 
        {
            return new Cook.DAL.collect_().delete(token, id);
        }
        public bool add(Cook.Model.collect_ model, string token)
        {
            return new Cook.DAL.collect_().add(model, token);
        }
        //我的收藏
        public List<Views.trends> GetMyCollect(string token) 
        {
            string tableid = new Cook.DAL.load().GetIdByToken(token);
            List<Views.trends> mycollect = new List<Views.trends>();
            DAL.course course = new DAL.course();
            DataTable dt = new DAL.collect_().getmycollect(tableid);
            foreach (DataRow itme in dt.Rows)
            {
                mycollect.Add(course.DataRowToTrends(itme));
            }
            return mycollect;
        }

        //我的收藏
        public List<Views.trends> GetMyCollectbyid(string tableid)
        {
            //string tableid = new Cook.DAL.load().GetIdByToken(token);
            List<Views.trends> mycollect = new List<Views.trends>();
            DAL.course course = new DAL.course();
            DataTable dt = new DAL.collect_().getmycollect(tableid);
            foreach (DataRow itme in dt.Rows)
            {
                mycollect.Add(course.DataRowToTrends(itme));
            }
            return mycollect;

        }

    }
}
