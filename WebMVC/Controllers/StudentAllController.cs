using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Crud_Mvc.Models;
using MealDataAccess;

namespace WebMVC.Controllers
{
    public class StudentAllController : Controller
    {
        Crud_Mvc.DataAccessLayer.db dbLayer = new Crud_Mvc.DataAccessLayer.db();
        // GET: Student
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("Http://localhost:51530/WebApi");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/Stud/GetStud").Result;
            if(response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<student>>().Result;
            }
            else
            {
                ViewBag.result = "Error";
            }
            return View();
        }
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(FormCollection fc)
        {
            Student student = new Student();
            student.StudentName = fc["Name"];
            student.Address = fc["Address"];
            student.City = fc["City"];
            student.EmailId = fc["EmailId"];
           // dbLayer.AddStudent(student);
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("Http://localhost:51530/WebApi");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("api/Stud/AddStudent",student).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["msg"] = "inserted";
                RedirectToAction("Index");
            }
            else
            {
                ViewBag.result = "Error";
            }
            return View();
        }
        public ActionResult UpdateStud(int id)
        {
            DataSet ds = dbLayer.ShowRecorById(id);
            ViewBag.studrecord = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult UpdateStud(int id, FormCollection fc)
        {
            Student student = new Student();
            //student.Id = Int32.Parse(id);
            student.Id = id;
            student.StudentName = fc["Name"];
            student.Address = fc["Address"];
            student.City = fc["City"];
            student.EmailId = fc["EmailId"];
            dbLayer.Update_Record(student);
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("Http://localhost:51530/WebApi");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsJsonAsync("api/Stud/UpdateStudent", student).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["msg"] = "Record Updated Successfully";
                RedirectToAction("Index");
            }
            else
            {
                ViewBag.result = "Error";
            }
            ViewBag.studrecord = student;
            return View();
        }
    }
}