using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEntityFramework.Models;

namespace WebAppEntityFramework.Controllers
{
    public class OrderController : Controller
    {
        List<OrderVM> lstOrders = new List<OrderVM>();
        // GET: Order
        public ActionResult Orders()
        {
            // StudentdbEntities db = new StudentdbEntities();
            //var empOrders = db.employees.Join(db.Ordertbls,
            //     e => e.Id, o => o.EmployeeId, (e, o) => e);
            // //return View();
            // return View(ViewBag.orderDetails=empOrders);
            StudentdbEntities db = new StudentdbEntities();
            List<OrderVM> lstOrders = new List<OrderVM>();
            lstOrders = (from emp in db.employees                     
                     join od in db.Ordertbls on emp.Id equals od.EmployeeId
                     join it in db.Items on od.ItemId equals it.Id
                     orderby od.Id
                     select new OrderVM
                     {
                         Id=od.Id,
                         EmpName =emp.EmpName,
                         ItemName=it.ItemName,
                         Price=it.Price,
                         Descr=od.Descr                         
                     }).ToList();
            return View(lstOrders);
        }

        public ActionResult OrdersLeftJoin()
        {
            StudentdbEntities db = new StudentdbEntities();
            List<OrderVM> lstOrders = new List<OrderVM>();
            //Working
            lstOrders = (from it in db.Items
                         join od in db.Ordertbls on it.Id equals od.ItemId
                         //orderby od.Id
                         into dep
                         from dept in dep.DefaultIfEmpty()
                         select new OrderVM
                         {
                             Id = (int?)it.Id,
                             // Id = dept.Id,
                             ItemName = it.ItemName,
                             Price = it.Price,
                             Descr = dept.Descr
                         }).ToList();


            //lstOrders = (from it in db.Items
            //             join od in db.Ordertbls on it.Id equals od.ItemId
            //             //orderby od.Id

            //             select new OrderVM
            //             {
            //                 Id = od.Id,
            //                 ItemName = it.ItemName,
            //                 Price = it.Price,
            //                 Descr = od.Descr
            //             }).ToList();


            //var query = from e in db.employees
            //            join od in db.Ordertbls on e.Id equals od.EmployeeId into t
            //            from nt in t.DefaultIfEmpty()
            //            orderby e.Id

            //            select new
            //            {
            //                e.Id,
            //                e.EmpName,
            //                nt.Descr
            //            };




            // StudentdbEntities db = new StudentdbEntities();
            //lstOrders = (from emp in db.employees
            //             join od in db.Ordertbls on emp.Id equals od.EmployeeId
            //             join it in db.Items on od.ItemId equals it.Id
            //             into dep
            //             from dept in dep.DefaultIfEmpty()
            //             select new OrderVM
            //             {
            //                 Id = (int?)dept.Id,
            //                 EmpName = emp.EmpName,
            //                 ItemName = dept.ItemName,
            //                 Price = dept.Price,
            //                 Descr = od.Descr
            //             }).ToList();

            //var lst = (from emp in db.employees
            //           join od in db.Ordertbls on emp.Id equals od.EmployeeId
            //           join it in db.Items on od.ItemId equals it.Id
            //           into dep
            //           from dept in dep.DefaultIfEmpty()
            //           select emp
            //          ).ToList();


            return View(lstOrders);
        }
    }
}