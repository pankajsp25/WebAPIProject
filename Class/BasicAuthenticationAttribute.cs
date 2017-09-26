﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;
using System.Security.Principal;
using System.Threading;



namespace WebAPI
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            else
            {
                string atoken = actionContext.Request.Headers.Authorization.Parameter;
                string decodetoken = Encoding.UTF8.GetString(Convert.FromBase64String(atoken));
                string[] usernamepassarray = decodetoken.Split(':');
                string UserName = usernamepassarray[0];
                string Password = usernamepassarray[1];

                if (EmpSecurity.Login(UserName, Password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }


            }
        }
    }
}