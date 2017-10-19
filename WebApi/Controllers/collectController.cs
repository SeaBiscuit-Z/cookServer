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
    public class collectController : ApiController
    {
        // api/collect
        /// <summary>
        /// { "courseId":"","userId":"" } 获取课程是否已收藏
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        [AuthFilterOutside]
        [Route("collect")]
        public bool isCollect([FromBody]JObject json) 
        {
            try
            {
                Cook.BLL.collect_ collect = new Cook.BLL.collect_();
                return collect.Exists(json["courseId"].ToString(), json["userId"].ToString());
            }
            catch (Exception)
            {
                return false;
            }
        }

        //{ "id" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("collectD")]
        public bool delete([FromBody]JObject json) 
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            Cook.BLL.collect_ collect = new Cook.BLL.collect_();
            return collect.delete(token,json["id"].ToString());
        }

        // { "id" : "" , "type" : "" , "time" : "" }
        [HttpPost]
        [AuthFilterOutside]
        [Route("collectA")]
        public bool add([FromBody]JObject json)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            Cook.Model.collect_ collect = new Cook.Model.collect_();
            collect.id = Convert.ToInt32(json["id"]);
            collect.type = json["type"].ToString();
            collect.time = json["time"].ToString();
            return new Cook.BLL.collect_().add(collect,token);
        }

        //获取自己的关注
        [HttpGet]
        [Route("mycollect")]
        public List<Views.trends> GetMyCollect()
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            return new Cook.BLL.collect_().GetMyCollect(token);
        }

        //GetMyCollectbyid
        [HttpGet]
        [Route("collectid/{id}")]
        public List<Views.trends> GetMyCollect(string id)
        {
            return new Cook.BLL.collect_().GetMyCollectbyid(id);
        }
    }
}
