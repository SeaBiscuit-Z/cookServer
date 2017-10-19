using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    [EnableCors("http://localhost:8080", "*", "*")]
    public class AccountController : ApiController
    {
        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("validate/{code}")]
        public bool validateCode(string code)
        {
            try
            {
                if (code == HttpContext.Current.Session["LoginCode"].ToString())
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //根据token获取主页信息

        #region 用户登录授权
        /// <summary>  
        /// 用户登录授权  
        /// </summary>  
        /// <param name="name">用户名</param>  
        /// <param name="pwd">密码</param>  
        /// <returns></returns>
        /// { "phone" : "" ,"pwd":"" }
        [HttpPost]
        [Route("login")]
        public ResponseResult Login([FromBody]JObject json)
        {
            string name = json["phone"].ToString();
            string pwd = json["pwd"].ToString();
            //定义  
            ResponseResult obj = new ResponseResult();
            var model = common.GetLoginModel(name, pwd);
            if (model != null)
            {
                int userId = model.id;
                string Token = common.GetMd5_16(Guid.NewGuid().ToString());
                var dtNow = DateTime.Now;

                #region 将身份信息保存票据表中，验证当前请求是否是有效请求
                //判断此用户是否存在票据信息  
                if (new Cook.BLL.load().GetTicketByUserId(userId.ToString()) != null)
                {
                    //清空重置  
                    new Cook.BLL.load().DeleteByUserId(userId.ToString());
                }
                new Cook.BLL.load().AddByUserId(userId.ToString(), Token, dtNow.ToString(), dtNow.AddDays(7).ToString());
                #endregion

                //返回信息              
                obj.status = true;
                obj.message = "用户登录成功";
                JObject jo = new JObject();
                jo.Add("token", Token);
                obj.info = jo;
            }
            else
            {
                obj.status = false;
                obj.message = "用户登录失败";
            }
            //var resultObj = JsonConvert.SerializeObject(obj, Formatting.Indented);
            //HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(resultObj, Encoding.GetEncoding("UTF-8"), "application/json") };
            //return result;
            return obj;
        }
        #endregion

        #region 用户退出登录，清空Token
        /// <summary>  
        /// 用户退出登录，清空Token  
        /// </summary>  
        /// <param name="userId">用户ID</param>  
        /// <returns></returns>  
        [HttpGet]
        [Route("logout")]
        public ResponseResult LoginOut()
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            //定义  
            ResponseResult obj = new ResponseResult();
            try
            {
                //清空数据库该用户票据数据  
                new Cook.BLL.load().DeleteTokenByToken(token);
            }
            catch (Exception) { }
            //返回信息              
            obj.status = true;
            obj.message = "成功退出";
            return obj;
        }
        #endregion


        #region 查询Token是否有效
        /// <summary>  
        /// 查询Token是否有效  
        /// </summary>  
        /// <param name="token">token</param>  
        /// <returns></returns>
        [HttpGet]
        [Route("ValidateToken")]
        [AuthFilterOutside]
        public Models.ResponseResult ValidateToken()
        {
            string token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            ResponseResult obj = new ResponseResult();
            obj.status = true;
            obj.message = "token有效";
            JObject json = new JObject();
            string url = new Cook.BLL.load().GetUrlByToken(token);
            json.Add("url", url);
            obj.info = json;
            return obj;
        }
        #endregion

        
        
    }
}
