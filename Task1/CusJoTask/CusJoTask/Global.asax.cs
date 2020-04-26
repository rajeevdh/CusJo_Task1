using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CusJoTask.App_Start;
using Newtonsoft.Json;
using System.Web.Security;
using CusJoTask.Models;

namespace CusJoTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

          //  UserDBContext.SetInitializer<UserDBContext>(null);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                newUser.Name = serializeModel.Name;
                newUser.EmailId = serializeModel.Email;
                newUser.Roles = serializeModel.roles;

                HttpContext.Current.User = newUser;
            }
        }

        public class CustomPrincipalSerializeModel
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string roles { get; set; }
        }
    }
}
