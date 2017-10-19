using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors("http://localhost:8080", "*", "*")]
    public class usersController : ApiController
    {
        ///添加信息
        /*[HttpGet]
        [Route("TTT")]
        public void TTT() 
        {
            for (int i = 1; i <= 16; i++)
            {
                new Cook.BLL.follow_().creatTable(i.ToString());
                new Cook.BLL.henchman_().creatTable(i.ToString());
                new Cook.BLL.aboutMe_().creatTable(i.ToString());
                new Cook.BLL.collect_().creatTable(i.ToString());
                //添加关注
                for (int l = 1; l <= 4; l++)
                {
                    Cook.BLL.follow_ f = new Cook.BLL.follow_();
                    Cook.Model.follow_ follow = new Cook.Model.follow_();
                    follow.id = l;
                    follow.time = "201702060506";
                    f.Add(follow, i.ToString());
                    //添加aboutme
                    Cook.Model.aboutMe_ model = new Cook.Model.aboutMe_();
                    Cook.BLL.aboutMe_ about = new Cook.BLL.aboutMe_();
                    model.sourceId = l;
                    model.sourceName = new Cook.BLL.users().getAuthorName(l);
                    model.time = "201709021205";
                    model.type = "2";
                    model.isRead = "0";
                    about.Add(model,i.ToString());
                }
                //添加粉丝
                for (int p = 1; p <= 3; p++)
                {
                    Cook.BLL.henchman_ hen = new Cook.BLL.henchman_();
                    Cook.Model.henchman_ henchamn = new Cook.Model.henchman_();
                    henchamn.id = p;
                    henchamn.time = "201702060506";
                    hen.Add(henchamn, i.ToString());

                }



            }
            for (int j = 1; j <= 26; j++) 
            {
                new Cook.BLL.course_().creatTable(j.ToString());
                new Cook.BLL.discuss_().creatTable(j.ToString());
            }

            //给图文教程添加具体内容
             for (int n = 1; n <= 26; n++)
             {
                 for (int m = 1; m <= 4; m++) 
                 {
                     Cook.BLL.discuss_ discuss = new Cook.BLL.discuss_();
                     Cook.Model.aboutMe_ about = new Cook.Model.aboutMe_();
                     about.sourceId = m;
                     about.sourceName = new Cook.BLL.users().getAuthorName(m);
                     about.targetId = n;
                     about.targetName = new Cook.BLL.course().getcoursenameByid(n.ToString());
                     about.time = "201709031403";
                     about.type = "1";
                     about.isRead = "0";
                     switch (m) 
                     {
                         case 1:
                             about.content = "很不错的教程,谢谢";
                             break;
                         case 2:
                             about.content = "教程很详细,加油";
                             break;
                         case 3:
                             about.content = "谢谢老师";
                             break;
                         case 4:
                             about.content = "师傅教程太棒了";
                             break;
                     }
                     discuss.addDis(about, n.ToString());
                 }

                Cook.BLL.course_ c = new Cook.BLL.course_();
                 Cook.Model.course_ course = new Cook.Model.course_();
                 if (n == 18 || n == 19 || n == 20 || n == 21)
                 {
                     course.img = "/static/movie/movie.jpg";
                     course.num = 1;
                     course.title = "";
                     course.content = "/static/movie/t.mp4";
                     c.Add(course, n.ToString());
                 }
                 for (int m = 1; m <= 4; m++)
                 {
                     course.num = m;
                     if (m == 1)
                     {
                         course.img = "/static/procedure/zb.jpg";
                         course.title = "准备步骤";
                         course.content = "龙虾2kg,红辣椒2个，辣椒油,鸡精,盐,糖";
                     }
                     else if (m == 2)
                     {
                         course.img = "/static/procedure/qc.jpg";
                         course.title = "切菜";
                         course.content = "参数参参数参数参数,数参数,参数参数参参数";
                     }
                     else {
                         course.img = "";
                         course.title = "";
                         course.content = "参数参参数数参数,参数参数,参数参数";
                     }
                     c.Add(course, n.ToString());
                 }
             }
        }*/
   
        [HttpGet]
        [Route("user")]
        public Views.user userinfo() 
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                Cook.BLL.users user = new Cook.BLL.users();
                return user.GetUser(common.getIdByToken(token));
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("user/{id}")]
        public Views.user userinfo(int id)
        {
            try
            {
                Cook.BLL.users user = new Cook.BLL.users();
                return user.GetUser(id.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/chef
        [HttpGet]
        [Route("chef")]
        public List<Views.chef> chef()
        {
            List<Views.chef> chef = new Cook.BLL.users().GetChefList();
            chef.Reverse();
            return chef;
        }

        [HttpGet]
        [Route("chefImg")]
        public List<Views.chef> chefImg()
        {
            return new Cook.BLL.users().GetChefImgList();
        }

        [HttpGet]
        [Route("aboutMe")]
        public List<Cook.Model.aboutMe_> aboutMe()
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                Cook.BLL.aboutMe_ about = new Cook.BLL.aboutMe_();
                List<Cook.Model.aboutMe_> list = about.GetAboutMeNoRead(token);
                about.setRead(token);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("aboutMeRead")]
        public List<Cook.Model.aboutMe_> aboutMeRead()
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                Cook.BLL.aboutMe_ about = new Cook.BLL.aboutMe_();
                List<Cook.Model.aboutMe_> list = about.GetAboutMeRead(token);
                about.setRead(token);
                return list;

            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("setRead")]
        public bool setRead([FromBody]JObject json) 
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                return new Cook.BLL.aboutMe_().setRead(token, Convert.ToInt32(json["id"]));
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("setInfo")]
        public bool setInfo([FromBody]JObject json)
        {
            try
            {
                string[] skill = new string[1] { json["skill"].ToString() };
                string[] honor = new string[1] { json["honor"].ToString() };
                Cook.Model.users model = new Cook.Model.users();
                model.name = json["name"].ToString();
                model.sex = json["sex"].ToString();
                model.skill = skill;
                model.honor = honor;
                model.introdice = json["introdice"].ToString();
                model.email = json["Email"].ToString();
                model.address = json["address"].ToString();
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                Cook.BLL.users user = new Cook.BLL.users();
                return user.setinfo(model, token);
            }
            catch (Exception) 
            {
                return false;
            }
        }

        [HttpGet]
        [Route("bg")]
        public string[] getbg() 
        {
            string[] bg = new string[] { "./static/user/user-bg1.jpg","./static/user/user-bg2.jpg","./static/user/user-bg3.jpg" };
            return bg;
        }

        [HttpPost]
        [Route("setbg")]
        public bool setbg([FromBody]JObject json) 
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            return new Cook.BLL.users().setbg(json["bg"].ToString(), token);
        }

        [HttpPost]
        [Route("setpagebg")]
        public bool setpagebg([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            return new Cook.BLL.users().setpagebg(json["pagebg"].ToString(), token);

        }

    }
}
