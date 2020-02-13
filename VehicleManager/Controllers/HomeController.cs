using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using VehicleManager.Models;

namespace VehicleManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var oDB = new VehicleDB.VehicleData();
            var oVehicles = oDB.GetVehicles();
            return View(oVehicles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Owner_First, Owner_Last, Owner_Phone, Owner_Unit, Owner_Apt, Make, Model, Color")] Vehicle oVehicle)
        {
            if (ModelState.IsValid)
            {
                var oDB = new VehicleDB.VehicleData();
                oDB.SaveVehicle(oVehicle);
                return RedirectToAction("Index");
            }

            return View(oVehicle);
        }

        public ActionResult Edit(Guid? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var oDB = new VehicleDB.VehicleData();
            Vehicle oVehicle = oDB.GetVehicleById(ID.GetValueOrDefault());

            if (oVehicle == null)
            {
                return HttpNotFound();
            }
            return View(oVehicle);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Owner_First, Owner_Last, Owner_Phone, Owner_Unit, Owner_Apt, Make, Model, Color")] Vehicle oVehicle)
        {
            if (ModelState.IsValid)
            {
                var oDB = new VehicleDB.VehicleData();
                oDB.SaveVehicle(oVehicle);
                return RedirectToAction("Index");
            }
            return View(oVehicle);
        }

        public ActionResult Search(string oSearch)
        {
            List<Vehicle> oVehicles = new List<Vehicle>();
            if (String.IsNullOrEmpty(oSearch))
            {
                ViewBag.Search = "";
                return View(oVehicles);
            }
            else
            {
                ViewBag.Search = oSearch;
                var oDB = new VehicleDB.VehicleData();
                oVehicles = oDB.SearchVehicle(oSearch);
                return View(oVehicles);
            }
        }

    }
}