using ItemMaster.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ItemMaster.Website.Controllers
{
    public class ItemController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            IEnumerable<ItemViewModel> Item = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ItemMaster/GetItems");

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ItemViewModel>>();
                    readTask.Wait();

                    Item = readTask.Result;
                }
                else 
                {
                   

                    Item = Enumerable.Empty<ItemViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Item);
        }


        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(ItemViewModel Item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/Item");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ItemViewModel>("ItemMaster/InsertItem", Item);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Item);
        }


        public ActionResult Edit(int id)
        {
            ItemViewModel Item = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ItemMaster/GetItemByID?pItemID=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ItemViewModel>();
                    readTask.Wait();

                    Item = readTask.Result;
                }
            }

            return View(Item);
        }


        [HttpPost]
        public ActionResult Edit(ItemViewModel Item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/Item");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ItemViewModel>("ItemMaster/UpdateItem", Item);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Item);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("ItemMaster/DeleteItem?pItemID=" + id.ToString());
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