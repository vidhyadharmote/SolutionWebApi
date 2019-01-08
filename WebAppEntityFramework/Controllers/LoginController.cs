using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppEntityFramework.Models;

namespace WebAppEntityFramework.Controllers
{
    public class LoginController : Controller
    {
        Db dbLayer = new Db();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user usr)
        {
            List<user> lst = new List<user>();
            StudentdbEntities db = new StudentdbEntities();
            lst= dbLayer.Login_User(usr);
            TempData["msg"] = "Login Successs";

            //var ussr = db.users.Single(u => u.Name == usr.Name && u.passwd == usr.passwd);
                if(lst != null && lst.Count>0)
                {
                    FormsAuthentication.SetAuthCookie(Request.Form["UserId"], true);
                    Session["UserId"] = lst.FirstOrDefault().UserId;
                    Session["Username"] = lst.FirstOrDefault().Name;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                TempData["msg"] = "Incorrect Username or Password";
                    return View("Login");
                }
            

        }
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Register(user usr)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using(StudentdbEntities db = new StudentdbEntities())
        //        {
        //            db.users.Add(usr);
        //            db.SaveChanges();
                    
        //        }
        //        ModelState.Clear();
        //        ViewBag.msg = "User Registered Successfully";
        //    }
        //    return RedirectToAction("Login");
        //}

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection formCollection)
        {

            int usrtype = 1;
            bool isActive = false;
            user usr = new user();
            usr.Name = formCollection["Name"];
            usr.passwd = formCollection["passwd"];
            usr.IsActive = isActive;
            usr.UserType = usrtype;
            dbLayer.AddUser(usr);
            TempData["msg"] = "inserted";
            return RedirectToAction("Login");
        }
    }
}