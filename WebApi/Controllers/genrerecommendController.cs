using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [RoutePrefix("api")]
    public class genrerecommendController : ApiController
    {
        // GET api/genrerecommend
        [HttpGet]
        [Route("rerecommend")]
        public List<Views.content_T<Views.course_T>> Get()
        {
            Cook.BLL.genreRecommend g = new Cook.BLL.genreRecommend();
            return g.getAllGenreRecommend_T();
        }

    }
}
