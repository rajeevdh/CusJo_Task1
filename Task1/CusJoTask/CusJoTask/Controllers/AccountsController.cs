using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CusJoTask.Models;
using CusJoTask.ViewModels;
using Newtonsoft.Json;
using System.Web.Security;


namespace CusJoTask.Controllers
{
    public class AccountsController : UserdataController
    {
        private UserDBContext _context;

            public AccountsController()
        {
            _context = new UserDBContext();
        }
        //
        // GET: /Account/

       [AllowAnonymous]
       public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(u => u.Name == loginUser.Name && u.EmailId == loginUser.EmailId).FirstOrDefault();
                if (user != null)
                {
                    byte roles = user.RoleID;

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.Name = user.Name;
                    serializeModel.Email = user.EmailId;
                    serializeModel.roles = _context.Roles.FirstOrDefault(c => c.RoleId == roles).RoleName;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    user.EmailId,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    false, //pass here true, if you want to implement remember me functionality
                    userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);

                    if (userData.Contains("Admin"))
                    {
                        return RedirectToAction("AdminView", "Home");
                    }
                    else if (userData.Contains("Staff"))
                    {
                        return RedirectToAction("StaffView", "Home");
                    }
                    else if (userData.Contains("EndUser"))
                    {
                        return RedirectToAction("EndUserView", "Home");
                    }
                    else
                    {
                        return RedirectToAction("LoginPage", "Accounts");
                    }
                }

                ModelState.AddModelError("", "Login Failed");
            }

            return RedirectToAction("LoginPage","Accounts");
        }

        public class CustomPrincipalSerializeModel
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string roles { get; set; }
        }

        public ActionResult AccessDenied()
        {
            return Content("Access Denied");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginPage", "Accounts", null);
        }

    }
}