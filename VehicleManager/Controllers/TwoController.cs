using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleManager.Controllers
{
    public class TwoController : Controller
    {
        // GET: Two
        public ActionResult Index()
        {
            ViewBag.Unique = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection oForm)
        {
            string sUnique = "";
            var sValues = oForm["arrValues"].Trim();
            var arrValues = sValues.Split((" ").ToCharArray());

            #region LINQ Solution
            //var uValues = arrValues.GroupBy(i => i).Where(i => i.Count() < 2).Select(i => i.First());
            //foreach(var oValue in uValues)
            //{
            //    sUnique += oValue + " ";
            //}
            #endregion

            #region Non-LINQ Solution
            var oCounts = new Dictionary<string, int>();
            foreach (var aValue in arrValues)
            {
                if (oCounts.ContainsKey(aValue))
                    oCounts[aValue]++;
                else
                    oCounts.Add(aValue, 1);
            }

            foreach (var oCount in oCounts)
            {
                if (oCount.Value < 2)
                {
                    sUnique += oCount.Key + " ";
                }
            }
            #endregion

            ViewBag.Unique = sUnique;
            return View();
        }
    }
}