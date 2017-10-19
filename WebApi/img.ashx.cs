using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    /// <summary>
    /// img 的摘要说明
    /// </summary>
    public class img : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            ValidateCode code = new ValidateCode();
            string VCode = code.CreateValidateCode(5);
            code.CreateValidateGraphic(VCode, context);
            HttpContext.Current.Session["LoginCode"] = VCode;

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}