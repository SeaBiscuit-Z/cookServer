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
    public class loadController : ApiController
    {
        // GET api/load
        /// <summary>
        /// 验证手机号是否存在
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ValidatorPhone/{phone}")]
        public bool Get(string phone)
        {
            return new Cook.BLL.users().ExistsPhone(phone);
        }

        //{ "phone" : "", "pwd" : "" }
        [HttpPost]
        [Route("register")]
        public Models.ResponseResult register([FromBody]JObject json) 
        {
            try {
                int id = new Cook.BLL.load().register(json["phone"].ToString(), json["pwd"].ToString());
                if (id !=0 )
                {
                    Models.ResponseResult obj = new Models.ResponseResult();

                    string Token = common.GetMd5_16(Guid.NewGuid().ToString());
                    var dtNow = DateTime.Now;
                    new Cook.BLL.load().AddByUserId(id.ToString(), Token, dtNow.ToString(), dtNow.AddDays(7).ToString());
                    //返回信息              
                    obj.status = true;
                    obj.message = "用户注册成功";
                    JObject jo = new JObject();
                    jo.Add("token", Token);
                    obj.info = jo;
                    return obj;
                }
                else {
                    return null;
                }
            }
            catch(Exception) {
                return null;
            }
        }

        // POST api/load
        [HttpPost]
        public string Post()
        {
            string x = System.Web.HttpContext.Current.Request.Cookies["user"].Value;
            JObject user = JObject.Parse(x);
            return user["phone"].ToString() + user["pwd"];
        }
    }
}
