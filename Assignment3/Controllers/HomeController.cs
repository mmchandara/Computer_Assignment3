using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            IEnumerable<Staff> staffs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53766/api/");
                //HTTP GET
                var responseTask = client.GetAsync("staffs");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Staff>>();
                    readTask.Wait();

                    staffs = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    staffs = Enumerable.Empty<Staff>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(staffs);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Staff staffs)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53766/api/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Staff>("staffs", staffs);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(staffs);
        }
        public ActionResult Edit(int id)
        {
            Staff staffs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53766/api/");
                //HTTP GET
                var responseTask = client.GetAsync("staffs?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Staff>();
                    readTask.Wait();

                    staffs = readTask.Result;
                }
            }

            return View(staffs);
        }
        [HttpPost]
        public ActionResult Edit(Staff staffs)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53766/api/staffs");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Staff>("staffs", staffs);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(staffs);
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53766/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("staffs/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
