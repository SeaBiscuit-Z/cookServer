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
    [EnableCors("http://localhost:8080", "*", "*")]
    public class searchController : ApiController
    {
        // GET api/search
        //搜索排行前十
        [HttpGet]
        [Route("searchTop")]
        public Views.content_T<Cook.Model.search> searchTop()
        {
            Cook.BLL.search s = new Cook.BLL.search();

            return s.GetListTop();
        }

        //热门搜索
        [HttpGet]
        [Route("hotSelect")]
        public List<Cook.Model.search> hotSelect()
        {
            return new Cook.BLL.search().GetHotTop();
        }


        [HttpPost]
        public List<Cook.Model.search> Post(string num)
        {
            int n;
            Int32.TryParse(num,out n);
            Cook.BLL.search s = new Cook.BLL.search();

            return s.DataTableToList(s.GetList(n, "", " num desc "));
        }
        

    }
}
