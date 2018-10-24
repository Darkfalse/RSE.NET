using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _WebApp.Infrastructure {
    public class AuthRequiredAttribute : AuthorizeAttribute {

        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            return EmployeeSession.CurrentEmployee != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
        }
    }
}