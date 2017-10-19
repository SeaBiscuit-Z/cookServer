using System;
using System.Collections.Generic;
using System.Text;

namespace Cook.BLL
{
    public partial class load :baseBll<Model.load>
    {

        public override DAL.baseDal<Model.load> getDal()
        {
            return new DAL.load();
        }
        public load() { }

        public int phoneValidate(string phone)
        {
            return new DAL.load().phoneValidate(phone);
        }
        /// <summary>
        /// 登录验证 0:密码错误 正数 : 成功  -2:phone错误  -3:账号已被冻结  -4: 数据库出错 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int loadValidate(string phone,string pwd)
        {
            return new DAL.load().loadValidate(phone, pwd);
        }

        public Model.load GetTicketByUserId(string id)
        {
            return new DAL.load().GetTicketByUserId(id);
        }

        public bool DeleteByUserId(string id) {
            return new DAL.load().DeleteByUserId(id);
        }

        /// <summary>
        /// 清除token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTokenByToken(string token)
        {
            return new DAL.load().DeleteTokenByToken(token);
        }
        /// <summary>
        /// 添加token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AddByUserId(string id, string token, string CreateDate, string ExpireDate)
        {
            return new DAL.load().AddByUserId(id, token, CreateDate, ExpireDate);
        }
        /// <summary>
        /// 根据token返回一个load模型数据
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Model.load GetTicketByToken(string token)
        {
            return new DAL.load().GetTicketByToken(token);
        }
        /// <summary>
        /// 根据用户名，密码返回一个load模型数据
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Model.load GetModelByUser(string phone, string pwd)
        {
            return new DAL.load().GetModelByUser(phone, pwd);
        }

        /// <summary>
        /// 根据token返回头像
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetUrlByToken(string token) 
        {
            return new Cook.DAL.load().GetUrl(token);
        }

        //注册
        public int register(string phone, string pwd)
        {
            int id = 0;
            try
            {
                Model.load load = new Model.load();
                load.phone = phone;
                load.pwd = pwd;
                load.status = "0";
                if (Add(load))
                {
                    id = new Cook.DAL.load().GetUserIdByInfo(phone, pwd);
                    Model.users user = new Model.users();
                    user.id = id;
                    user.name = phone;
                    user.type = "1";
                    user.url = "man0";
                    user.bg = "#ffffff";
                    user.pagebg = "./static/user/user-bg3.jpg";
                    user.henchman = 0;
                    user.follow = 0;
                    user.phone = phone;
                    user.status = "0";
                    if (new DAL.users().Add(user))
                    {
                        new Cook.BLL.henchman_().creatTable(id.ToString());
                        new Cook.BLL.follow_().creatTable(id.ToString());
                        new Cook.BLL.aboutMe_().creatTable(id.ToString());
                        new Cook.BLL.collect_().creatTable(id.ToString());
                        return id;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //根据token获取id
        public string GetIdByToken(string token) 
        {
            return new DAL.load().GetIdByToken(token);
        }

    }
}
