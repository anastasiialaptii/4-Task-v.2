using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class SessionManager
    {
        public SessionModel CreateHttpContext(HttpContextBase httpContext)
        {
            SessionModel sessionContext = new SessionModel()
            {
                HttpContext = httpContext
            };
            return sessionContext;
        }
    }
}