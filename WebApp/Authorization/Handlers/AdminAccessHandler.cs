using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.Authorization.Handlers
{
    public class AdminAccessHandler : AuthorizationHandler<AdminAccessRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly IUnitOfWork _unitOfWork;

        public AdminAccessHandler(IHttpContextAccessor httpContextAccesor)//, IUnitOfWork unitOfWork)
        {
            _httpContextAccesor = httpContextAccesor;
            //_unitOfWork = unitOfWork;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            AdminAccessRequirement requirement)
        {
            context.Succeed(requirement);
            //context.Fail();
        }
    }
}
