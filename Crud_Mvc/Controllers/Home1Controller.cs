using Crud_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Mvc.Controllers
{
    public class Home1Controller : Controller
    {
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
        DataAccessLayer.db dbLayer = new DataAccessLayer.db();
        public ActionResult Show()
        {
            DataSet ds = dbLayer.ShowAllStudentRecords();
            ViewBag.stud = ds.Tables[0];

            return View();
        }

        [HttpPost]
        public ActionResult AddRecord(FormCollection formCollection)
        {
            Student student = new Student();
            student.StudentName = formCollection["Name"];
            student.Address = formCollection["Address"];
            student.City = formCollection["City"];
            student.EmailId = formCollection["EmailId"];
            dbLayer.AddStudent(student);
            TempData["msg"] = "inserted";
            return View();
        }
        public ActionResult GetRecord(FormCollection formCollection)
        {
            Student student = new Student();
            student.StudentName = formCollection["Name"];
            student.Address = formCollection["Address"];
            student.City = formCollection["City"];
            student.EmailId = formCollection["EmailId"];
            dbLayer.AddStudent(student);
            TempData["msg"] = "inserted";
            return View();
        }
    }
}