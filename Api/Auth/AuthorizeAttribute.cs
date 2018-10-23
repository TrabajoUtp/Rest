using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;

namespace Api
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                var algo = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Acceso no autorizado");
                actionContext.Response = algo; //new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
}