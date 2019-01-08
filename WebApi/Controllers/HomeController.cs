using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MealDataAccess;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<employee> empList = new List<employee>();
            using(StudentdbEntities studentdbEntities =new StudentdbEntities())
            {
                empList=studentdbEntities.employees.ToList();
            }
            
            //ViewBag.Title = "Home Page";

            return View(empList);
        }
        //public ActionResult Show()
        //{
        //    DataSet ds = dbLayer.ShowAllStudentRecords();
        //    ViewBag.stud = ds.Tables[0];

        //    return View();
        //}
    }
}
