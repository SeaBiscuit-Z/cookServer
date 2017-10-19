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
    public class henchmanController : ApiController
    {
        [HttpGet]
        [Route("gethenchman")]
        public List<Views.userSign> gethenchman()
        {
            try
            {
                string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
                return new Cook.BLL.henchman_().gethenchman(token);
            }
            catch (Exception) {
                return null;
            }
        }

        [HttpGet]
        [Route("gethenchman/{id}")]
        public List<Views.userSign> gethenchmanid(string id)
        {
            try
            {
                return new Cook.BLL.henchman_().gethenchmanbyid(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // { "id" : "" , "type" : "" , "time" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("addhenchamn")]
        public bool addfollow([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            if (new Cook.BLL.users().addhenchman(common.getIdByToken(token)))
            {
                Cook.Model.henchman_ collect = new Cook.Model.henchman_();
                collect.id = Convert.ToInt32(json["id"]);
                collect.time = json["time"].ToString();
                return new Cook.BLL.henchman_().add(collect, token);
            }
            else {
                return false;
            }
        }
        //{ "id" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("deletehenchamn")]
        public bool delete([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            if (new Cook.BLL.users().delhenchman(common.getIdByToken(token)))
            {
                Cook.BLL.henchman_ collect = new Cook.BLL.henchman_();
                return collect.delete(token, json["id"].ToString());
            }
            else {
                return false;
            }
        }



        // GET api/henchman/5
        [HttpGet]
        public Cook.Model.henchman_  Get(string id,string tableid)
        {
            Cook.BLL.henchman_ c = new Cook.BLL.henchman_();
            Cook.Model.henchman_ msg = c.GetModel(id, tableid);
            return msg;
        }

        // POST api/henchman
        [HttpPost]
        public Cook.Model.henchman_ Post(JObject value)
        {
            Cook.BLL.henchman_ c = new Cook.BLL.henchman_();
            Cook.Model.henchman_ msg = c.GetModel(value["id"].ToString(), value["tableid"].ToString());
            return msg;
        }

    }
}
