using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace List_Little_Api.Authorization
{
	public class AuthorizeRolesAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!(context.HttpContext.User.IsInRole("Admin") || context.HttpContext.User.IsInRole("Manager")))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}

