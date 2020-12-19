using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Authorization.Handlers
{
    public class UserAccessHandler : AuthorizationHandler<UserAccessRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UserAccessHandler(IHttpContextAccessor httpContextAccesor)
        {
            _httpContextAccesor = httpContextAccesor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            UserAccessRequirement requirement)
        {
            context.Succeed(requirement);
            //context.Fail();
        }
    }
}
