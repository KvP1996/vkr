using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QBaseServer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public HtmlString Index()
        {
            string res = "<b>QBase server.</b> <br><br><br>" + 
                "<i>/algorithms</i>" +
                "<ul><li>GET algorithms list</li>" + 
                "<li>POST new algorithm(JSON with name and description)</li></ul><br><br>" + 
                "<i>/algorithms/id</i>" + 
                "<ul><li>DELETE algorithm</li>" + 
                "<li>PUT algorithm(JSON with name and description)</li>" +
                "<li>POST new Q-determinant (JSON with fields \"Determinant\" and \"Dimensions\")</li>" + 
                "<li>GET Q-determinants' IDs</li></ul><br><br>" +
                "<i>/algorithms/attribute/commoncompare</i>" +
                "<ul><li>Compare algorithms' ticks or processors (POST)</li></ul><br><br>" +
                "<i>/determinants/id</i>" + 
                "<ul><li>GET Q-determinant</li>" + 
                "<li>DELETE Q-determinant</li></ul><br><br>" +
                "<i>/determinants/id/attribute</i>" +
                "<ul><li>GET Q-determinant's attribute's value (ticks, processors, dimensions)</li></ul><br><br>";
            return new HtmlString(res);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
