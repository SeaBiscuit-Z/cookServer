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
