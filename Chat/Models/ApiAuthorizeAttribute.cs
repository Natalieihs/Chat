using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Chat.Models
{
    /// <summary>
    /// 身份拦截器
    /// </summary>
    public class ApiAuthorizeAttribute:AuthorizeAttribute
    {
        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, IRequest request)
        {
            var token = request.QueryString.Get("Bearer");
            if (string.IsNullOrEmpty(token)) return false;

            try
            {
                UserInfo userInfo = Help.JwtHelp.GetJwtDecode(token);
                if (userInfo==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            //return base.AuthorizeHubMethodInvocation(hubIncomingInvokerContext, appliesToMethod);
            return false;
        }
        protected override bool UserAuthorized(IPrincipal user)
        {
            return true;
        }
    }
}