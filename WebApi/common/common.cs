using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebApi.Models;

namespace WebApi
{
    public class common
    {
        /// <summary>
        /// 小写16位
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5_16(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");

            t2 = t2.ToLower();

            return t2;
        }

        #region 验证票据是否有效
        /// <summary>  
        /// 验证票据是否有效  
        /// </summary>  
        /// <param name="encryptToken">token</param>  
        /// <returns></returns>  
        public static bool ValidateTicket(string encryptToken)
        {
            bool flag = false;
            try
            {
                //获取数据库Token  
                Cook.Model.load model = new Cook.BLL.load().GetTicketByToken(encryptToken);
                if (model.token == encryptToken) //存在  
                {
                    //未超时  
                    flag = (DateTime.Now <= Convert.ToDateTime(model.expiredate)) ? true : false;
                }
            }
            catch (Exception) { }
            return flag;
        }
        #endregion

        
        /// <summary>
        /// 根据token获取id
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string getIdByToken(string token)
        {
            try
            {
                //获取数据库Token  
                Cook.Model.load model = new Cook.BLL.load().GetTicketByToken(token);
                if (model.token == token) //存在  
                {
                    //未超时  
                    if ((DateTime.Now <= Convert.ToDateTime(model.expiredate)) ? true : false)
                    {
                        return model.id.ToString();
                    }
                }
            }
            catch (Exception) { }
            return "";
        }

        #region 用户登录
        /// <summary>  
        /// 用户登录  
        /// </summary>  
        /// <param name="userName">用户名</param>  
        /// <param name="userPwd">密码</param>  
        /// <returns></returns>
        public static Cook.Model.load GetLoginModel(string userName, string userPwd)
        {
            Cook.Model.load model = new Cook.Model.load();
            try
            {
                if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(userPwd))
                {
                    //数据库比对  
                    model = new Cook.BLL.load().GetModelByUser(userName, userPwd);//common.GetMd5_16()
                }
            }
            catch (Exception) { }
            return model;
        }
        #endregion 
    }
}