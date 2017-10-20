using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    public class headrecommendController : ApiController
    {
        // GET api/headrecommend/5
        //首页图片
        [HttpGet]
        [Route("mainImg")]
        public List<Views.headrecommend_T> Get()
        {
            Cook.BLL.HeadRecommend hr = new Cook.BLL.HeadRecommend();

            return hr.GetModel_T();
        }

    }
}
