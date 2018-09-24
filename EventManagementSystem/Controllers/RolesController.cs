using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventManagementSystem.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            //Populate Dropdown List
            var context = new ApplicationDbContext();

            var roleList = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            ViewBag.Message = "";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string RoleName)
        {
            var context = new ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        //Edit Get
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string RoleName)
        {

            var context = new ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            return View(thisRole);
        }

        ///Edit Post
        ///
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(IdentityRole role)
        {

            try
            {
                var context = new ApplicationDbContext();
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Create Get
        [Authorize(Roles = "Admin")]

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public ActionResult Create(FormCollection collection)
        {

            try
            {
                var context = new ApplicationDbContext();
                context.Roles.Add(new IdentityRole() { Name = collection["RoleName"] });
                context.SaveChanges();
                ViewBag.Message = "Role Created Successfull !!!!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
        //Getting a list of roles for a user
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))

            {
                var context = new ApplicationDbContext();
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userStor = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStor);
                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);

                //Populate Dropdown List

                var roleList = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = roleList;

                var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
                ViewBag.Users = userList;


                ViewBag.Message = "Roles Retrieved Successfully";


            }
            return View("Index");
        }


        //Adding Roles to a user 

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            var context = new ApplicationDbContext();
            if (context == null)
            {
                throw new ArgumentNullException("context", "Context must not be null");
            }

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userStor = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStor);
            userManager.AddToRole(user.Id, RoleName);

            ViewBag.Message = "Role Created successfully";


            //DropDownlist


            var roleList = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;


            ViewBag.Message = "Roles Retrieved Successfully";


            return View("Index");


        }
        //Deleting User From a Roles 

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var account = new AccountController();
            var context = new ApplicationDbContext();

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();


            var userStor = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStor);
            if (userManager.IsInRole(user.Id, RoleName))
            {
                userManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.Message = "Role remove From this user successfully";

            }
            else
            {
                ViewBag.Message = "This User doesn't belong to selected role!!!!";
            }



            // Populate DropDownlist


            var roleList = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            return View("Index");

        }
    }
}
