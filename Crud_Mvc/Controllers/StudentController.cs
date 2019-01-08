using Crud_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        DataAccessLayer.db dbLayer = new DataAccessLayer.db();
        public ActionResult Show()
        {
            DataSet ds = dbLayer.ShowAllStudentRecords();
            ViewBag.stud = ds.Tables[0];

            return View();
        }
        public ActionResult AddRecord()
        {
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
            TempData["msg"] = "Record Added Successfully";
            return View();
        }
        public ActionResult UpdateRecord(int id)
        {
            DataSet ds = dbLayer.ShowRecorById(id);
            ViewBag.studrecord = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult UpdateRecord(int id,FormCollection fc)
        {
            Student student = new Student();


            //student.Id = Int32.Parse(id);
            student.Id = id;
            student.StudentName = fc["Name"];
            student.Address = fc["Address"];
            student.City = fc["City"];
            student.EmailId = fc["EmailId"];
            dbLayer.Update_Record(student);
            TempData["msg"] = "Record Updated Successfully";
             return RedirectToAction("Show");
          //  return View();
        }

        public ActionResult DeleteRecord(int id)
        {
            dbLayer.DeleteRecord(id);
            TempData["msg"] = "Record Deleted";
            return RedirectToAction("Show");
        }
    }
}