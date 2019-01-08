using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppEntityFramework.Models;
using Crud_Mvc.DataAccessLayer;
using Crud_Mvc.Models;

namespace WebAppEntityFramework.Api
{
    public class StudController : ApiController
    {
        List<student> lstStudent = new List<student>();
        db dbLayer = new db();
       // Db dbLayer = new Db();
        [HttpGet]
        public IEnumerable<student> GetStud()
        {

            using (StudentdbEntities studentdbEntities = new StudentdbEntities())
            {
                lstStudent = studentdbEntities.students.ToList();
                return (lstStudent);
            }         
        }

        // POST api/values
        [HttpPost]
        public bool AddStudent(Student stud)
        {
            Student student = new Student();
            student.StudentName = stud.StudentName;
            student.Address = stud.Address;
            student.City = stud.City;
            student.EmailId = stud.EmailId;
            dbLayer.AddStudent(student);
            dbLayer.AddStudent(student);

            //StudentdbEntities db = new StudentdbEntities();
            //db.students.Add(stud);
            //db.SaveChanges();;
            return true;

        }
        [HttpPut]
        public bool UpdateStudent(Student stud)
        {
            Student student = new Student();
            
            student.Id = stud.Id;
            student.StudentName = stud.StudentName;
            student.Address = stud.Address;
            student.City = stud.City;
            student.EmailId = stud.EmailId;
            dbLayer.Update_Record(student);

            //StudentdbEntities db = new StudentdbEntities();
            //db.students.Add(stud);
            //db.SaveChanges();
            return true;

        }
        [HttpDelete]
        public bool DeleteStudent(int id)
        {
           bool res = dbLayer.DeleteStudent(id);
            return res;
            
        }
    }
}
