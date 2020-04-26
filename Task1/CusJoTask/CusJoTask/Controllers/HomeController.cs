using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CusJoTask.ViewModels;
using CusJoTask.Models;
using System.Data.Entity;
using CusJoTask.Security;

namespace CusJoTask.Controllers
{
   [Authorize]
    public class HomeController : UserdataController
    {

        private UserDBContext _context;

        public HomeController()
        {
            _context = new UserDBContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult AdminView()
        {
            AdminViewModel adminView = new AdminViewModel();

            adminView.allUsers = _context.Users.Include(c => c.Role).ToList();
            adminView.allRoles = _context.Roles.ToList();
           
            return View(adminView);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult SaveUserPermission(int UserId, byte RoleId)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(c => c.UserId == UserId);
                user.RoleID = RoleId;
                _context.SaveChanges();
            }

            catch
            {
                return Content("Permissions Not changed");
            }

            return Content("Permissions changed");
        }

        [CustomAuthorize(Roles = "Staff")]
        public ActionResult StaffView()
        {
            return View();
        }

        [CustomAuthorize(Roles = "EndUser")]
        public ActionResult EndUserView()
        {
             return View();
        }
    }
}