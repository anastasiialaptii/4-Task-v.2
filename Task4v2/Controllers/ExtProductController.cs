using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ExtProductController : Controller
    {
        private ExtProductManager extProductManager = new ExtProductManager();
        List<ExtProductModel> extProductModels = new List<ExtProductModel>();

        public ActionResult CreateExtProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                extProductModels.Add(extProduct);
                return RedirectToAction("ExtProductSessionList");
            }
            return View();
        }

        public ActionResult ExtProductSessionList()
        {
            return View(extProductModels);
        }
    }
}