using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAppEntityFramework.Models;

namespace WebAppEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        List<employee> empList = new List<employee>();
        [Authorize]
        public ActionResult Index()
        {
            if(Session["UserId"] != null)
            {
                
                using (StudentdbEntities studentdbEntities = new StudentdbEntities())
                {
                    empList = studentdbEntities.employees.ToList();
                    return View(empList);
                }
            }
            else
            {
                return RedirectToAction("Login","Login");
            }

            //ViewBag.Title = "Home Page";

            
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(employee emp)
        {
            StudentdbEntities db = new StudentdbEntities();
             db.employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");

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
        public ActionResult Delete(int? id)
        {
            StudentdbEntities db = new StudentdbEntities();
            if(id != null)
            {
                employee emp = db.employees.Find(id);
                db.employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            StudentdbEntities db = new StudentdbEntities();

            employee emp = db.employees.Where(x => x.Id == id).Single();
            if(emp == null)
            {
                return HttpNotFound();
            }
                
                return View(emp);
           

            //return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(employee emp)
        {
            StudentdbEntities db = new StudentdbEntities();
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}