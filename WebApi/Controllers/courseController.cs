using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cook;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Web.Http.Cors;
using System.Web;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors("http://localhost:8080", "*", "*")]
    public class courseController : ApiController
    {
        //评分排名
        // GET api/course
        [HttpGet]
        [Route("courseTop")]
        public Views.content_T<Views.courseTop> courseTop()
        {
            return new Cook.BLL.course().GetListTop();
        }

        //最新动态
        // GET api/course
        [HttpGet]
        [Route("trends/{index}")]
        public List<Views.trends> courseTop(int index)
        {
            string token = "";
            try
            {
                token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                return new Cook.BLL.course().GetNewTrends(index,token);
            }
            catch (Exception) {
                token = "";
                return new Cook.BLL.course().GetNewTrends(index);
            }
        }
        //首页
        // GET api/course/5
        [HttpGet]
        [Route("home/{id}")]
        public Cook.Model.HeadRecommend home(string id)
        {
            Cook.BLL.HeadRecommend c = new Cook.BLL.HeadRecommend();
            Cook.Model.HeadRecommend msg = c.GetModel(id);
            return msg;
        }
        //搜索
        // POST api/course  {"pageIndex": "1" , "key" : "是" , "type":"0"}
        [HttpPost]
        [Route("select")]
        public Views.select select([FromBody]JObject json)
        {
            try {
                //请求哪一页
                int pageIndex;
                Int32.TryParse(json["pageIndex"].ToString(), out pageIndex);
                //搜索关键字
                string key = json["key"].ToString();
                //教程类型
                string type = json["type"].ToString();
                Views.select s = new Views.select();
                Cook.BLL.course c = new Cook.BLL.course();
                s.hasMovie = c.hasMovie(key);
                s.newPage = pageIndex.ToString();
                s.allCount = c.GetCount(key, type);
                s.content = c.GetListToSelect(pageIndex, key, type);
                return s;
            }
            catch(Exception)
            {
                return null;
            }
        }

        //某一具体教程
        //{"id":"17"}
        [HttpGet]
        [Route("courseMsg/{id}")]
        public Views.courseMsg courseMsg(string id)
        {
            try {
                string token = "";
                try
                {
                    token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                }
                catch (Exception) {
                    token = "";
                }
                Cook.BLL.course course = new Cook.BLL.course();
                return course.DataRowToSelectMsg(id, token);
            }
            catch(Exception){
                return null;
            }
        }

        //获取我的推送消息
        [HttpGet]
        [Route("mytrends/{pageIndex}")]
        public List<Views.trends> trends(string pageIndex)
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                Cook.BLL.users user = new Cook.BLL.users();
                return user.GetTrends(new Cook.BLL.load().GetIdByToken(token), Convert.ToInt32(pageIndex), token);
            }
            catch (Exception) {
                return new List<Views.trends>();
            }
        }

        //获取自己发布的教程
        //{ "type" : "" }
        [HttpPost]
        [Route("mycourse")]
        public List<Views.trends> mycourse([FromBody]JObject json) 
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                return new Cook.BLL.course().GetMyCourse(json["type"].ToString(), token);
            }
            catch (Exception) {
                return null;
            }
        }

        //通过id获取别人发布的教程{ "id": "" , "type" : "" }
        [HttpPost]
        [Route("courseid")]
        public List<Views.trends> Getcoursebyid([FromBody]JObject json)
        {
            string token = "";
            try
            {
                token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            }
            catch (Exception)
            {
                token = "";
            }
            return new Cook.BLL.course().GetMyCoursebyid(json["type"].ToString(), json["id"].ToString(), token);
        }

        //{  "targetid" : "" ,"targetName" : "" , "content" : "" , "time" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("discuss")]
        public bool discuss([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            string[] info = new Cook.BLL.users().getuserinfo(token);

            Cook.Model.aboutMe_ model = new Cook.Model.aboutMe_();
            model.sourceId = Convert.ToInt32(info[0]);
            model.sourceName = info[1];
            model.time = json["time"].ToString();
            model.targetId = Convert.ToInt32(json["targetid"]);
            model.targetName = json["targetname"].ToString();
            model.content = json["content"].ToString();
            string id = model.targetId.ToString();
            return new Cook.BLL.discuss_().addDis(model, id);
        }

        [HttpGet]
        [Route("getdiscuss/{id}")]
        public List<Views.discuss> getdiscuss(string id)
        {
            try
            {
                return new Cook.BLL.discuss_().getdiscuss(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("setread/{id}")]
        public bool setread(int id) 
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            return new Cook.BLL.aboutMe_().setRead(token,id);
        }

    }
}
