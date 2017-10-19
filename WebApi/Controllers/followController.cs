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
    public class followController : ApiController
    {
        [HttpGet]
        [Route("getfollow")]
        public List<Views.userSign> getfollow()
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                return new Cook.BLL.follow_().getFollow(token);
            }
            catch (Exception) {
                return null;
            }
        }

        [HttpGet]
        [Route("getfollow/{id}")]
        public List<Views.userSign> getfollowid(string id)
        {
            try
            {
                return new Cook.BLL.follow_().getFollowbyid(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // { "id" : "" , "time" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("addfollow")]
        public bool addfollow([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            if (new Cook.BLL.users().addfollow(common.getIdByToken(token)))
            {
                //添加到about
                string[] info = new Cook.BLL.users().getuserinfo(token);

                Cook.Model.aboutMe_ model = new Cook.Model.aboutMe_();
                model.sourceId = Convert.ToInt32(info[0]);
                model.sourceName = info[1];
                model.time = json["time"].ToString();
                string id = json["id"].ToString();
                new Cook.BLL.follow_().addfoll(model, id);

                //改follow
                Cook.Model.follow_ collect = new Cook.Model.follow_();
                collect.id = Convert.ToInt32(json["id"]);
                collect.time = json["time"].ToString();
                return new Cook.BLL.follow_().add(collect, token);
            }
            else {
                return false;
            }
            
        }
        //{ "id" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("deletefollow")]
        public bool delete([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            if (new Cook.BLL.users().delfollow(common.getIdByToken(token)))
            {
                Cook.BLL.follow_ collect = new Cook.BLL.follow_();
                return collect.delete(token, json["id"].ToString());
            }
            else {
                return false;
            }
        }

        [HttpGet]
        [Route("isfollow/{id}")]
        public bool isfollow(int id) 
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                return new Cook.BLL.follow_().Exists(id.ToString(), common.getIdByToken(token));
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
